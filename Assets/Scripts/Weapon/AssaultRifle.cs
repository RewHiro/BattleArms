using UnityEngine;
using UnityEngine.Networking;

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

    public override GameObject CreateBullet()
    {
        var obj = Instantiate(FindObjectOfType<BulletCreater>().getAssaulutBullet);
        obj.transform.position = gameObject.transform.position;
        obj.transform.Translate(gameObject.transform.forward * 2.5f);
        obj.transform.rotation = gameObject.transform.rotation;
        Vector3 force;
        force = gameObject.transform.forward * 100;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        return obj;
    }


    float shot_count_ = 0.0f;
}
