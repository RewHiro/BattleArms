using UnityEngine;
using System.Collections;

public class HitDestoryer : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        var layer = collider.gameObject.layer;
        if (layer != LayerMask.NameToLayer("PlayerBullet") &&
            layer != LayerMask.NameToLayer("EnemyBullet") &&
            layer != LayerMask.NameToLayer("Player") &&
            layer != LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var layer = collision.gameObject.layer;
        if (layer != LayerMask.NameToLayer("PlayerBullet") &&
            layer != LayerMask.NameToLayer("EnemyBullet") &&
            layer != LayerMask.NameToLayer("Player") &&
            layer != LayerMask.NameToLayer("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
