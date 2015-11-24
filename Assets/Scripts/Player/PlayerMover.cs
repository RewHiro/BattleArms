using UnityEngine;
using UnityEngine.Networking;

public class PlayerMover : NetworkBehaviour
{
    void Start()
    {
        if (!isLocalPlayer) return;
        player_controller_ = GetComponent<PlayerController>();

        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        MOVE_SPEED = air_frame_parameter.GetMoveSpeed(id);
        BOOST_POWER = air_frame_parameter.GetBoostPower(id);

    }

    void Update()
    {
        if (!isLocalPlayer) return;
        Move();
    }

    void Move()
    {

        var vartical_axis = player_controller_.getInputVerticalValue;
        var horizontal_axis = player_controller_.getInputHorizontalValue;


        if (vartical_axis == 0.0f &&
            horizontal_axis == 0.0f)
            return;

        var direction = gameObject.transform.forward;
        var cross = Vector3.Cross(direction, gameObject.transform.up).normalized;

        direction = direction * vartical_axis;
        direction += -cross * horizontal_axis;

        var slope = 0.0f;
        if (vartical_axis == 0.0f)
        {
            slope = Mathf.Abs(horizontal_axis);
        }
        else if (horizontal_axis == 0.0f)
        {
            slope = Mathf.Abs(vartical_axis);
        }
        else
        {
            slope = (Mathf.Abs(horizontal_axis) + Mathf.Abs(vartical_axis)) * 0.5f;
        }

        float boost_value = 1.0f;

        if (player_controller_.isInputBoost)
        {
            boost_value = BOOST_POWER;
        }

        gameObject.transform.localPosition +=
            direction.normalized * MOVE_SPEED * slope * boost_value * Time.deltaTime;
    }

    PlayerController player_controller_ = null;
    float MOVE_SPEED = 0.0f;
    float BOOST_POWER = 1.0f;
}
