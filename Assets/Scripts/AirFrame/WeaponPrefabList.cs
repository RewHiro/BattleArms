using UnityEngine;

public class WeaponPrefabList : MonoBehaviour
{
    [SerializeField]
    GameObject[] weapon_list_ = null;

    public GameObject GetWeaponPrefab(uint num)
    {
        return weapon_list_[num];
    }
}
