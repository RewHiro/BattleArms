using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HPManager : NetworkBehaviour
{
    bool is_active_ = true;

    [SerializeField]
    int layer_num_ = 3;

    [SyncVar]
    float hp_ = 100;

    [SerializeField]
    GameObject hit_effect_prefab = null;

    [SerializeField]
    GameObject destory_effect_prefab_ = null;

    [SerializeField]
    GameObject hp_text_ = null;

    SoundManager sound_manager_ = null;

    float MAX_HP = 0.0f;

    public bool isActive
    {
        get
        {
            return is_active_;
        }
    }

    public float hp
    {
        private set
        {
            hp_ = value;
        }
        get
        {
            return hp_;
        }
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }

    void Start()
    {
        var id = GetComponent<Identificationer>().id;
        hp = FindObjectOfType<AirFrameParameter>().GetMaxHP(id);
        MAX_HP = hp;
        sound_manager_ = FindObjectOfType<SoundManager>();
    }

    void Death()
    {
        if (!isServer) return;
        if (!isActive) return;
        if (hp_ > 0) return;
        var destory_effect = Instantiate(destory_effect_prefab_);
        destory_effect.transform.SetParent(gameObject.transform);
        destory_effect.transform.position = gameObject.transform.position;
        is_active_ = false;
        sound_manager_.PlaySE(0);
    }

    void Update()
    {
        Death();
        if (!isLocalPlayer) return;
        if (hp_text_ == null) return;

        hp_text_.GetComponent<Text>().text = "HP:" + hp_.ToString() + "/" + MAX_HP.ToString();

    }

    void OnTriggerEnter(Collider collider)
    {
        if (!isServer) return;
        if (collider.gameObject.layer != layer_num_) return;

        hp -= collider.gameObject.GetComponent<BulletPower>().getPower;
        Destroy(collider.gameObject);
        var hit_effect = Instantiate(hit_effect_prefab);
        hit_effect.transform.SetParent(gameObject.transform);
        hit_effect.transform.position = collider.gameObject.transform.position;
        NetworkServer.Spawn(hit_effect);

        if (hp < 0)
        {
            hp = 0;
        }

        if (gameObject.tag != "Player") return;

        sound_manager_.PlaySE(12);

        //if (hp_ > 0) return;
        //var destory_effect = Instantiate(destory_effect_prefab_);
        //destory_effect.transform.SetParent(gameObject.transform);
        //destory_effect.transform.position = gameObject.transform.position;
        //is_active_ = false;
        //FindObjectOfType<SoundManager>().PlaySE(0);
    }
}
