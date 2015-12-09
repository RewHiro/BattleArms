using UnityEngine;
using UnityEngine.Networking;

public class HPManager : NetworkBehaviour
{
    bool is_active_ = true;

    [SerializeField]
    int layer_num_ = 3;

    [SyncVar]
    float hp_ = 100;

    [SerializeField]
    GameObject hit_effect_prefab = null;

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
        if (hp_ <= 0) is_active_ = false;
    }
}
