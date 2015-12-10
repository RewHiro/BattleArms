using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine;

public class EndDirector : NetworkBehaviour
{

    Text text_ = null;

    [SerializeField]
    GameObject text_object_ = null;

    [ClientRpc]
    public void RpcTellClientStart(string str)
    {
        text_.text = str;
        text_object_.SetActive(true);
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        text_ = text_object_.GetComponent<Text>();
    }

}
