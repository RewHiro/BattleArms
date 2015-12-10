using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;


// デリゲートで実装した方がみやすいかも

public class ServerManager : NetworkBehaviour
{
    GameObject[] players = null;
    GameObject[] enemys = null;

    float count_ = 0.0f;

    public bool goResult
    {
        get
        {
            List<HPManager> player_hp_managers = new List<HPManager>();
            foreach (var player in players)
            {
                player_hp_managers.Add(player.GetComponent<HPManager>());
            }

            if (player_hp_managers.All(player => !player.isActive)) return true;

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
            foreach (var player in players)
            {
                var hp_manager = player.GetComponent<HPManager>();
                if (hp_manager.isActive) return true;
            }
            return false;
        }
    }

    void Start()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        Result();
    }

    void Result()
    {
        if (!goResult) return;
        if (count_ <= 0.0)
        {
            if (isWinPlayer)
            {
                //　勝利演出

                foreach (var player in FindObjectsOfType<EndDirector>())
                {
                    player.RpcTellClientStart("Win");
                }
            }
            else
            {
                //　敗北演出
                foreach (var player in FindObjectsOfType<EndDirector>())
                {
                    player.RpcTellClientStart("Lose");
                }
            }
        }

        count_ += Time.deltaTime;

        if (count_ <= 5.0f) return;

        MyNetworkLobbyManager.instance.StopHost();
    }
}
