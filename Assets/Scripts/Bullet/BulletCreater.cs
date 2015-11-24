using UnityEngine;
using System.Collections;

public class BulletCreater : MonoBehaviour
{
    [SerializeField]
    GameObject assalut_bullet_ = null;

    [SerializeField]
    GameObject rocket_bullet_ = null;

    public GameObject getAssaulutBullet
    {
        get
        {
            return assalut_bullet_;
        }
    }

    public GameObject getRocketBullet
    {
        get
        {
            return rocket_bullet_;
        }
    }
}
