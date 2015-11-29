using UnityEngine;
using System.Collections.Generic;

public class Rocket : Weapon
{
    BulletCreater bullet_creater_ = null;

    void Start()
    {
        bullet_creater_ = FindObjectOfType<BulletCreater>();
    }

    public override void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            shot_count_ = 1.0f;
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
        var obj = Instantiate(FindObjectOfType<BulletCreater>().getRocketBullet);
        obj.transform.position = gameObject.transform.position;
        obj.transform.Translate(gameObject.transform.forward * 2.5f);
        obj.transform.rotation = gameObject.transform.rotation;
        Destroy(obj, 1.5f);

        bullets.Add(obj);
        return bullets;
    }


    float shot_count_ = 0.0f;
}
