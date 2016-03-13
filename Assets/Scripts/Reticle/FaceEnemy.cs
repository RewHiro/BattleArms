using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class FaceEnemy : NetworkBehaviour
{

    GameObject[] enemy_;

    PlayerController player_controller_ = null;
    PlayerModer player_moder_ = null;

    float cool_down_count_ = 0.0f;

    int enemy_number_;

    bool is_change_target_ = false;

    SoundManager sound_manager_ = null;

    public override void OnStartLocalPlayer()
    {

        enemy_ = GameObject.FindGameObjectsWithTag("Enemy");
        player_controller_ = GetComponent<PlayerController>();
        player_moder_ = GetComponent<PlayerModer>();

        sound_manager_ = FindObjectOfType<SoundManager>();

        base.OnStartLocalPlayer();
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        IsChangeEnemyNumber();
        LookAtEnemy();
        ChangeLockEnemy();
        ChangeTargetCoolDown();
    }

    void ChangeTargetCoolDown()
    {
        if (!is_change_target_) return;
        cool_down_count_ += Time.deltaTime;

        if (cool_down_count_ <= 2.0f) return;
        cool_down_count_ = 0.0f;
        is_change_target_ = false;
    }

    public void ChangeLockEnemy()
    {
        if (player_moder_.isMeleeMode) return;
        if (!player_controller_.isChangeTarget) return;
        if (cool_down_count_ != 0.0f) return;
        sound_manager_.PlaySE(1);
        is_change_target_ = true;
        enemy_number_++;

        if (enemy_number_ >= enemy_.Length)
        {
            enemy_number_ = 0;
        }
    }


    public void IsChangeEnemyNumber()
    {
        if (enemy_.Length != GameObject.FindGameObjectsWithTag("Enemy").Length)
        {
            var enemys = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemys == null) return;
            enemy_ = enemys;

            if (enemy_number_ >= enemy_.Length)
            {
                enemy_number_ = 0;
            }
        }
    }

    public void LookAtEnemy()
    {
        GameObject look_object_ = null;

        if (enemy_.Length == 0) return;

        look_object_ = enemy_[enemy_number_];

        if (look_object_ == null) return;

        var enemy_position = look_object_.transform.position;
        enemy_position.y = gameObject.transform.position.y;

        gameObject.transform.LookAt(enemy_position);

    }


}
