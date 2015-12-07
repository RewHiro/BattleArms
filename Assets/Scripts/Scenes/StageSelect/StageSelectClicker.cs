using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class StageSelectClicker : MonoBehaviour
{
    List<string> stage_name_list_ = new List<string>();

    void Start()
    {
        stage_name_list_.Add("stage01");
        stage_name_list_.Add("stage02");
        stage_name_list_.Add("stage03");
    }

    public void Ready(int num)
    {
        FindObjectOfType<MyNetworkLobbyManager>().playScene = stage_name_list_[num];
        FindObjectOfType<SoundManager>().PlaySE(4);
        FindObjectOfType<StageData>().stageNum = num;
        var network_lobby_player = FindObjectOfType<NetworkLobbyPlayer>();
        network_lobby_player.SendReadyToBeginMessage();
    }
}
