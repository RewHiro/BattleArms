using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class EnterRoom : NetworkBehaviour
{

    public bool isEnter
    {
        get
        {
            return is_enter_;
        }
    }

    bool is_enter_ = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        is_enter_ = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Player")) return;
        is_enter_ = true;
    }
}
