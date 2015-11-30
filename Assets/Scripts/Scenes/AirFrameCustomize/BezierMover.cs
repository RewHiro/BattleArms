using UnityEngine;
using System.Collections;

public class BezierMover : MonoBehaviour
{
    public GameObject getMoveObject
    {
        get
        {
            return move_object_;
        }
    }

    [SerializeField]
    GameObject move_object_ = null;

    [SerializeField]
    float STOP_TIME = 1.0f;

    enum Type
    {
        START,
        MOVE,
        STOP
    }

    BezierCurve bezier_curve_ = null;

    Type type_ = Type.STOP;

    float current_time_ = 0.0f;

    void Start()
    {
        bezier_curve_ = GetComponent<BezierCurve>();
    }

    void Update()
    {
        BezeirMove();
    }

    public void BezeirStart()
    {
        type_ = Type.MOVE;
        current_time_ = 0.0f;
    }

    void BezeirMove()
    {
        if (type_ != Type.MOVE) return;
        var elapsed_time = current_time_ / STOP_TIME;
        Vector3 current_point = BezierCurve.GetQuadraticCurvePoint(bezier_curve_[0].position, bezier_curve_[1].position, bezier_curve_[2].position, elapsed_time);
        current_time_ += Time.deltaTime;

        move_object_.transform.position = current_point;

        var player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        iTween.LookUpdate(move_object_.gameObject, player_position, 1.0f);

        if (!(current_time_ >= STOP_TIME)) return;
        type_ = Type.STOP;
    }

    void BezeirStop()
    {
        if (type_ != Type.STOP) return;

    }
}
