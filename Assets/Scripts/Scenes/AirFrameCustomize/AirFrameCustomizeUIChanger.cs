using UnityEngine;

public class AirFrameCustomizeUIChanger : MonoBehaviour
{
    [SerializeField]
    GameObject air_frame_select_ui_ = null;

    [SerializeField]
    GameObject right_weapon_select_ui_ = null;

    [SerializeField]
    GameObject left_weapon_select_ui_ = null;

    [SerializeField]
    GameObject back_weapon_select_ui_ = null;

    public void ChangeAirFrameSelectUI()
    {
        right_weapon_select_ui_.SetActive(false);
        air_frame_select_ui_.SetActive(true);
        left_weapon_select_ui_.SetActive(false);
        back_weapon_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
    }

    public void ChangeRightWeaponSelectUI()
    {
        right_weapon_select_ui_.SetActive(true);
        air_frame_select_ui_.SetActive(false);
        left_weapon_select_ui_.SetActive(false);
        back_weapon_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
    }

    public void ChangeLeftWeaponSelectUI()
    {
        left_weapon_select_ui_.SetActive(true);
        right_weapon_select_ui_.SetActive(false);
        back_weapon_select_ui_.SetActive(false);
        air_frame_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
    }

    public void ChangeBackWeaponSelectUI()
    {
        back_weapon_select_ui_.SetActive(true);
        left_weapon_select_ui_.SetActive(false);
        right_weapon_select_ui_.SetActive(false);
        air_frame_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
    }
}