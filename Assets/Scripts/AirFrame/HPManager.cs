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

    void Start()
    {

        var id = GetComponent<Identificationer>().id;
        hp = FindObjectOfType<AirFrameParameter>().GetMaxHP(id);
        MAX_HP = hp;
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        if (hp_text_ == null) return;

        hp_text_.GetComponent<Text>().text = "HP:" + hp_.ToString() + "/" + MAX_HP.ToString();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!isServer) return;
        if (collider.gameObject.layer != layer_num_) return;
        hp -= 10;
        Destroy(collider.gameObject);
        var hit_effect = Instantiate(hit_effect_prefab);
        hit_effect.transform.SetParent(gameObject.transform);
        hit_effect.transform.position = collider.gameObject.transform.position;
        NetworkServer.Spawn(hit_effect);
        if (hp_ > 0) return;
        var destory_effect = Instantiate(destory_effect_prefab_);
        destory_effect.transform.SetParent(gameObject.transform);
        destory_effect.transform.position = gameObject.transform.position;
        is_active_ = false;
        FindObjectOfType<SoundManager>().PlaySE(0);
    }
}
