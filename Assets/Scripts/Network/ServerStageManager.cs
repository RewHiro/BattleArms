using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ServerStageManager : NetworkBehaviour
{

    EnemySpawner enemy_spawner_ = null;

    bool[] go_room_ = new bool[3];

    List<GameObject> enemys = new List<GameObject>();

    float result_count_ = 0.0f;
    float limit_count_ = 60 * 5;

    TutorialManager tutorial_manager_ = null;

    public bool IsEndTutorial
    {
        get
        {
            if (tutorial_manager_ == null) return false;
            return !tutorial_manager_.IsStart;
        }
    }

    public bool CanGoRoom(uint num)
    {
        if (num > go_room_.Length) return false;
        return go_room_[num];
    }

    public bool goResult
    {
        get
        {
            if (limit_count_ <= 0.0f) return true;

            var players = GameObject.FindGameObjectsWithTag("Player");
            List<HPManager> player_hp_managers = new List<HPManager>();
            foreach (var player in players)
            {
                player_hp_managers.Add(player.GetComponent<HPManager>());
            }

            if (player_hp_managers.All(player => !player.isActive)) return true;

            List<HPManager> enemy_hp_managers = new List<HPManager>();

            if (enemys.Count <= 15) return false;
            var active_enemys = enemys.GetRange(5, 11);
            foreach (var enemy in active_enemys)
            {
                if (enemy == null) continue;
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

            foreach (var player in FindObjectsOfType<PlayerSetting>())
            {
                var hp_manager = player.GetComponent<HPManager>();
                if (hp_manager.isActive) return true;
            }
            return false;
        }
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        enemy_spawner_ = FindObjectOfType<EnemySpawner>();

        for (int i = 0; i < 1; i++)
        {
            var enemy = enemy_spawner_.CreateEnemy(i);
            enemy.GetComponent<AI2>().SetRoomName("lastStage_clean");
            enemys.Add(enemy);
        }

        StartCoroutine("Room1");
    }

    void FindComponent()
    {
        if (tutorial_manager_ != null) return;
        foreach (var player in FindObjectsOfType<PlayerSetting>())
        {
            if (!player.isLocalPlayer) continue;
            tutorial_manager_ = player.GetComponentInChildren<TutorialManager>();
        }
    }

    void Update()
    {
        var go_result = goResult;
        FindComponent();
        if (tutorial_manager_ == null) return;
        if (!tutorial_manager_.IsStart) return;
        Result(go_result);
        LimitTimeUpdate(go_result);
    }

    void Result(bool go_result)
    {
        if (!go_result) return;

        if (result_count_ <= 0.0)
        {
            if (isWinPlayer)
            {
                //　勝利演出

                foreach (var player in FindObjectsOfType<EndDirector>())
                {
                    player.RpcTellClientStart("Win");                    
                    player.RpcTellClientTime((int)limit_count_);
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

    void LimitTimeUpdate(bool go_result)
    {
        if (go_result) return;
        limit_count_ -= Time.deltaTime;

        foreach (var player in FindObjectsOfType<Limiter>())
        {
            player.RpcTellToClient(limit_count_);
        }
    }

    IEnumerator Room1()
    {
        while (true)
        {
            if (enemys[0].GetComponent<HPManager>().isActive)
            {
                yield return null;
            }
            else
            {
                if (go_room_[0]) yield return null;
                for (int i = 1; i < 3; i++)
                {
                    var enemy = enemy_spawner_.CreateEnemy(i);
                    enemy.GetComponent<AI2>().SetRoomName("room1");
                    enemys.Add(enemy);
                }
                go_room_[0] = true;
                yield return StartCoroutine("Room2");
            }
        }
    }

    IEnumerator Room2()
    {
        while (true)
        {
            var enemys_active = false;

            var count = 0;
            for (int i = 1; i < 3; i++)
            {
                if (enemys[i] != null) break;
                count++;
            }

            if (count == 2) enemys_active = true;

            if (enemys_active)
            {
                if (go_room_[1]) yield return null;

                for (int i = 3; i < 5; i++)
                {
                    var enemy = enemy_spawner_.CreateEnemy(i);
                    enemy.GetComponent<AI2>().SetRoomName("room2");
                    enemys.Add(enemy);
                }
                //enemys.Add(enemy_spawner_.CreateMiddleEnemy01(6));
                var middle_enemy = enemy_spawner_.CreateMiddleEnemy02(5);
                middle_enemy.GetComponent<AI2>().SetRoomName("room2");
                enemys.Add(middle_enemy);
                go_room_[1] = true;
                yield return StartCoroutine("Room3");
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator Room3()
    {
        while (true)
        {
            var enemys_active = false;

            var count = 0;
            for (int i = 3; i < 6; i++)
            {
                if (enemys[i] != null) break;
                count++;
            }

            if (count == 3) enemys_active = true;

            if (enemys_active)
            {
                if (go_room_[2]) yield return null;

                for (int i = 8; i < 15; i++)
                {
                    var enemy = enemy_spawner_.CreateEnemy(i);
                    enemy.GetComponent<AI2>().SetRoomName("room3");
                    enemys.Add(enemy);
                }
                var big_enemy = enemy_spawner_.CreateBigEnemy(15);
                big_enemy.GetComponent<AI4>().SetRoomName("room3");
                enemys.Add(big_enemy);
                go_room_[2] = true;
                StopCoroutine("Room3");
            }

            yield return null;
        }
    }
}
