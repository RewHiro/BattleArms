using UnityEngine;

public class PlayerModer : MonoBehaviour
{
    [SerializeField]
    GameObject effect_ = null;

    Vector3 hit_position_ = Vector3.zero;
    PlayerMode player_mode_ = PlayerMode.NORMAL;
    PlayerMeleeAttacker player_melee_attacker_ = null;
    Rigidbody rigidbody_ = null;
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
        player_melee_attacker_ = GetComponent<PlayerMeleeAttacker>();
        rigidbody_ = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (!isMeleeMode) return;
        transform.position.Set(hit_position_.x, transform.position.y, hit_position_.z);

        if (!player_melee_attacker_.isThreeAttacked) return;
        rigidbody_.AddForce(-transform.forward * 50.0f, ForceMode.Impulse);
        player_mode_ = PlayerMode.NORMAL;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.GetHashCode() != ENEMY_HASH) return;
        if (collider.gameObject.GetComponent<EnemyStater>().isStop) return;
        var direction = new Vector3(transform.forward.x, 0, transform.forward.z);
        hit_position_ = transform.position - direction * 10.0f;
        player_mode_ = PlayerMode.MELEE;

        for (int i = 0; i < 4; i++)
        {
            var effect = Instantiate(effect_);
            var position = transform.position;
            position.y += 2.0f;
            effect.transform.position = position;
            Destroy(effect, 4.0f);
        }
    }
}
