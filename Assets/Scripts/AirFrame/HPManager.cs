using UnityEngine;
using UnityEngine.Networking;

public class HPManager : NetworkBehaviour
{
    bool is_active_ = true;

    [SerializeField]
    int layer_num_ = 3;

    [SyncVar]
    float hp_ = 100;

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
        if (hp_ <= 0) is_active_ = false;
    }
}
