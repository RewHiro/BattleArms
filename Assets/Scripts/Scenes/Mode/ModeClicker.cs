using UnityEngine;

public class ModeClicker : MonoBehaviour
{
    [SerializeField]
    GameObject my_network_manager_ = null;

    public GameObject getMyNetworkManagerPrefab
    {
        get
        {
            if (my_network_manager_ != null) return my_network_manager_;
            var prefab = Resources.Load<GameObject>("Network/MyNetworkLobbyManager");
            my_network_manager_ = prefab;
            return my_network_manager_;
        }
    }

    void Start()
    {
        var prefab = Instantiate<GameObject>(my_network_manager_);
        prefab.name = my_network_manager_.name;
    }

    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(SceneType.CUSTOMIZE);
        var my_network_lobby_manager = FindObjectOfType<MyNetworkLobbyManager>();
        my_network_lobby_manager.maxPlayers = 1;
        my_network_lobby_manager.StartHost();
    }

    public void LobbyStart()
    {
        FindObjectOfType<MyNetworkLobbyManager>().StartLobby();
    }
}
