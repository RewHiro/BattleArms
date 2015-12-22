using UnityEngine;

public class BackWeaponSelector : MonoBehaviour
{

    [SerializeField]
    GameObject[] weapon_list_ = null;

    GameObject back_weapon_ = null;

    AirFrameManager air_frame_manager_ = null;


    public void ChangeBackWeapon(int id)
    {
        air_frame_manager_.backWeaponId = id;

        Destroy(back_weapon_.transform.GetChild(0).gameObject);

        var select_weapon = weapon_list_[id];
        var select_weapon_transform = select_weapon.transform;

        var weapon = Instantiate(select_weapon);
        var weapon_transform = weapon.transform;

        weapon_transform.SetParent(back_weapon_.transform);
        weapon_transform.localPosition = select_weapon_transform.position;
        weapon_transform.localRotation = select_weapon_transform.rotation;
        weapon_transform.localScale = select_weapon_transform.lossyScale;

        FindObjectOfType<SoundManager>().PlaySE(4);
    }

    void Start()
    {
        back_weapon_ = GameObject.FindGameObjectWithTag("BackWeapon");
        air_frame_manager_ = FindObjectOfType<AirFrameManager>();
    }
}
