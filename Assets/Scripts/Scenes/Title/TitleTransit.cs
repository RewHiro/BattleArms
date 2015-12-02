using UnityEngine;
using Leap;

public class TitleTransit : MonoBehaviour
{
    [SerializeField]
    SceneType transit_scene_type_ = SceneType.MODE;

    GameObject customize_player_robot_ = null;

    HandController hand_contoller_ = null;

    void Start()
    {
        hand_contoller_ = FindObjectOfType<HandController>();
        customize_player_robot_ = GameObject.FindGameObjectWithTag("Player");
        customize_player_robot_.SetActive(false);
    }

    void Update()
    {
        if (!isTransit) return;
        FindObjectOfType<SceneManager>().Transition(transit_scene_type_);
        customize_player_robot_.SetActive(true);
        var ovr_display = new OVRDisplay();
        ovr_display.RecenterPose();
    }

    bool isTransit
    {
        get
        {
            foreach (var gesture in hand_contoller_.GetFrame().Gestures())
            {
                var screen_tap = new ScreenTapGesture(gesture);
                if (!screen_tap.IsValid) break;
                return true;
            }

            if (Input.GetKeyDown(KeyCode.Return) ||
                Input.GetMouseButtonDown(0) ||
                Input.GetMouseButtonDown(1))
                return true;

            return false;
        }
    }
}
