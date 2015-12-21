using UnityEngine;
using UnityEngine.Networking;

public class PlayerJumper : NetworkBehaviour
{

    const int STAGE_LAYER = 13;

    HPManager hp_manager_ = null;
    PlayerModer player_moder_ = null;

    void Start()
    {

        if (!isLocalPlayer) return;

        hp_manager_ = GetComponent<HPManager>();

        player_controller_ = GetComponent<PlayerController>();

        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        JUMP_POWER = air_frame_parameter.GetJumpPower(id);

        rigidbody_ = GetComponent<Rigidbody>();

        player_moder_ = GetComponent<PlayerModer>();
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        if (!hp_manager_.isActive) return;
        if (!player_moder_.isNormalMode) return;
        if (is_jump_) return;
        if (!player_controller_.isInputJump) return;
        Debug.Log("OK");
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
