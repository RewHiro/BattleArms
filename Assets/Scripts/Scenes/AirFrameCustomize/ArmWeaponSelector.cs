using UnityEngine;

public class ArmWeaponSelector : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapon_list_ = null;

    GameObject right_weapon_ = null;

    GameObject left_weapon_ = null;

    AirFrameManager air_frame_manager_ = null;

    public void ChangeRightWeapon(int id)
    {
        air_frame_manager_.rightWeaponId = id;

        Destroy(right_weapon_.transform.GetChild(0).gameObject);

        var select_weapon = weapon_list_[id];
        var select_weapon_transform = select_weapon.transform;

        var weapon = Instantiate(select_weapon);
        var weapon_transform = weapon.transform;

        weapon_transform.SetParent(right_weapon_.transform);
        weapon_transform.localPosition = select_weapon_transform.position;
        weapon_transform.localRotation = select_weapon_transform.rotation;
        weapon_transform.localScale = select_weapon_transform.lossyScale;

        FindObjectOfType<SoundManager>().PlaySE(4);
    }

    public void ChangeLeftWeapon(int id)
    {
        air_frame_manager_.leftWeaponId = id;

        Destroy(left_weapon_.transform.GetChild(0).gameObject);

        var select_weapon = weapon_list_[id];
        var select_weapon_transform = select_weapon.transform;

        var weapon = Instantiate(select_weapon);
        var weapon_transform = weapon.transform;

        weapon_transform.SetParent(left_weapon_.transform);

        var temp_position = select_weapon_transform.localPosition;
        temp_position.x *= -1;
        weapon.transform.localPosition = temp_position;

        weapon_transform.localRotation = select_weapon_transform.rotation;
        weapon_transform.localScale = select_weapon_transform.lossyScale;

        FindObjectOfType<SoundManager>().PlaySE(4);
    }

    void Start()
    {
        right_weapon_ = GameObject.FindGameObjectWithTag("RightWeapon");
        left_weapon_ = GameObject.FindGameObjectWithTag("LeftWeapon");
        air_frame_manager_ = FindObjectOfType<AirFrameManager>();
    }
}