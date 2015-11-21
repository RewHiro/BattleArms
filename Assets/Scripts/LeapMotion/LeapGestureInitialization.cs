using UnityEngine;
using Leap;

public class LeapGestureInitialization : MonoBehaviour
{

    [SerializeField]
    bool shoud_enable_circle_gesture_ = false;

    [SerializeField]
    bool shoud_enable_key_tap_gesture_ = false;

    [SerializeField]
    bool shoud_enable_screen_tap_gesture_ = false;

    [SerializeField]
    bool shoud_enable_swipe_gesture_ = false;


    void Awake()
    {
        var leap_contoller = GetComponent<HandController>().GetLeapController();

        if (shoud_enable_circle_gesture_) 
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);

        if (shoud_enable_key_tap_gesture_)
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);

        if (shoud_enable_screen_tap_gesture_)
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);

        if (shoud_enable_swipe_gesture_)
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
    }
}
