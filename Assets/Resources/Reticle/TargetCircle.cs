using UnityEngine;
using System.Collections;


public class TargetCircle : MonoBehaviour
{

    GameObject[] enemy_;


    Vector3[] enemy_camera_position_;

    int near_enemy_number;

    float near_enemy_distance_;

    float enemy_distance_;

    bool is_hit_enemy_ = false;

    public bool Is_Hit_Enemy_ { get { return is_hit_enemy_; } }

    [SerializeField]
    Camera reticle_camera_ = null;



    void Start()
    {
        enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void Update()
    {
        NearEnemySelect();
    //    Debug.Log(Is_Hit_Enemy_);
    }

    public GameObject GetEnemyObject
    {
        get
        {
            if (enemy_.Length == 0) return null;
            return enemy_[NearEnemySelect()];
        }
    }

  public  int  NearEnemySelect()
    {
        enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        enemy_camera_position_ = new Vector3[enemy_.Length];

        near_enemy_distance_ = enemy_distance_;


        for (int i = 0; i < enemy_.Length; ++i)
        {
            enemy_camera_position_[i] = reticle_camera_.WorldToScreenPoint(enemy_[i].transform.position);

            enemy_distance_ = (reticle_camera_.transform.position - enemy_[i].transform.position).magnitude;


            if (near_enemy_distance_ < enemy_distance_)
            {
                near_enemy_distance_ = enemy_distance_;
                near_enemy_number = i;
            }

        }

        return near_enemy_number;
    }

    void OnTriggerStay2D(Collider2D collision2D_stay)
    {
        if(collision2D_stay.gameObject.transform.parent.name == enemy_[NearEnemySelect()].name)
        {
            Debug.Log("ok");
            is_hit_enemy_ = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision2D_exit)
    {
        if (collision2D_exit.gameObject.transform.parent.name == enemy_[NearEnemySelect()].name)
        {
            Debug.Log("exit");
            is_hit_enemy_ = false;
        }
    }


}
