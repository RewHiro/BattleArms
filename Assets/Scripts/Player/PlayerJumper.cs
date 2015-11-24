using UnityEngine;
using UnityEngine.Networking;

public class PlayerJumper : NetworkBehaviour
{

    const int STAGE_LAYER = 11;

    void Start()
    {

        if (!isLocalPlayer) return;
        player_controller_ = GetComponent<PlayerController>();

        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        JUMP_POWER = air_frame_parameter.GetJumpPower(id);

        rigidbody_ = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        if (is_jump_) return;
        if (!player_controller_.isInputJump) return;
        rigidbody_.AddForce(Vector3.up * JUMP_POWER, ForceMode.Impulse);
        is_jump_ = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isLocalPlayer) return;
        if (collision.gameObject.layer != STAGE_LAYER) return;
        is_jump_ = false;
    }

    PlayerController player_controller_ = null;
    Rigidbody rigidbody_ = null;
    float JUMP_POWER = 0.0f;
    bool is_jump_ = false;
}
