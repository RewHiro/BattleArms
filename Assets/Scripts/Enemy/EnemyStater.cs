using UnityEngine;

public class EnemyStater : MonoBehaviour
{
    Vector3 hit_position_ = Vector3.zero;
    Quaternion hit_rotate_ = Quaternion.identity;
    EnemyState enemy_state_ = EnemyState.NORMAL;
    int PLAYER_HASH = 0;

    public bool isNormal
    {
        get
        {
            return enemy_state_ == EnemyState.NORMAL;
        }
    }

    public bool isMeleed
    {
        get
        {
            return enemy_state_ == EnemyState.MELEED;
        }
    }

    public bool isStop
    {
        get
        {
            return enemy_state_ == EnemyState.STOP;
        }
    }

    void Start()
    {
        PLAYER_HASH = "Player".GetHashCode();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (PLAYER_HASH != collider.gameObject.tag.GetHashCode()) return;
        enemy_state_ = EnemyState.MELEED;
        hit_position_ = transform.position;
        hit_rotate_ = transform.rotation;
    }

    void Update()
    {
        if (!isMeleed) return;
        transform.position.Set(hit_position_.x, transform.position.y, hit_position_.z);
        transform.rotation = hit_rotate_;
    }
}
