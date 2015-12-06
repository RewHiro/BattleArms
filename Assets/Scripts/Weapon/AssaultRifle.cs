using UnityEngine;
using System.Collections.Generic;

public class AssaultRifle : Weapon
{

    //Speedを大きくしすぎるとみえなくなるから注意
    [SerializeField]
    float Speed = 100;//速度

    BulletCreater bullet_creater_ = null;

    void Start()
    {
        bullet_creater_ = FindObjectOfType<BulletCreater>();
    }

    public override void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            shot_count_ = 0.1f;
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
        var obj = Instantiate(FindObjectOfType<BulletCreater>().getAssaulutBullet);
        obj.transform.position = gameObject.transform.position;
        obj.transform.Translate(gameObject.transform.forward * 2.5f);
        obj.transform.rotation = gameObject.transform.rotation;
        Vector3 force;

        var reticle_position = Reticle.transform.position;

        var direction = (reticle_position - transform.position).normalized;
        force = direction * 100;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        Destroy(obj, 3.0f);

        bullets.Add(obj);

        FindObjectOfType<SoundManager>().PlaySE(7);

        return bullets;
    }


    float shot_count_ = 0.0f;
}
