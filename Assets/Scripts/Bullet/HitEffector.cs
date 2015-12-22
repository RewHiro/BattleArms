using UnityEngine;
using System.Collections;

public class HitEffector : MonoBehaviour
{

    [SerializeField]
    GameObject effect_ = null;

    void OnTriggerEnter(Collider collider)
    {
        var effect = Instantiate(effect_);
        effect_.transform.position = gameObject.transform.position;
        Destroy(effect, 4.0f);
    }

}
