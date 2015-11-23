using UnityEngine;
using System.Collections;
using Leap;
using System;

public class LeftHandInput : MonoBehaviour
{

    float ratio_ = 0.01f;

    float reference_point_ = 100.0f;

    [SerializeField]
    float REACTION_VALUE = 0.1f;

    [SerializeField]
    float REACTION_GRAB_VALUE = 1.0f;

    public float getHorizaontalValue
    {
        get
        {
            var point = reference_point_ + hand_model_.GetLeapHand().PalmPosition.x;
            point *= ratio_;
            point = Mathf.Clamp(point, -1.0f, 1.0f);
            if (REACTION_VALUE > point && -REACTION_VALUE < point) return 0.0f;
            return point;
        }
    }

    public float getVerticalValue
    {
        get
        {
            var point = -hand_model_.GetLeapHand().PalmPosition.z * ratio_;
            point = Mathf.Clamp(point, -1.0f, 1.0f);
            if (REACTION_VALUE > point && -REACTION_VALUE < point) return 0.0f;
            return point;
        }
    }

    public bool isFront
    {
        get
        {
            return getVerticalValue > 0.0f;
        }
    }

    public bool isBack
    {
        get
        {
            return getVerticalValue < 0.0f;
        }
    }

    public bool isRight
    {
        get
        {
            return getHorizaontalValue > 0.0f;
        }
    }

    public bool isLeft
    {
        get
        {
            return getHorizaontalValue < 0.0f;
        }
    }

    public bool isNeutral
    {
        get
        {
            return getHorizaontalValue == 0.0f &&
                getVerticalValue == 0.0f;
        }
    }

    public bool isGrabed
    {
        get
        {
            return hand_model_.GetLeapHand().GrabStrength >= REACTION_GRAB_VALUE;
        }
    }

    void Start()
    {
        hand_model_ = GetComponent<HandModel>();
        player_controller_ = FindObjectOfType<PlayerController>();
        player_controller_.SetLeftHandInput(this);

        var parameter = FindObjectOfType<LeapMotionParameter>();
        REACTION_VALUE = parameter.getReactionValue;
        reference_point_ = parameter.getReferencePoint;

    }

    void Update()
    {
        if (player_controller_.getLeftHandInput == null) player_controller_.SetLeftHandInput(this);
    }

    PlayerController player_controller_ = null;

    HandModel hand_model_ = null;
}
