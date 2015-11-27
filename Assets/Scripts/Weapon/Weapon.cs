using UnityEngine;
using UnityEngine.Networking;

public class Weapon : NetworkBehaviour
{
    BulletCreater bullet_creater_ = null;

    public WeaponType getType
    {
        get
        {
            return weapon_type_;
        }
    }

    public void SetType(WeaponType weapon_type)
    {
        weapon_type_ = weapon_type;
    }

    virtual public void OnAttack() { }
    virtual public void OnNotAttack() { }
    virtual public bool CanShot() { return false; }
    virtual public GameObject CreateBullet() { return new GameObject(); }

    protected int id_ = 0;
    protected string name_ = "";
    protected string explanatory_text_ = "";
    WeaponType weapon_type_ = WeaponType.LEFT;
}