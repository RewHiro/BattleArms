using UnityEngine;
using UnityEngine.Networking;

public class BoostManager : NetworkBehaviour
{
    public float boostValue { private set; get; }

    void Start()
    {
        if (!isLocalPlayer) return;
        var id = GetComponent<Identificationer>().id;
        boostValue = FindObjectOfType<AirFrameParameter>().GetMaxBoostValue(id);
    }
}
