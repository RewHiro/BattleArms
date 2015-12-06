using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetting : NetworkBehaviour
{

    [SerializeField]
    GameObject right_weapon_ = null;

    [SerializeField]
    GameObject left_weapon_ = null;

    [SyncVar]
    int left_weapon_id_ = 0;

    [SyncVar]
    int right_weapon_id_ = 0;

    [SyncVar]
    int back_weapon_id_ = 0;

    [SyncVar]
    int air_frame_id_ = 0;

    public int getLeftWeaponID
    {
        get
        {
            return left_weapon_id_;
        }
    }

    public int getRightWeaponID
    {
        get
        {
            return right_weapon_id_;
        }
    }

    public int getBackWeaponID
    {
        get
        {
            return back_weapon_id_;
        }
    }

    public int getAirFrameID
    {
        get
        {
            return air_frame_id_;
        }
    }

    void Start()
    {
        if (isLocalPlayer)
        {
            gameObject.name = "Player01";
            var air_frame_manager = FindObjectOfType<AirFrameManager>();
            left_weapon_id_ = air_frame_manager.leftWeaponId;
            right_weapon_id_ = air_frame_manager.rightWeaponId;
            back_weapon_id_ = air_frame_manager.backWeaponId;
            air_frame_id_ = air_frame_manager.airFrameId;

            CreateRightWeapon(right_weapon_id_);
            CreateLeftWeapon(left_weapon_id_);
        }
        else
        {
            gameObject.name = "Player02";

            CreateRightWeapon(right_weapon_id_);
            CreateLeftWeapon(left_weapon_id_);

            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i);
                if ("mesh" != child.name) continue;
                child.gameObject.layer = LayerMask.NameToLayer("Player");
            }
        }
    }

    void CreateRightWeapon(int id)
    {
        
        var select_weapon = FindObjectOfType<WeaponPrefabList>().GetWeaponPrefab((uint)id);
        var select_weapon_transform = select_weapon.transform;

        var weapon = Instantiate(select_weapon);
        var weapon_transform = weapon.transform;

        weapon_transform.SetParent(right_weapon_.transform);
        weapon_transform.localPosition = select_weapon_transform.position;
        weapon_transform.localRotation = select_weapon_transform.rotation;
        weapon_transform.localScale = select_weapon_transform.lossyScale;

    }

    void CreateLeftWeapon(int id)
    {

        var select_weapon = FindObjectOfType<WeaponPrefabList>().GetWeaponPrefab((uint)id);
        var select_weapon_transform = select_weapon.transform;

        var weapon = Instantiate(select_weapon);
        var weapon_transform = weapon.transform;

        weapon_transform.SetParent(left_weapon_.transform);

        var temp_position = select_weapon_transform.localPosition;
        temp_position.x *= -1;
        weapon.transform.localPosition = temp_position;

        weapon_transform.localRotation = select_weapon_transform.rotation;
        weapon_transform.localScale = select_weapon_transform.lossyScale;
    }
}
