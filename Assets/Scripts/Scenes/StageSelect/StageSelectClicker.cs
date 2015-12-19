using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

public class StageSelectClicker : MonoBehaviour
{
    List<string> stage_name_list_ = new List<string>();

    bool is_click_ = false;

    void Start()
    {
        stage_name_list_.Add("stage01");
        stage_name_list_.Add("stage02");
        stage_name_list_.Add("stage03");
    }

    public void Ready(int num)
    {
        if (is_click_) return;
        is_click_ = true;
        FindObjectOfType<MyNetworkLobbyManager>().playScene = stage_name_list_[num];

        var sound_manager = FindObjectOfType<SoundManager>();
        sound_manager.PlaySE(4);
        sound_manager.StopBGM(0);

        FindObjectOfType<StageData>().stageNum = num;

        FindObjectOfType<MyNetworkLobbyManager>().CheckReadyToBegin();

        FindObjectOfType<MoviePlayer>().Play();

        foreach (var player in FindObjectsOfType<MyNetworkLobbyPlayer>())
        {
            if (!player.isLocalPlayer) continue;
            player.Ready();
        }

    }
}
