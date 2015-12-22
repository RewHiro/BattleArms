using UnityEngine;

public class MeleeHand : MonoBehaviour
{
    [SerializeField]
    GameObject player_ = null;

    [SerializeField]
    GameObject effect_ = null;

    PlayerMeleeAttacker player_melee_attacker_ = null;

    int ENEMY_HASH = 0;

    void Start()
    {
        ENEMY_HASH = "Enemy".GetHashCode();
        player_melee_attacker_ = player_.GetComponent<PlayerMeleeAttacker>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.GetHashCode() != ENEMY_HASH) return;
        
        player_melee_attacker_.SendAttack();
        collider.gameObject.GetComponent<EnemyStater>().SendAttacked();

        var effect = Instantiate(effect_);
        effect.transform.position = collider.transform.position;
        Destroy(effect, 4.0f);
    }
}
