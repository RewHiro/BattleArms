using UnityEngine;
using UnityEngine.Networking;

public class DoorDestoryer : NetworkBehaviour
{

    [SerializeField]
    GameObject effect_ = null;

    [SerializeField]
    uint num_ = 0;

    ServerStageManager server_stage_manager_ = null;

    bool is_guard_ = false;

    public override void OnStartServer()
    {
        base.OnStartServer();
        server_stage_manager_ = FindObjectOfType<ServerStageManager>();
    }

    void Update()
    {
        if (!isServer) return;
        if (is_guard_) return;
        if (!server_stage_manager_.CanGoRoom(num_)) return;
        is_guard_ = true;
        var child_position = transform.GetChild(0).position;
        for (int i = 0; i < 10; ++i)
        {
            var position = child_position + Random.insideUnitSphere * Random.Range(-50.0f, 50.0f);
            var effect = Instantiate(effect_) as GameObject;
            effect.transform.position = position;
            NetworkServer.Spawn(effect);
        }
        FindObjectOfType<SoundManager>().PlaySE(0);
        Destroy(gameObject);
    }

}
