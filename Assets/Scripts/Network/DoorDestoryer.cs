using UnityEngine;
using UnityEngine.Networking;

public class DoorDestoryer : NetworkBehaviour
{

    [SerializeField]
    GameObject effect_ = null;

    [SerializeField]
    uint num_ = 0;

    ServerStageManager server_stage_manager_ = null;

    public override void OnStartServer()
    {
        base.OnStartServer();
        server_stage_manager_ = FindObjectOfType<ServerStageManager>();
    }

    void Update()
    {
        if (!server_stage_manager_.CanGoRoom(num_)) return;
        for (int i = 0; i < 10; ++i)
        {
            var position = transform.position + Random.insideUnitSphere * Random.Range(-20.0f, 20.0f);
            var effect = Instantiate(effect_, position, Quaternion.identity) as GameObject;
            NetworkServer.Spawn(effect);
        }
        Destroy(gameObject);
    }

}
