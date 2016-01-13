using UnityEngine;
using System.Collections;

public class BulletPower : MonoBehaviour
{
    float power_ = 0.0f;

    public float getPower
    {
        get
        {
            return power_;
        }
    }

    public void SetPower(float power)
    {
        power_ = power;
    }
}
