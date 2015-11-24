using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour
{
    [SerializeField]
    GameObject enmey_prefab = null;

    [SerializeField]
    GameObject[] enemy_spawn_point_ = null;

    public override void OnStartServer()
    {
        base.OnStartServer();
        CreateEnemy(0);
        CreateEnemy(1);
    }

    void CreateEnemy(int spawn_num)
    {
        var enemy = Instantiate(
            enmey_prefab,
            enemy_spawn_point_[spawn_num].transform.position,
            enemy_spawn_point_[spawn_num].transform.rotation) as GameObject;

        NetworkServer.Spawn(enemy);
    }
}
