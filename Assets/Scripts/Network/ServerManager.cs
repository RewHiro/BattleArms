using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System.Linq;


// デリゲートで実装した方がみやすいかも

public class ServerManager : NetworkBehaviour
{
    GameObject[] players = null;
    GameObject[] enemys = null;

    float result_count_ = 0.0f;
    float limit_count_ = 60 * 5;

    public bool goResult
    {
        get
        {
            if (limit_count_ <= 0.0f) return true;

            players = GameObject.FindGameObjectsWithTag("Player");
            List<HPManager> player_hp_managers = new List<HPManager>();
            foreach (var player in players)
            {
                player_hp_managers.Add(player.GetComponent<HPManager>());
            }

            if (player_hp_managers.All(player => !player.isActive)) return true;

            List<HPManager> enemy_hp_managers = new List<HPManager>();

            enemys = GameObject.FindGameObjectsWithTag("Enemy");
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
            if (limit_count_ <= 0.0f) return false;

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
        players = GameObject.FindGameObjectsWithTag("Player");
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        Result();

        if (goResult) return;
        limit_count_ -= Time.deltaTime;

        foreach (var player in FindObjectsOfType< Limiter > ())
        {
            player.RpcTellToClient(limit_count_);
        }
    }

    void Result()
    {
        if (!goResult) return;
        if (result_count_ <= 0.0)
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

        result_count_ += Time.deltaTime;

        if (result_count_ <= 5.0f) return;

        FindObjectOfType<MyNetworkLobbyManager>().StopHost();
    }
}
