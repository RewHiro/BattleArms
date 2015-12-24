using UnityEngine;

public class AirFrameDestoyer : MonoBehaviour
{
    HPManager hp_manager_ = null;
    bool guard_ = false;

    void Start()
    {
        hp_manager_ = GetComponent<HPManager>();
    }

    void Update()
    {
        if (hp_manager_.isActive) return;
        if (guard_) return;
        guard_ = true;
        Destroy(gameObject, 4.0f);
    }
}
