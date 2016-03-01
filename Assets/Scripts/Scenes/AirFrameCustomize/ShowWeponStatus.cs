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

    public int ShowWeaponStatus(int id)
    {
        return air_frame_manager_.rightWeaponId = id;

    }

    void Start()
    {
        air_frame_manager_ = FindObjectOfType<AirFrameManager>();
    }

    void Update()
    {
        switch (air_frame_manager_.rightWeaponId)
        {
            case 0:
                GetComponent<Text>().text =
                    "攻撃力：" + weapon_A_1 +
                    "\n連射力：" + weapon_A_2 +
                    "\n・・・：" + weapon_A_3 +
                    "\n・・・：" + weapon_A_4 +
                    "\n・・・：" + weapon_A_5;
                break;
            case 1:
                GetComponent<Text>().text =
                    "攻撃力：" + weapon_B_1 +
                    "\n連射力：" + weapon_B_2 +
                    "\n・・・：" + weapon_B_3 +
                    "\n・・・：" + weapon_B_4 +
                    "\n・・・：" + weapon_B_5;
                break;
            case 2:
                GetComponent<Text>().text =
                    "攻撃力：" + weapon_C_1 +
                    "\n連射力：" + weapon_C_2 +
                    "\n・・・：" + weapon_C_3 +
                    "\n・・・：" + weapon_C_4 +
                    "\n・・・：" + weapon_C_5;
                break;
            case 3:
                GetComponent<Text>().text =
                    "攻撃力：" + weapon_D_1 +
                    "\n連射力：" + weapon_D_2 +
                    "\n・・・：" + weapon_D_3 +
                    "\n・・・：" + weapon_D_4 +
                    "\n・・・：" + weapon_D_5;
                break;
        }
    }
}
