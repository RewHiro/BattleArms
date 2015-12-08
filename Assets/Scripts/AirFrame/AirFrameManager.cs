using UnityEngine;

public class AirFrameManager : MonoBehaviour
{
    public int leftWeaponId
    {
        get; set;
    }

    public int rightWeaponId
    {
        get; set;
    }

    public int backWeaponId
    {
        get; set;
    }

    public int airFrameId
    {
        get; set;
    }

    static bool is_create_ = false;

    void Awake()
    {
        if (!is_create_)
        {
            DontDestroyOnLoad(gameObject);
            is_create_ = true;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Reset()
    {
        leftWeaponId = 0;
        rightWeaponId = 0;
        backWeaponId = 0;
        airFrameId = 0;
    }
}