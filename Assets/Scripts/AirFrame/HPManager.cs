using UnityEngine;
using UnityEngine.Networking;

public class HPManager : NetworkBehaviour
{
    [SerializeField]
    int layer_num_ = 3;

    [SyncVar]
    float hp_ = 100;

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
        if (!isLocalPlayer) return;
        var id = GetComponent<Identificationer>().id;
        hp = FindObjectOfType<AirFrameParameter>().GetMaxHP(id);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isServer) return;
        if (collision.gameObject.layer != layer_num_) return;
        hp -= 10;
        Destroy(collision.gameObject);
    }
}
