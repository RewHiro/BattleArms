using UnityEngine;
using Leap;

public class TitleTrasit : MonoBehaviour
{
    [SerializeField]
    SceneType transit_scene_type_ = SceneType.MODE;

    HandController hand_contoller_ = null;

    void Start()
    {
        hand_contoller_ = FindObjectOfType<HandController>();
    }

    void Update()
    {

        foreach (var gesture in hand_contoller_.GetFrame().Gestures())
        {
            var screen_tap = new ScreenTapGesture(gesture);
            if (!screen_tap.IsValid) break;
            Debug.Log("OK");
            FindObjectOfType<SceneManager>().Transition(transit_scene_type_);
        }
    }
}
