using UnityEngine;
using UnityEngine.Networking;

public class StageSelectClicker : MonoBehaviour
{
    public void Ready(int num)
    {
        FindObjectOfType<StageData>().stageNum = num;
        var network_lobby_player = FindObjectOfType<NetworkLobbyPlayer>();
        network_lobby_player.SendReadyToBeginMessage();
    }
}
