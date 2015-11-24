using UnityEngine;
using UnityEngine.Networking;

public class StageSelectClicker : MonoBehaviour
{
    public void Ready()
    {
        var network_lobby_player = FindObjectOfType<NetworkLobbyPlayer>();
        network_lobby_player.SendReadyToBeginMessage();
    }
}
