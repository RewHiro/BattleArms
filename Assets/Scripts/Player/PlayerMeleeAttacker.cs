using UnityEngine.Networking;
using UnityEngine;

public class PlayerMeleeAttacker : NetworkBehaviour
{
    [SerializeField]
    GameObject hand_ = null;

    PlayerModer player_moder_ = null;
    HandController hand_controller_ = null;

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
            if (!hand.IsLeft) continue;
            Debug.Log(hand.PalmPosition);
            var position = Leap.UnityVectorExtension.ToUnity(hand.PalmPosition) * 0.01f;
            position.y -= 1.5f;
            hand_.transform.localPosition = position;
        }

    }
}
