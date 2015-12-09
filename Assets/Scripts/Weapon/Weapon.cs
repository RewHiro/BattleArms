using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    GameObject reticle_ = null;

    public WeaponType getType
    {
        get
        {
            return weapon_type_;
        }
    }

    public GameObject Reticle
    {
        get
        {
            return reticle_;
        }
    }

    public GameObject WeaponObject
    {
        get
        {
            return weapon_object_;
        }
    }

    public void SetType(WeaponType weapon_type)
    {
        weapon_type_ = weapon_type;
    }

    public void SetReticle(GameObject reticle)
    {
        reticle_ = reticle;
    }

    public void SetWeaponObject(GameObject weapon_object)
    {
        weapon_object_ = weapon_object;
    }

    public void SetLayer(int layer)
    {
        layer_ = layer;
    }

    virtual public void OnAttack() { }
    virtual public void OnNotAttack() { }
    virtual public bool CanShot() { return false; }
    virtual public IEnumerable<GameObject> CreateBullet() { return null; }

    protected int layer_ = 0;
    protected int id_ = 0;
    protected string name_ = "";
    protected string explanatory_text_ = "";
    WeaponType weapon_type_ = WeaponType.LEFT;
    GameObject weapon_object_ = null;
}