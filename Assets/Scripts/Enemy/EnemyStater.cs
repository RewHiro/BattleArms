using UnityEngine;

public class EnemyStater : MonoBehaviour
{
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

    void OnCollisionEnter(Collision collision)
    {
        if (PLAYER_HASH != collision.gameObject.tag.GetHashCode()) return;
        enemy_state_ = EnemyState.MELEED;
    }
}
