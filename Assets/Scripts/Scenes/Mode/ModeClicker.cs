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

    public void CreateMyNetworkManager()
    {
        var prefab = Instantiate<GameObject>(my_network_manager_);
        prefab.name = my_network_manager_.name;
    }
}
