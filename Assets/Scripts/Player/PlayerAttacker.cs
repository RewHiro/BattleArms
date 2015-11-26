using UnityEngine;
using System;
using UnityEngine.Networking;

public class PlayerAttacker : NetworkBehaviour
{

    [SerializeField]
    GameObject right_weapon_object_ = null;

    [SerializeField]
    GameObject left_weapon_object_ = null;

    void Start()
    {
        if (!isLocalPlayer) return;
        player_controller_ = GetComponent<PlayerController>();
        right_weapon_ = right_weapon_object_.AddComponent<AssaultRifle>();
        left_weapon_ = left_weapon_object_.AddComponent<AssaultRifle>();
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        Debug.Log(gameObject.name);
        AttackWithWeapon(player_controller_.isInputRightAttack, right_weapon_);
        AttackWithWeapon(player_controller_.isInputLeftAttack, left_weapon_);
    }


    void AttackWithWeapon(bool input, Weapon weapon)
    {
        if (weapon == null) throw new Exception();
        if (input)
        {
            weapon.OnAttack();
        }
        else
        {
            weapon.OnNotAttack();
        }
    }


    PlayerController player_controller_ = null;
    Weapon right_weapon_ = null;
    Weapon left_weapon_ = null;
    Weapon back_weapon_ = null;
    Weapon melee_weapon_ = null;

}
