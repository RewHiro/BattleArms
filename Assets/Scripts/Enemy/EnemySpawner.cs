using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject enmey_prefab = null;

    [SerializeField]
    GameObject[] middle_enemy_prefabs = null;

    [SerializeField]
    GameObject[] enemy_spawn_point_ = null;

    [SerializeField]
    GameObject big_enemy_prefab_ = null;

    bool is_create_ = false;

    public override void OnStartServer()
    {
        base.OnStartServer();

        //CreateEnemy(0);
        //CreateEnemy(1);

        //for (int i = 0; i < 1; i++)
        //{
        //    var spawn_num = i;
        //    var enemy = Instantiate(
        //    enmey_prefab,
        //    enemy_spawn_point_[spawn_num].transform.position,
        //    enemy_spawn_point_[spawn_num].transform.rotation) as GameObject;
        //    enemy.name = "Enemy" + i.ToString();
        //    NetworkServer.Spawn(enemy);
        //}

        //if (FindObjectOfType<MyNetworkLobbyManager>().numPlayers <= 2) return;

    }

    public GameObject CreateEnemy(int spawn_num)
    {
        var enemy = Instantiate(
            enmey_prefab,
            enemy_spawn_point_[spawn_num].transform.position,
            enemy_spawn_point_[spawn_num].transform.rotation) as GameObject;
        enemy.name = "Enemy" + spawn_num.ToString();
        NetworkServer.Spawn(enemy);
        return enemy;
    }

    public GameObject CreateMiddleEnemy01(int spawn_num)
    {
        var enemy = Instantiate(
            middle_enemy_prefabs[0],
            enemy_spawn_point_[spawn_num].transform.position,
            enemy_spawn_point_[spawn_num].transform.rotation) as GameObject;
        enemy.name = "Enemy" + spawn_num.ToString();
        NetworkServer.Spawn(enemy);
        return enemy;
    }

    public GameObject CreateMiddleEnemy02(int spawn_num)
    {
        var enemy = Instantiate(
            middle_enemy_prefabs[1],
            enemy_spawn_point_[spawn_num].transform.position,
            enemy_spawn_point_[spawn_num].transform.rotation) as GameObject;
        enemy.name = "Enemy" + spawn_num.ToString();
        NetworkServer.Spawn(enemy);
        return enemy;
    }
    public GameObject CreateBigEnemy(int spawn_num)
    {
        var enemy = Instantiate(
            big_enemy_prefab_,
            enemy_spawn_point_[spawn_num].transform.position,
            enemy_spawn_point_[spawn_num].transform.rotation) as GameObject;
        enemy.name = "Enemy" + spawn_num.ToString();
        NetworkServer.Spawn(enemy);
        return enemy;
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
