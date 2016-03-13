using UnityEngine;

public class ReSpawner : MonoBehaviour
{
    readonly int PLAYER_NAME_HASH = "Player".GetHashCode();
    readonly int ENEMY_NAME_HASH = "Enemy".GetHashCode();

    [SerializeField]
    GameObject re_spawn_ = null;

    //void OnTriggerEnter(Collider collider)
    //{
    //    Debug.Log(collider.name);
    //    var hash_code = collider.GetHashCode();
    //    if (!(hash_code == PLAYER_NAME_HASH ||
    //        hash_code == ENEMY_NAME_HASH)) return;

    //    collider.gameObject.transform.position = re_spawn_.transform.position;
    //}

    void OnCollisionEnter(Collision collision)
    {
        var hash_code = collision.gameObject.tag.GetHashCode();
        if (!(hash_code == PLAYER_NAME_HASH ||
            hash_code == ENEMY_NAME_HASH)) return;

        collision.gameObject.transform.position = re_spawn_.transform.position;
    }
}
