using UnityEngine;
using System.Collections;

public class BoostManager : MonoBehaviour
{
    public float boostValue { private set; get; }

    void Start()
    {
        var id = GetComponent<Identificationer>().id;
        boostValue = FindObjectOfType<AirFrameParameter>().GetMaxBoostValue(id);
    }
}
