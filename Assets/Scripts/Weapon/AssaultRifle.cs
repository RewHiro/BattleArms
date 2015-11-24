using UnityEngine;
using System.Collections;

public class AssaultRifle : Weapon
{

    //Speedを大きくしすぎるとみえなくなるから注意
    [SerializeField]
    float Speed = 100;//速度

    GameObject bullet = null;

    void Start()
    {
        bullet = FindObjectOfType<BulletCreater>().getAssaulutBullet;
    }

    public override void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            var obj = Instantiate(bullet);
            obj.transform.position = gameObject.transform.position;
            obj.transform.Translate(gameObject.transform.forward * 2.5f);
            obj.transform.rotation = gameObject.transform.rotation;
            Vector3 force;
            force = gameObject.transform.forward * Speed;
            obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            shot_count_ = 0.1f;
        }
        shot_count_ -= Time.deltaTime;
    }

    public override void OnNotAttack()
    {
        shot_count_ = 0.0f;
    }

    float shot_count_ = 0.0f;
}
