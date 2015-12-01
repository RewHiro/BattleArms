using UnityEngine;
using System;
using UnityEngine.Networking;


// ネットワーク専用のイベント登録があるからそれでやった方がよいかも
public class PlayerAttacker : NetworkBehaviour
{

    [SerializeField]
    GameObject right_weapon_object_ = null;

    [SerializeField]
    GameObject left_weapon_object_ = null;

    [SerializeField]
    GameObject back_weapon_object_ = null;

    public override void PreStartClient()
    {
        base.PreStartClient();
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
    }

    void Start()
    {
        player_controller_ = GetComponent<PlayerController>();

        back_weapon_ = back_weapon_object_.AddComponent<HomingGun>();
        back_weapon_.SetType(WeaponType.BACK);
    }

    void Update()
    {
        if (right_weapon_ == null)
        {
            right_weapon_ = right_weapon_object_.GetComponentInChildren<Weapon>();
            right_weapon_.SetType(WeaponType.RIGHT);
        }

        if (left_weapon_ == null)
        {
            left_weapon_ = left_weapon_object_.GetComponentInChildren<Weapon>();
            left_weapon_.SetType(WeaponType.LEFT);
        }
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        AttackWithWeapon(player_controller_.isInputRightAttack, right_weapon_);
        AttackWithWeapon(player_controller_.isInputLeftAttack, left_weapon_);
        AttackWithWeapon(player_controller_.isInputBothHandAttack, back_weapon_);
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
                    case WeaponType.BACK:
                        CmdCreateBackBullet();
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

    [Command]
    void CmdCreateBackBullet()
    {
        var itr = back_weapon_.CreateBullet().GetEnumerator();
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
