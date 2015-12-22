using UnityEngine;
using UnityEngine.Networking;

public class PlayerMover : NetworkBehaviour
{
    HPManager hp_manager_ = null;
    PlayerModer player_moder_ = null;

    void Start()
    {
        if (!isLocalPlayer) return;

        hp_manager_ = GetComponent<HPManager>();

        player_controller_ = GetComponent<PlayerController>();
        player_moder_ = GetComponent<PlayerModer>();

        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        MOVE_SPEED = air_frame_parameter.GetMoveSpeed(id);
        BOOST_POWER = air_frame_parameter.GetBoostPower(id);
    }

    void Update()
    {
        if (!isLocalPlayer) return;
        if (!hp_manager_.isActive) return;
        if (!player_moder_.isNormalMode) return;
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

        var slope = 1.0f;

        var abs_vartical_axis = Mathf.Abs(vartical_axis);
        var abs_horizantal_axis = Mathf.Abs(horizontal_axis);

        if (abs_vartical_axis > abs_horizantal_axis)
        {
            slope = abs_vartical_axis;
        }
        else
        {
            slope = abs_horizantal_axis;
        }

        float boost_value = 1.0f;

        if (player_controller_.isInputBoost)
        {
            boost_value = BOOST_POWER;
        }

        gameObject.transform.localPosition +=
             direction.normalized * MOVE_SPEED * boost_value * slope * Time.deltaTime;
    }

    PlayerController player_controller_ = null;
    float MOVE_SPEED = 0.0f;
    float BOOST_POWER = 1.0f;
}
