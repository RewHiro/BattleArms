using UnityEngine;
using UnityEngine.UI;

public class ShowWeponStatus : MonoBehaviour
{
    AirFrameManager air_frame_manager_ = null;


    [SerializeField]
    private string weapon_A_1 = "A";
    [SerializeField]
    private string weapon_A_2 = "A";
    [SerializeField]
    private string weapon_A_3 = "A";
    [SerializeField]
    private string weapon_A_4 = "A";
    [SerializeField]
    private string weapon_A_5 = "A";

    [SerializeField]
    private string weapon_B_1 = "B";
    [SerializeField]
    private string weapon_B_2 = "B";
    [SerializeField]
    private string weapon_B_3 = "B";
    [SerializeField]
    private string weapon_B_4 = "B";
    [SerializeField]
    private string weapon_B_5 = "B";

    [SerializeField]
    private string weapon_C_1 = "C";
    [SerializeField]
    private string weapon_C_2 = "C";
    [SerializeField]
    private string weapon_C_3 = "C";
    [SerializeField]
    private string weapon_C_4 = "C";
    [SerializeField]
    private string weapon_C_5 = "C";

    [SerializeField]
    private string weapon_D_1 = "D";
    [SerializeField]
    private string weapon_D_2 = "D";
    [SerializeField]
    private string weapon_D_3 = "D";
    [SerializeField]
    private string weapon_D_4 = "D";
    [SerializeField]
    private string weapon_D_5 = "D";

    [SerializeField]
    private string weapon_E_1 = "E";
    [SerializeField]
    private string weapon_E_2 = "E";
    [SerializeField]
    private string weapon_E_3 = "E";
    [SerializeField]
    private string weapon_E_4 = "E";
    [SerializeField]
    private string weapon_E_5 = "E";

    [SerializeField]
    WeaponUI right_weapon_;

    [SerializeField]
    WeaponUI left_weapon_;

    [SerializeField]
    BackWeaponUI back_weapon_;

    Text text_ = null;

    public int ShowWeaponStatus(int id)
    {
        return air_frame_manager_.rightWeaponId = id;
    }

    void Start()
    {
        air_frame_manager_ = FindObjectOfType<AirFrameManager>();

        text_ = GetComponent<Text>();
    }

    void BackWeaponUpdate()
    {
        if (!back_weapon_.gameObject.activeSelf) return;

        switch (back_weapon_.getBackWeapon)
        {
            case BackWeapon.LaserGun:
                text_.text =
                "威力：" + weapon_D_1 +
                "\n\n" +
                "\n射程：" + weapon_D_2 +
                "\n\n" +
                "\n連射：" + weapon_D_3;
                break;

            case BackWeapon.HomingMissile:
                text_.text =
                "威力：" + weapon_E_1 +
                "\n\n" +
                "\n射程：" + weapon_E_2 +
                "\n\n" +
                "\n連射：" + weapon_E_3;
                break;
        }

    }

    void ArmWeaponUpdate(WeaponUI weapon_ui)
    {
        if (!weapon_ui.gameObject.activeSelf) return;

        switch (weapon_ui.getArmWeapon)
        {
            case ArmWeapon.AssaultRifle:
                text_.text =
                    "威力：" + weapon_A_1 +
                    "\n\n" +
                    "\n射程：" + weapon_A_2 +
                    "\n\n" +
                    "\n連射：" + weapon_A_3;
                break;

            case ArmWeapon.ShotGun:
                text_.text =
                    "威力：" + weapon_B_1 +
                    "\n\n" +
                    "\n射程：" + weapon_B_2 +
                    "\n\n" +
                    "\n連射：" + weapon_B_3;
                break;

            case ArmWeapon.GatlingGun:
                text_.text =
                    "威力：" + weapon_C_1 +
                    "\n\n" +
                    "\n射程：" + weapon_C_2 +
                    "\n\n" +
                    "\n連射：" + weapon_C_3;
                break;
        }
    }

    void Update()
    {
        ArmWeaponUpdate(right_weapon_);
        ArmWeaponUpdate(left_weapon_);
        BackWeaponUpdate();
    }
}
