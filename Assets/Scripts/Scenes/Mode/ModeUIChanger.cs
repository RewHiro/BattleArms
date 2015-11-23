using UnityEngine;
using UnityEngine.Networking;

public class ModeUIChanger : MonoBehaviour
{
    bool is_online_ = false;

    [SerializeField]
    GameObject online_ui_ = null;

    [SerializeField]
    GameObject offline_ui_ = null;

    public void ChangeOnlineUI()
    {
        online_ui_.SetActive(true);
        offline_ui_.SetActive(false);
    }

    public void ChangeOfflineUI()
    {
        online_ui_.SetActive(false);
        offline_ui_.SetActive(true);
        var active_object = FindObjectOfType<MyNetworkLobbyManager>().gameObject;
        Destroy(active_object);
    }
}
