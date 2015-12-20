using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class FaceEnemy : NetworkBehaviour
{

    GameObject lock_enemy_;
    GameObject start_lock_enemy_;

    int enemy_number;

    TargetCircle target_circle_;


    public override void OnStartLocalPlayer()
    {
        enemy_number = 0;
        target_circle_ = GetComponentInChildren<TargetCircle>();

        //start_lock_enemy_ = target_circle_.GetEnemyObject;
        //lock_enemy_ = start_lock_enemy_;

        base.OnStartLocalPlayer();
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        target_circle_ = GetComponentInChildren<TargetCircle>();

        lock_enemy_ = target_circle_.GetEnemyObject;

        if (lock_enemy_ == null) return;

        //transform.Rotate(0, 12, 0);

        transform.LookAt(lock_enemy_.transform);
    }
}
