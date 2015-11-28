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
        player_controller_ = GetComponent<PlayerController>();
        right_weapon_ = right_weapon_object_.AddComponent<ShotGun>();
        right_weapon_.SetType(WeaponType.RIGHT);

        left_weapon_ = left_weapon_object_.AddComponent<AssaultRifle>();
        left_weapon_.SetType(WeaponType.LEFT);
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        AttackWithWeapon(player_controller_.isInputRightAttack, right_weapon_);
        AttackWithWeapon(player_controller_.isInputLeftAttack, left_weapon_);
    }

    void AttackWithWeapon(bool input, Weapon weapon)
    {
        if (weapon == null) throw new Exception();

        if (input)
        {
            weapon.OnAttack();
            if (weapon.CanShot())
            {
                switch (weapon.getType)
                {
                    case WeaponType.LEFT:
                        CmdCreateLeftBullet();
                        break;
                    case WeaponType.RIGHT:
                        CmdCreateRightBullet();
                        break;
                }
            }
        }
        else
        {
            weapon.OnNotAttack();
        }
    }

    [Command]
    void CmdCreateRightBullet()
    {
        var itr = right_weapon_.CreateBullet().GetEnumerator();
        while (itr.MoveNext())
        {
            NetworkServer.Spawn(itr.Current);
        }
    }

    [Command]
    void CmdCreateLeftBullet()
    {
        var itr = left_weapon_.CreateBullet().GetEnumerator();
        while (itr.MoveNext())
        {
            NetworkServer.Spawn(itr.Current);
        }
    }

    PlayerController player_controller_ = null;
    Weapon right_weapon_ = null;
    Weapon left_weapon_ = null;
    Weapon back_weapon_ = null;
    Weapon melee_weapon_ = null;

}
