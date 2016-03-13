using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomizeClicker : MonoBehaviour
{
    List<string> stage_name_list_ = new List<string>();

    bool is_click_ = false;

    [SerializeField]
    GameObject right_weapon_bezier_manager_ = null;

    void Start()
    {
        stage_name_list_.Add("stage01");
        stage_name_list_.Add("stage02");
        stage_name_list_.Add("stage03");
        stage_name_list_.Add("stage04");

        if (right_weapon_bezier_manager_ == null) return;
        StartCoroutine(Bezeir());
    }

    IEnumerator Bezeir()
    {
        yield return new WaitForSeconds(0.1f);

        right_weapon_bezier_manager_.GetComponent<BezierMover>().BezeirStart();
    }

    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(SceneType.STAGESELECT);
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

        FindObjectOfType<SoundManager>().PlaySE(15);

        //FindObjectOfType<MyNetworkDiscovery>().StopBroadcast();

        foreach (var player in FindObjectsOfType<MyNetworkLobbyPlayer>())
        {
            if (!player.isLocalPlayer) continue;
            player.Ready();
        }

    }
}
