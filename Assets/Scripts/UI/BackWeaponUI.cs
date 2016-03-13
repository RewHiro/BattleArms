using UnityEngine;
using System.Collections;

enum BackWeapon
{
    LaserGun,
    HomingMissile
}

public class BackWeaponUI : MonoBehaviour {


    private bool is_lasergun_ = true;
    private bool is_homingmissile_ = false;
    private Animator _animator;
    private int _lasergunHash = Animator.StringToHash("Is_LaserGun");
    private int _homingmissileHash = Animator.StringToHash("Is_HomingMissile");

    BackWeapon back_weapon_ = BackWeapon.LaserGun;
    BackWeapon former_back_weapon_ = BackWeapon.LaserGun;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }



    public void UpSelect()
    {
        former_back_weapon_ = back_weapon_;
        back_weapon_++;
        if((int)back_weapon_ >= 2)
        {
            back_weapon_ = 0;
        }
        SelectWeapon();
    }

    public void DownSelect()
    {
        former_back_weapon_ = back_weapon_;
        back_weapon_--;
        if ((int)back_weapon_ < 0)
        {
            back_weapon_ = (BackWeapon)1;
        }
        SelectWeapon();

    }

    void SelectWeapon()
    {
        if(back_weapon_ == BackWeapon.LaserGun)
        {
            is_homingmissile_ = false;
            _animator.SetBool(_homingmissileHash, is_homingmissile_);


            is_lasergun_ = true;
            _animator.SetBool(_lasergunHash, is_lasergun_);
        }
        else
        if(back_weapon_ == BackWeapon.HomingMissile)
        {
            is_lasergun_ = false;
            _animator.SetBool(_lasergunHash, is_lasergun_);

            is_homingmissile_ = true;
            _animator.SetBool(_homingmissileHash, is_homingmissile_);
        }
    }
}



