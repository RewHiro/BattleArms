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
        Debug.Log("OK");
        bullet_creater_ = FindObjectOfType<BulletCreater>();
    }

    public override void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            Debug.Log(FindObjectOfType<BulletCreater>());
            //var obj = Instantiate(bullet);
            //obj.transform.position = gameObject.transform.position;
            //obj.transform.Translate(gameObject.transform.forward * 2.5f);
            //obj.transform.rotation = gameObject.transform.rotation;
            //Vector3 force;
            //force = gameObject.transform.forward * Speed;
            //obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            //shot_count_ = 0.1f;
            //NetworkServer.Spawn(obj);
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
