using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class FaceEnemy : NetworkBehaviour
{

    GameObject[] enemy_;
    GameObject[] base_;
    GameObject look_object_;
    Vector3 enemy_position;

    int enemy_number_;
    int base_number_;

    public override void OnStartLocalPlayer()
    {

        enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        base_ = GameObject.FindGameObjectsWithTag("Base");

        base.OnStartLocalPlayer();
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        IsChangeEnemyNumber();
        LookAtEnemy();
    }

    public void ChangeLockEnemy()
    {
        enemy_number_++;

        if (enemy_number_ >= enemy_.Length)
        {
            base_number_++;
        }

        if (base_number_ >= base_.Length)
        {
            base_number_ = -1;
            enemy_number_ = 0;

        }

    }


    public void IsChangeEnemyNumber()
    {
        if (!(enemy_.Length == GameObject.FindGameObjectsWithTag("Enemy").Length))
        {
            enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        }

        if (!(base_.Length == GameObject.FindGameObjectsWithTag("Base").Length))
        {
            base_ = GameObject.FindGameObjectsWithTag("Base");
        }

    }

    public void LookAtEnemy()
    {
        if (enemy_number_ < enemy_.Length)
        {
            look_object_ = enemy_[enemy_number_];
        }
        else
        if (enemy_number_ >= enemy_.Length)
        {
            look_object_ = base_[base_number_];
        }

        enemy_position = look_object_.transform.position;
        enemy_position.y = gameObject.transform.position.y;

        gameObject.transform.LookAt(enemy_position);

    }


}
