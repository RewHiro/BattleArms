using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject enmey_prefab = null;

    [SerializeField]
    GameObject[] enemy_spawn_point_ = null;

    bool is_create_ = false;

    public override void OnStartServer()
    {
        base.OnStartServer();
        CreateEnemy(0);

        if (MyNetworkLobbyManager.instance.numPlayers != 2) return;
        CreateEnemy(1);

    }

    void CreateEnemy(int spawn_num)
    {
        var enemy = Instantiate(
            enmey_prefab,
            enemy_spawn_point_[spawn_num].transform.position,
            enemy_spawn_point_[spawn_num].transform.rotation) as GameObject;
        enemy.name = "Enemy" + spawn_num.ToString();
        NetworkServer.Spawn(enemy);
    }

    void Update()
    {
        //if (is_create_) return;
        //foreach (var player in FindObjectsOfType<StartDirector>())
        //{
        //    if (!player.isStart) return;
        //}

        //is_create_ = true;

        //CreateEnemy(0);

        //if (MyNetworkLobbyManager.instance.numPlayers != 2) return;
        //CreateEnemy(1);
    }
}
