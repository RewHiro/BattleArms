using UnityEngine;

public class AirFrameCustomizeUIChanger : MonoBehaviour
{
    [SerializeField]
    GameObject air_frame_select_ui_ = null;

    [SerializeField]
    GameObject weapon_select_ui_ = null;

    public void ChangeAirFrameSelectUI()
    {
        weapon_select_ui_.SetActive(false);
        air_frame_select_ui_.SetActive(true);
    }

    public void ChangeWeaponSelectUI()
    {
        weapon_select_ui_.SetActive(true);
        air_frame_select_ui_.SetActive(false);
    }
}