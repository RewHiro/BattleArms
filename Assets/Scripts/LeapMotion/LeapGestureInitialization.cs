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
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE);
        }
        else
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_CIRCLE, false);
        }

        if (shoud_enable_key_tap_gesture_)
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP);
        }
        else
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_KEY_TAP, false);
        }

        if (shoud_enable_screen_tap_gesture_)
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP);
        }
        else
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_SCREEN_TAP, false);
        }

        if (shoud_enable_swipe_gesture_)
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_SWIPE);
        }
        else
        {
            leap_contoller.EnableGesture(Gesture.GestureType.TYPE_SWIPE, false);
        }

        leap_contoller.Config.SetFloat("Gesture.ScreenTap.ForwardVelocity", 10.0f);
        leap_contoller.Config.SetFloat("Gesture.ScreenTap.HistorySeconds", 0.8f);
        leap_contoller.Config.SetFloat("Gesture.ScreenTap.MinDistance", 0.01f);

        leap_contoller.Config.SetFloat("Gesture.KeyTap.MinDownVelocity", 10.0f);
        leap_contoller.Config.SetFloat("Gesture.KeyTap.HistorySeconds", 0.3f);
        leap_contoller.Config.SetFloat("Gesture.KeyTap.MinDistance", 0.01f);

        leap_contoller.Config.SetFloat("Gesture.Swipe.MinLength", 100.0f);
        leap_contoller.Config.SetFloat("Gesture.Swipe.MinVelocity", 750.0f);

        leap_contoller.Config.Save();
    }
}
