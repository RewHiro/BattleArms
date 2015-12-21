using UnityEngine;

public class PlayerModer : MonoBehaviour
{
    PlayerMode player_mode_ = PlayerMode.NORMAL;
    int ENEMY_HASH = 0;

    public bool isNormalMode
    {
        get
        {
            return player_mode_ == PlayerMode.NORMAL;
        }
    }

    public bool isMeleeMode
    {
        get
        {
            return player_mode_ == PlayerMode.MELEE;
        }
    }

    void Start()
    {
        ENEMY_HASH = "Enemy".GetHashCode();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.GetHashCode() != ENEMY_HASH) return;
        
        player_mode_ = PlayerMode.MELEE;
    }
}
