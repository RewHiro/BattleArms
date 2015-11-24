using UnityEngine;
using UnityEngine.Networking;

public class HPManager : NetworkBehaviour
{
    public float hp { private set; get; }

    void Start()
    {
        if (!isLocalPlayer) return;
        var id = GetComponent<Identificationer>().id;
        hp = FindObjectOfType<AirFrameParameter>().GetMaxHP(id);
    }

    void OnCollisionEnter(Collision collision)
    {
        //　ダメージ処理
    }
}
