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
        AttackWithWeapon(player_controller_.isInputRightAttack, right_weapon_);
        AttackWithWeapon(player_controller_.isInputLeftAttack, left_weapon_);
    }


    void AttackWithWeapon(bool input, Weapon weapon)
    {
        if (weapon == null) throw new Exception();
        if (input)
        {
            //weapon.OnAttack();
            CmdCreate();
        }
        else
        {
            weapon.OnNotAttack();
        }
    }


    //　true falseで返す(Weapon)
    //　引数でパラメータ調整
    [Command]
    public virtual void CmdCreate()
    {
        Debug.Log("OK");
        
        var obj = Instantiate(FindObjectOfType<BulletCreater>().getAssaulutBullet);
        obj.transform.position = gameObject.transform.position;
        obj.transform.Translate(gameObject.transform.forward * 2.5f);
        obj.transform.rotation = gameObject.transform.rotation;
        Vector3 force;
        force = gameObject.transform.forward * 100;
        obj.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        NetworkServer.Spawn(obj);
    }


    PlayerController player_controller_ = null;
    Weapon right_weapon_ = null;
    Weapon left_weapon_ = null;
    Weapon back_weapon_ = null;
    Weapon melee_weapon_ = null;

}
