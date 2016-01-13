using UnityEngine;
using UnityEngine.Networking;

public class MeleeHand : MonoBehaviour
{
    [SerializeField]
    GameObject player_ = null;

    [SerializeField]
    GameObject effect_ = null;

    [SerializeField]
    GameObject explosion_effect_ = null;

    PlayerMeleeAttacker player_melee_attacker_ = null;
    SoundManager sound_manager_ = null;
    int ENEMY_HASH = 0;

    void Start()
    {
        ENEMY_HASH = "Enemy".GetHashCode();
        player_melee_attacker_ = player_.GetComponent<PlayerMeleeAttacker>();
        sound_manager_ = FindObjectOfType<SoundManager>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag.GetHashCode() != ENEMY_HASH) return;
        player_melee_attacker_.SendAttack();
        collider.gameObject.GetComponent<EnemyStater>().SendAttacked();

        var effect = Instantiate(effect_);
        effect.transform.position = transform.position;
        Destroy(effect, 4.0f);

        var explosion = Instantiate(explosion_effect_);
        explosion.transform.position = collider.gameObject.transform.position;
        NetworkServer.Spawn(explosion);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.GetHashCode() != ENEMY_HASH) return;

        sound_manager_.PlaySE(6);

        player_melee_attacker_.SendAttack();
        collision.gameObject.GetComponent<EnemyStater>().SendAttacked();

        var effect = Instantiate(effect_);
        effect.transform.position = transform.position;
        Destroy(effect, 4.0f);

        var explosion = Instantiate(explosion_effect_);
        explosion.transform.position = collision.gameObject.transform.position;
        NetworkServer.Spawn(explosion);
    }
}
