using UnityEngine;

public class HomingBulletMover : MonoBehaviour
{

    GameObject target_enemy_ = null;

    Reticle reticle_ = null;

    BezierCurve bezier_curve_ = null;
    Vector3 old_position_ = Vector3.zero;
    float current_time = 0.0f;

    [SerializeField]
    float EXPLOSITION_TIME = 2.0f;

    public void SetReticle(Reticle reticle)
    {
        reticle_ = reticle;
    }

    void Start()
    {
        foreach (var player in FindObjectsOfType<PlayerController>())
        {
            if (!player.isLocalPlayer) continue;
            bezier_curve_ = player.gameObject.GetComponentInChildren<BezierCurve>();
        }

        old_position_ = gameObject.transform.position;
    }

    void Update()
    {
        var direction = gameObject.transform.position - old_position_;

        gameObject.transform.rotation = 
        Quaternion.LookRotation(direction);

        old_position_ = gameObject.transform.position;

        BezierMove();
        HomingMove();
    }

    void BezierMove()
    {
        if (current_time >= EXPLOSITION_TIME) return;
        var elapsed_time = current_time / EXPLOSITION_TIME;
        Vector3 current_point = BezierCurve.GetQuadraticCurvePoint(bezier_curve_[0].position, bezier_curve_[1].position, bezier_curve_[2].position, elapsed_time);
        transform.position = current_point;
        current_time += Time.deltaTime;
    }

    void HomingMove()
    {
        if (current_time < EXPLOSITION_TIME) return;

    }

}
