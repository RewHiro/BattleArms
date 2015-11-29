using UnityEngine;
using UnityEngine.Networking;

public class BulletCreater : NetworkBehaviour
{
    [SerializeField]
    GameObject assalut_bullet_ = null;

    [SerializeField]
    GameObject rocket_bullet_ = null;

    [SerializeField]
    GameObject homing_bullet_ = null;

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

    public GameObject getHomingBullet
    {
        get
        {
            return homing_bullet_;
        }
    }
}
