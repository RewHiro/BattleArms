using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{

    bool lock_on_site_enemy_hit_;

    [SerializeField]
    GameObject target_circle_prefab_;

    TargetCircle target_circle_;

    public bool Lock_On_Site_Enemy_Hit
    {
        get
        {
            return lock_on_site_enemy_hit_;
        }
    }

    void Start()
    {
        target_circle_ = FindObjectOfType<TargetCircle>();
        //target_circle_ = GameObject.Find(target_circle_prefab_.name).GetComponent<TargetCircle>();
    }

    void OnTriggerStay2D(Collider2D collision2D_stay)
    {
        var enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy_.Length == 0) return;
        if (collision2D_stay.gameObject.transform.parent.name == enemy_[target_circle_.NearEnemySelect()].name)
        {
            //Debug.Log("ok");
            lock_on_site_enemy_hit_ = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision2D_exit)
    {
        var enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy_.Length == 0) return;
        if (collision2D_exit.gameObject.transform.parent.name == enemy_[target_circle_.NearEnemySelect()].name)
        {
            //Debug.Log("exit");
            lock_on_site_enemy_hit_ = false;
        }
    }

}

