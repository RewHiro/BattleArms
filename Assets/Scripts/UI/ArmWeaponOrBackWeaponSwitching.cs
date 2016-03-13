using UnityEngine;
using System.Collections;

public class ArmWeaponOrBackWeaponSwitching : MonoBehaviour {

    [SerializeField]
    GameObject weapon_;

    [SerializeField]
    GameObject back_weapon_;

    [SerializeField]
    GameObject down_arrow_image_;

    [SerializeField]
    GameObject up_arrow_image_;

    void Start ()
    {
	
	}
	
	void Update ()
    {
	}

    public void Switch()
    {
        if(weapon_.activeInHierarchy == true)
        {
            back_weapon_.active = true;
            weapon_.active = false;
            down_arrow_image_.transform.FindChild("ArmWeaponButton").gameObject.active = false;
            down_arrow_image_.transform.FindChild("BackButton").gameObject.active = true;
            up_arrow_image_.transform.FindChild("ArmWeaponButton").gameObject.active = false;
            up_arrow_image_.transform.FindChild("BackButton").gameObject.active = true;
        }
        else
        if (back_weapon_.activeInHierarchy == true)
        {
            weapon_.active = true;
            back_weapon_.active = false;
            down_arrow_image_.transform.FindChild("ArmWeaponButton").gameObject.active = true;
            down_arrow_image_.transform.FindChild("BackButton").gameObject.active = false;
            up_arrow_image_.transform.FindChild("ArmWeaponButton").gameObject.active = true;
            up_arrow_image_.transform.FindChild("BackButton").gameObject.active = false;
        }
    }
}
