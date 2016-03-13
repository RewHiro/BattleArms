using UnityEngine;
using System.Collections.Generic;

public class ShotGun : Weapon
{

    float shot_count_ = 0.0f;

    //Speedを大きくしすぎるとみえなくなるから注意
    [SerializeField]
    float Speed = 100;//速度

    Vector3 origin_pos_ = Vector3.zero;

    [SerializeField]
    GameObject spark_prefab_ = null;

    float POWER = 0.0f;

    void Start()
    {
        var parameter = FindObjectOfType<ShotGunParameter>();
        if (parameter == null) return;
        POWER = parameter.GetAttackPower(0);
    }

    override public void OnAttack()
    {
        spark_prefab_.SetActive(false);
        if (shot_count_ <= 0.0f)
        {
            shot_count_ = 0.8f;

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

    override public void OnNotAttack()
    {
        shot_count_ = 0.0f;
        spark_prefab_.SetActive(false);
    }

    override public bool CanShot()
    {
        return shot_count_ <= 0.0f;
    }

    override public IEnumerable<GameObject> CreateBullet()
    {
        List<GameObject> bullets = new List<GameObject>();
        for (int i = 0; i < 8; ++i)
        {
            var obj = Instantiate(FindObjectOfType<BulletCreater>().getShotGunBullet);
            obj.transform.position = gameObject.transform.position;
            obj.transform.Translate(gameObject.transform.forward * 1.5f);
            obj.transform.rotation = gameObject.transform.rotation;
            Vector3 force;

            var reticle_position = Reticle.transform.position;

            var direction = (reticle_position - transform.position).normalized;

            const float diff = 0.1f;

            var random = new Vector3(Random.Range(-diff, diff), Random.Range(-diff, diff), Random.Range(-diff, diff));
            force = (direction + random) * 300;
            obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

            obj.layer = layer_;

            obj.GetComponent<BulletPower>().SetPower(POWER);

            Destroy(obj, 3.0f);

            bullets.Add(obj);
        }
        return bullets;
    }
}
