using UnityEngine.Networking;
using UnityEngine;

public class PlayerMeleeAttacker : NetworkBehaviour
{
    [SerializeField]
    GameObject left_hand_ = null;

    [SerializeField]
    GameObject right_hand_ = null;

    PlayerModer player_moder_ = null;
    HandController hand_controller_ = null;

    float MOVE_MENT_RATIO_X = 4.0f;
    float MOVE_MENT_RATIO_Z = 6.0f;

    int attack_count_ = 0;

    public bool isThreeAttacked
    {
        get
        {
            return attack_count_ >= 3;
        }
    }

    public void SendAttack()
    {
        attack_count_++;
    }

    public override void OnStartLocalPlayer()
    {
        player_moder_ = GetComponent<PlayerModer>();
        hand_controller_ = GetComponentInChildren<HandController>();
        base.OnStartLocalPlayer();
    }

    void Update()
    {
        foreach (var hand in hand_controller_.GetFrame().Hands)
        {
            if (hand.IsLeft)
            {
                var position = Leap.UnityVectorExtension.ToUnityScaled(hand.PalmPosition);
                position.x *= MOVE_MENT_RATIO_X;
                position.z *= MOVE_MENT_RATIO_Z;
                left_hand_.transform.localPosition = position;
            }
            else if (hand.IsRight)
            {
                var position = Leap.UnityVectorExtension.ToUnityScaled(hand.PalmPosition);
                position.x *= MOVE_MENT_RATIO_X;
                position.z *= MOVE_MENT_RATIO_Z;
                right_hand_.transform.localPosition = position;
            }
        }
        AttackCountReset();
    }

    void AttackCountReset()
    {
        if (!player_moder_.isNormalMode) return;
        attack_count_ = 0;
    }
}
