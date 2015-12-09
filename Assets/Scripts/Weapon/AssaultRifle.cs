using UnityEngine;
using System.Collections.Generic;

public class AssaultRifle : Weapon
{

    //Speedを大きくしすぎるとみえなくなるから注意
    [SerializeField]
    float Speed = 100;//速度

    BulletCreater bullet_creater_ = null;
    Vector3 origin_pos_ = Vector3.zero;

    [SerializeField]
    GameObject spark_prefab_ = null;

    void Start()
    {
        bullet_creater_ = FindObjectOfType<BulletCreater>();
    }

    public override void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            shot_count_ = 0.1f;

            if (origin_pos_ == Vector3.zero)
            {
                origin_pos_ = WeaponObject.transform.localPosition;
            }
            spark_prefab_.SetActive(true);
            var diff = 0.01f;
            var random = new Vector3(Random.Range(-diff, diff), Random.Range(-diff, diff), 0.0f);
            WeaponObject.transform.localPosition = origin_pos_ + random; 
        }
        shot_count_ -= Time.deltaTime;
    }

    public override void OnNotAttack()
    {
        shot_count_ = 0.0f;
        spark_prefab_.SetActive(false);
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

        const float diff = 0.1f;

        var random = new Vector3(Random.Range(-diff, diff), Random.Range(-diff, diff), Random.Range(-diff, diff));

        force = (direction + random) * 300;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

        obj.layer = layer_;

        Destroy(obj, 3.0f);

        bullets.Add(obj);

        FindObjectOfType<SoundManager>().PlaySE(7);

        return bullets;
    }


    float shot_count_ = 0.0f;
}
