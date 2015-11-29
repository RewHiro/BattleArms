using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;


// デリゲートで実装した方がみやすいかも

public class ServerManager : NetworkBehaviour
{

    GameObject local_player_ = null;
    GameObject remote_player_ = null;

    GameObject[] enemys = null;

    public bool goResult
    {
        get
        {
            if (local_player_ == null) return false;
            if (remote_player_ == null) return false;

            if (!(local_player_.GetComponent<HPManager>().isActive &&
                remote_player_.GetComponent<HPManager>().isActive)) return true;
            List<HPManager> enemy_hp_managers = new List<HPManager>();

            foreach (var enemy in enemys)
            {
                enemy_hp_managers.Add(enemy.GetComponent<HPManager>());
            }

            if (enemy_hp_managers.All(enemy => !enemy.isActive)) return true;
            return false;
        }
    }

    public bool isWinPlayer
    {
        get
        {
            if (local_player_.GetComponent<HPManager>().isActive &&
                remote_player_.GetComponent<HPManager>().isActive) return true;
            return false;
        }
    }

    void Start()
    {
        FindPlayers();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        FindPlayers();

        Result();
    }

    void FindPlayers()
    {
        if (remote_player_ != null) return;
        var players = FindObjectsOfType<PlayerController>();
        foreach (var player in players)
        {
            if (player.isLocalPlayer)
            {
                local_player_ = player.gameObject;
            }
            else
            {
                remote_player_ = player.gameObject;
            }
        }
    }

    void Result()
    {
        if (!goResult) return;
        if (isWinPlayer)
        {
            //　勝利演出
        }
        else
        {
            //　敗北演出
        }
        MyNetworkLobbyManager.instance.StopHost();
    }
}
