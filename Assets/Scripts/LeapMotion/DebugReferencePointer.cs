using UnityEngine;
using System.Collections;

public class DebugReferencePointer : MonoBehaviour
{

    [SerializeField]
    bool is_right_ = false;

    void Start()
    {
        var parameter = FindObjectOfType<LeapMotionParameter>();
        if (!parameter.isDebug) Destroy(gameObject);

        var reference_point = parameter.getReferencePoint * ratio_;
        if (!is_right_) reference_point *= -1;

        gameObject.transform.localPosition =
            new Vector3(
            reference_point,
            0.12f,
            0.0f);
    }

    float ratio_ = 0.001f;
}
