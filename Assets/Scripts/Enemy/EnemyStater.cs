using UnityEngine;
using System.Collections.Generic;

public class EnemyStater : MonoBehaviour
{

    delegate void StateUpdate();

    Dictionary<EnemyState, StateUpdate> state_update_list_ = new Dictionary<EnemyState, StateUpdate>();
    Vector3 hit_position_ = Vector3.zero;
    Quaternion hit_rotate_ = Quaternion.identity;
    EnemyState enemy_state_ = EnemyState.NORMAL;
    float stop_count_ = 0;
    float time_ = 0.0f;
    int attacked_count_ = 0;
    int PLAYER_HASH = 0;

    public bool isNormal
    {
        get
        {
            return enemy_state_ == EnemyState.NORMAL;
        }
    }

    public bool isMeleed
    {
        get
        {
            return enemy_state_ == EnemyState.MELEED;
        }
    }

    public bool isStop
    {
        get
        {
            return enemy_state_ == EnemyState.STOP;
        }
    }

    public EnemyState getEnemyState
    {
        get
        {
            return enemy_state_;
        }
    }

    public void SendAttacked()
    {
        attacked_count_++;
    }

    public void SendHitPlayer(Transform transform)
    {
        enemy_state_ = EnemyState.MELEED;
        hit_position_ = transform.position;
        hit_rotate_ = transform.rotation;
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    void Start()
    {
        PLAYER_HASH = "Player".GetHashCode();

        state_update_list_.Add(EnemyState.MELEED, MeleeUpdate);
        state_update_list_.Add(EnemyState.STOP, StopUpdate);
        state_update_list_.Add(EnemyState.NORMAL, NormalUpdate);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (PLAYER_HASH != collider.gameObject.tag.GetHashCode()) return;
    }


    void Update()
    {
        state_update_list_[enemy_state_]();
    }

    void MeleeUpdate()
    {
        time_ += Time.deltaTime;

        transform.position.Set(hit_position_.x, transform.position.y, hit_position_.z);
        transform.rotation = hit_rotate_;

        if (time_ >= 4.0f)
        {
            enemy_state_ = EnemyState.NORMAL;
            attacked_count_ = 0;
            time_ = 0.0f;
        }

        if (attacked_count_ < 3) return;
        enemy_state_ = EnemyState.STOP;
        attacked_count_ = 0;
    }

    void StopUpdate()
    {
        stop_count_ += Time.deltaTime;
        if (stop_count_ < 10.0f) return;
        stop_count_ = 0.0f;
        enemy_state_ = EnemyState.NORMAL;
    }

    void NormalUpdate()
    {

    }
}
