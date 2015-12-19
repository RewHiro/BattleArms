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

        var sound_manager = FindObjectOfType<SoundManager>();
        sound_manager.PlaySE(4);
        sound_manager.StopBGM(0);

        FindObjectOfType<StageData>().stageNum = num;

        FindObjectOfType<MyNetworkLobbyManager>().CheckReadyToBegin();

        foreach (var player in FindObjectsOfType<MyNetworkLobbyPlayer>())
        {
            if (!player.isLocalPlayer) continue;
            player.SendReadyToBeginMessage();
        }

    }
}
