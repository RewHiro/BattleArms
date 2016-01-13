using UnityEngine;
using System.Collections.Generic;


public class HomingGun : Weapon
{
    BulletCreater bullet_creater_ = null;

    float POWER = 0.0f;

    void Start()
    {
        bullet_creater_ = FindObjectOfType<BulletCreater>();
        var parameter = FindObjectOfType<HomingMissileParameter>();
        if (parameter == null) return;
        POWER = parameter.GetAttackPower(0);
    }

    public override void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            shot_count_ = 1.5f;
        }
        shot_count_ -= Time.deltaTime;
    }

    public override void OnNotAttack()
    {
        shot_count_ = 0.0f;
    }

    public override bool CanShot()
    {
        return shot_count_ <= 0.0f;
    }

    public override IEnumerable<GameObject> CreateBullet()
    {
        List<GameObject> bullets = new List<GameObject>();
        var obj = Instantiate(FindObjectOfType<BulletCreater>().getHomingBullet);
        obj.transform.position = gameObject.transform.position;;
        obj.transform.rotation = gameObject.transform.rotation;

        obj.GetComponent<HomingBulletMover>().SetReticle(Reticle.GetComponentInChildren<Reticle>());

        obj.GetComponent<BulletPower>().SetPower(POWER);

        bullets.Add(obj);

        return bullets;
    }


    float shot_count_ = 0.0f;
}
