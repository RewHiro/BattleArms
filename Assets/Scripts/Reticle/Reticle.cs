using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reticle : MonoBehaviour {

    Vector2 center_position_;

    [SerializeField]
    float circle_size_ = 50;


    GameObject[] enemy_;


    Vector3[] enemy_camera_position_;

    int near_enemy_number;

    float near_enemy_distance_;

    float enemy_distance_;


    [SerializeField]
    Camera reticle_camera_ = null;

    [SerializeField]
    Image lock_on_site_panel_ = null;

    GameObject lock_on_site_canvas_ = null;



    void Start ()
    {
        //いい案が思いつかなかった
        lock_on_site_canvas_ = GameObject.Find(lock_on_site_panel_.transform.parent.name);
        lock_on_site_panel_.rectTransform.localScale = new Vector3(circle_size_ * 2, circle_size_* 2, 0);
        lock_on_site_panel_ = Instantiate(lock_on_site_panel_);
        lock_on_site_panel_.transform.SetParent(lock_on_site_canvas_.transform);
        lock_on_site_panel_.rectTransform.localPosition = new Vector3(0, 0, 0);


        center_position_ = new Vector2(Screen.width / 2, Screen.height / 2);
        enemy_ =  GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	void Update ()
    {
        //Debug.Log(center_position_);
        center_position_ = new Vector2(Screen.width / 2, Screen.height / 2);
        NearEnemyPosition();
        LockOnSite();
    }


    public Vector3 NearEnemyPosition()
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

        return enemy_camera_position_[near_enemy_number];

    }

     bool LockOnSite()
    {


        Vector2 distance_to_circle = new Vector2(NearEnemyPosition().x - center_position_.x, NearEnemyPosition().y - center_position_.y);


        if (distance_to_circle.x * distance_to_circle.x +
            distance_to_circle.y * distance_to_circle.y <= circle_size_ * circle_size_ )
        {
            Debug.Log("LockOnSiteIn");
            return true;
        }
        else
        {
            Debug.Log("LockOnSiteOut");
            return false;
        }

    }

}
