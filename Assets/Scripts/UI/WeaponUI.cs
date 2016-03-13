using UnityEngine;
using System.Collections;

public enum ArmWeapon
{
    AssaultRifle,
    ShotGun,
    GatlingGun
}

public class WeaponUI : MonoBehaviour {

    private bool is_assaultrifle_ = false;
    private bool is_shotgun_ = false;
    private bool is_gatlinggun_ = false;
    private Animator _animator;
    private int _assaultrifleHash = Animator.StringToHash("Is_AssaultRifle");
    private int _shotgunHash = Animator.StringToHash("Is_ShotGun");
    private int _gatlinggunHash = Animator.StringToHash("Is_GatlingGun");

    public ArmWeapon getArmWeapon
    {
        get
        {
            return arm_weapon_;
        }
    }

    ArmWeapon arm_weapon_ = ArmWeapon.AssaultRifle;
    ArmWeapon former_arm_weapon_ = ArmWeapon.AssaultRifle;
    
    void Start ()
    {
        _animator = GetComponent<Animator>();
    }
	
	void Update ()
    {

    }

    public void UpSelect()
    {
        former_arm_weapon_ = arm_weapon_;
        arm_weapon_++;
        if ((int)arm_weapon_ >= 3)
        {
            arm_weapon_ = 0;
        }
        
        SelectWeapon();
    }

    public void DownSelect()
    {
        former_arm_weapon_ = arm_weapon_;
        arm_weapon_--;
        if ((int)arm_weapon_ <0 )
        {
            arm_weapon_ = (ArmWeapon)2;
        }
        SelectWeapon();
        
    }

    void SelectWeapon()
    {
        if(arm_weapon_ == ArmWeapon.AssaultRifle )
        {

            if(former_arm_weapon_ == ArmWeapon.ShotGun)
            {
                is_shotgun_ = false;
                _animator.SetBool(_shotgunHash, is_shotgun_);
            }
            else
            if(former_arm_weapon_ == ArmWeapon.GatlingGun)
            {
                is_gatlinggun_ = false;
                _animator.SetBool(_gatlinggunHash, is_gatlinggun_);
            }
            is_assaultrifle_ = true;
            _animator.SetBool(_assaultrifleHash, is_assaultrifle_);

        }
        else

        if (arm_weapon_ == ArmWeapon.ShotGun)
        {

            if (former_arm_weapon_ == ArmWeapon.AssaultRifle)
            {
                is_assaultrifle_ = false;
                _animator.SetBool(_assaultrifleHash, is_assaultrifle_);
            }
            else
            if (former_arm_weapon_ == ArmWeapon.GatlingGun)
            {
                is_gatlinggun_ = false;
                _animator.SetBool(_gatlinggunHash, is_gatlinggun_);
            }
            is_shotgun_ = true;
            _animator.SetBool(_shotgunHash, is_shotgun_);


        }
        else

        if (arm_weapon_ == ArmWeapon.GatlingGun)
        {

            if (former_arm_weapon_ == ArmWeapon.ShotGun)
            {
                is_shotgun_ = false;
                _animator.SetBool(_shotgunHash, is_shotgun_);
            }
            else
            if (former_arm_weapon_ == ArmWeapon.AssaultRifle)
            {
                is_assaultrifle_ = false;
                _animator.SetBool(_assaultrifleHash, is_assaultrifle_);
            }
            is_gatlinggun_ = true;
            _animator.SetBool(_gatlinggunHash, is_gatlinggun_);

        }

    }
}
