using UnityEngine;
using UnityEngine.Networking;

public class PlayerRotater : NetworkBehaviour
{
    HPManager hp_manager_ = null;

    void Start()
    {
        if (!isLocalPlayer) return;

        hp_manager_ = GetComponent<HPManager>();

        player_controller_ = GetComponent<PlayerController>();

        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        SWING_SPEED = air_frame_parameter.GetSwingSpeed(id);
    }

    void Update()
    {
        if (!isLocalPlayer) return;

        if (!hp_manager_.isActive) return;

        var rotate_value = player_controller_.getRotateValue;
        if (rotate_value == 0.0f) return;

        gameObject.transform.Rotate(gameObject.transform.up, rotate_value * SWING_SPEED * Time.deltaTime);
    }

    PlayerController player_controller_ = null;
    float SWING_SPEED = 0.0f;
}
