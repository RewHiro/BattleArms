using UnityEngine;
using System.Collections.Generic;

public class ShotGun : Weapon
{

    float shot_count_ = 0.0f;

    //Speedを大きくしすぎるとみえなくなるから注意
    [SerializeField]
    float Speed = 100;//速度

    override public void OnAttack()
    {
        if (shot_count_ <= 0.0f)
        {
            shot_count_ = 0.8f;
        }
        shot_count_ -= Time.deltaTime;
    }

    override public void OnNotAttack()
    {
        shot_count_ = 0.0f;
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
            var obj = Instantiate(FindObjectOfType<BulletCreater>().getAssaulutBullet);
            obj.transform.position = gameObject.transform.position;
            obj.transform.Translate(gameObject.transform.forward * 1.5f);
            obj.transform.rotation = gameObject.transform.rotation;
            Vector3 force;

            var reticle_position = Reticle.transform.position;

            var direction = (reticle_position - transform.position).normalized;

            var random = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
            force = (direction + random) * 100;
            obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

            Destroy(obj, 3.0f);

            bullets.Add(obj);
        }
        return bullets;
    }
}
