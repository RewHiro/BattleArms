using UnityEngine;

public class ModeClicker : MonoBehaviour
{

    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(SceneType.CUSTOMIZE);
        var my_network_lobby_manager = FindObjectOfType<MyNetworkLobbyManager>();
        my_network_lobby_manager.maxPlayers = 1;
        my_network_lobby_manager.StartHost();
    }

    public void LobbyStart()
    {
        var my_network_lobby_manager = FindObjectOfType<MyNetworkLobbyManager>();
        my_network_lobby_manager.maxPlayers = 6;
        my_network_lobby_manager.StartLobby();
    }
}
