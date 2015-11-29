using UnityEngine;

public class HomingBulletMover : MonoBehaviour
{

    BezierCurve bezier_curve_ = null;
    float current_time = 0.0f;

    [SerializeField]
    float EXPLOSITION_TIME = 2.0f;

    void Start()
    {
        foreach (var player in FindObjectsOfType<PlayerController>())
        {
            if (!player.isLocalPlayer) continue;
            bezier_curve_ = player.gameObject.GetComponentInChildren<BezierCurve>();
        }
    }

    void Update()
    {
        var elapsed_time = current_time / EXPLOSITION_TIME;
        Vector3 current_point = BezierCurve.GetQuadraticCurvePoint(bezier_curve_[0].position, bezier_curve_[1].position, bezier_curve_[2].position, elapsed_time);
        transform.position = current_point;
        current_time += Time.deltaTime;
    }
}
