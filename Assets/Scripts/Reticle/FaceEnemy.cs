using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class FaceEnemy : MonoBehaviour {

   // [SerializeField]
    GameObject[] enemys_;
    GameObject lock_enemy_;
    GameObject start_lock_enemy_;

    int enemy_number;

    TargetCircle target_circle_;

    //List<GameObject[]> enemys_;

	void Start ()
    {
        //enemys_ = new List<GameObject[]>();

        enemy_number = 0;
        target_circle_ = FindObjectOfType<TargetCircle>();
        start_lock_enemy_ = target_circle_.GetEnemyObject;
        lock_enemy_ = start_lock_enemy_;
    }
	
	void Update ()
    {
                target_circle_ = FindObjectOfType<TargetCircle>();
                lock_enemy_ = target_circle_.GetEnemyObject;
        //        Debug.Log((gameObject.transform.position - enemy_.transform.position).magnitude);

        ChangeLockEnemy();
        //lock_enemy_ = enemys_[enemy_number];

        gameObject.transform.LookAt(lock_enemy_.transform);
	}

    void ChangeLockEnemy()
    {
        //enemys_.Add(GameObject.FindGameObjectsWithTag("Enemy"));

      //  Debug.Log(enemys_[0].name);
    }
}
