using UnityEngine;
using System.Collections;
using System;

public class PlayerAttacker : MonoBehaviour
{
    void Start()
    {
        //player_controller_ = GetComponent<PlayerController>();
        //var weapon_attacher = GetComponent<WeaponAttacher>();
        //right_weapon_ = weapon_attacher.getRightWeapon;
        //left_weapon_ = weapon_attacher.getLeftWeapon;
    }

    void FixedUpdate()
    {
        //AttackWithWeapon(player_controller_.isInputRightAttack, right_weapon_);
        //AttackWithWeapon(player_controller_.isInputLeftAttack, left_weapon_);
    }

    //void AttackWithWeapon(bool input,Weapon weapon)
    //{
    //    if (weapon == null) throw new Exception();
    //    if (input)
    //    {
    //        weapon.OnAttack();
    //    }
    //    else
    //    {
    //        weapon.OnNotAttack();
    //    }
    //}


    PlayerController player_controller_ = null;
    //Weapon right_weapon_ = null;
    //Weapon left_weapon_ = null;
    //Weapon back_weapon_ = null;
    //Weapon melee_weapon_ = null;

}
