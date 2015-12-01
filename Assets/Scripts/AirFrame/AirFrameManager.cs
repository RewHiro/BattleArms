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

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}