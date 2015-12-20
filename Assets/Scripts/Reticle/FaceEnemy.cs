using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FaceEnemy : MonoBehaviour {

    GameObject[] enemy_;
    GameObject[] base_;
    GameObject look_object_;
//    GameObject start_lock_enemy_;
    Vector3 enemy_position;

//    TargetCircle target_circle_;
    
    int enemy_number_;
    int base_number_;
    
    void Awake()
    {
        enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        base_ = GameObject.FindGameObjectsWithTag("Base");
    }

    void Start ()
    {
        // target_circle_ = GetComponent<TargetCircle>();
        base_number_ = 0;
        enemy_number_ = 0;
//        target_circle_ = FindObjectOfType<TargetCircle>();
 //       start_lock_enemy_ = target_circle_.GetEnemyObject;
   //     enemy_position = start_lock_enemy_.transform.position;

    }

    void Update ()
    {
        IsChangeEnemyNumber();
        LookAtEnemy();
        Debug.Log(base_.Length);
    }

    public  void ChangeLockEnemy()
    {
        enemy_number_++;

        if(enemy_number_ >= enemy_.Length)
        {
            base_number_++;
        }

        if(base_number_ >= base_.Length)
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
        if(enemy_number_ >= enemy_.Length)
        {
            look_object_ = base_[base_number_];
        }

        enemy_position = look_object_.transform.position;
        enemy_position.y = gameObject.transform.position.y;

        gameObject.transform.LookAt(enemy_position);

    }
}
