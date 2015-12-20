using UnityEngine;

public class UIMover : MonoBehaviour
{

    float LIMIT_DISTANCE = 0.0f;
    int hash_tag_ = 0;

    void Start()
    {
        hash_tag_ = "HandIndex".GetHashCode();
        var distance = Vector3.Distance(gameObject.transform.position, Camera.main.transform.position);
        LIMIT_DISTANCE = distance;
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "HandIndex") return;
        var distance = Vector3.Distance(collider.transform.position, Camera.main.transform.position);
        if (distance >= LIMIT_DISTANCE + 0.1f ||
            distance <= LIMIT_DISTANCE - 0.1f)
            return;
        gameObject.transform.position = collider.transform.position;

    }
}
