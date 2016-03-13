using UnityEngine;
using System;
using System.Collections.Generic;

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

    [SerializeField]
    GameObject back_bezier_manager_ = null;

    [SerializeField]
    GameObject left_bezier_manager_ = null;

    List<Action> actions_ = new List<Action>();

    int count_ = 0;

    void Start()
    {
        actions_.Add(ChangeRightWeaponSelectUI);
        actions_.Add(ChangeLeftWeaponSelectUI);
    }

    public void ChangeAirFrameSelectUI()
    {
        right_weapon_select_ui_.SetActive(false);
        air_frame_select_ui_.SetActive(true);
        left_weapon_select_ui_.SetActive(false);
        back_weapon_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
        count_++;
    }

    public void ChangeRightWeaponSelectUI()
    {
        right_weapon_select_ui_.SetActive(true);
        air_frame_select_ui_.SetActive(false);
        left_weapon_select_ui_.SetActive(false);
        back_weapon_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
        count_++;
    }

    public void ChangeLeftWeaponSelectUI()
    {
        left_weapon_select_ui_.SetActive(true);
        right_weapon_select_ui_.SetActive(false);
        back_weapon_select_ui_.SetActive(false);
        air_frame_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
        count_++;
    }

    public void ChangeBackWeaponSelectUI()
    {
        back_weapon_select_ui_.SetActive(true);
        left_weapon_select_ui_.SetActive(false);
        right_weapon_select_ui_.SetActive(false);
        air_frame_select_ui_.SetActive(false);
        FindObjectOfType<SoundManager>().PlaySE(4);
        count_++;
    }

    public void Back()
    {
        count_--;
        if (count_ < 0)
        {
            count_ = 0;
            return;
        }

        if (count_ == 0)
        {
            left_bezier_manager_.GetComponent<BezierMover>().BezeirStart();
        }
        else if (count_ == 1)
        {
            back_bezier_manager_.GetComponent<BezierMover>().BezeirStart();
        }

        actions_[count_]();

        count_--;
    }
}