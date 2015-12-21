using UnityEngine;

public class PlayerModer : MonoBehaviour
{
    Vector3 hit_position_ = Vector3.zero;
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

    void Update()
    {
        if (!isMeleeMode) return;
        transform.position.Set(hit_position_.x, transform.position.y, hit_position_.z);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.GetHashCode() != ENEMY_HASH) return;
        var direction = new Vector3(transform.forward.x, 0, transform.forward.z);
        hit_position_ = transform.position - direction * 5.0f;
        player_mode_ = PlayerMode.MELEE;
    }
}
