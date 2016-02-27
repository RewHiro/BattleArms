using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour
{

    const float REACTION_VALUE = 0.1f;
    const float DURATION_TIME = 1.0f;

    bool is_start_ = false;

    [SerializeField]
    GameObject tutorial_info_panel_ = null;

    MissionManager mission_manager_ = null;

    public bool IsStart
    {
        get
        {
            if (mission_manager_ == null) return false;
            return mission_manager_.IsDrawed;
        }
    }

    void Start()
    {
        mission_manager_ = FindObjectOfType<MissionManager>();
    }

    public void Skip()
    {
        Destroy(transform.GetChild(0).gameObject);
        is_start_ = true;
        FindObjectOfType<MissionManager>().StartMissionInfo();
    }

    public void StartTutorial()
    {
        Destroy(transform.GetChild(0).gameObject);
        StartCoroutine("Tutorial");
    }

    IEnumerator Tutorial()
    {

        tutorial_info_panel_.SetActive(true);
        var player_controller = FindObjectOfType<PlayerController>();

        var left_hand = tutorial_info_panel_.transform.FindChild("LeftHand").gameObject;
        var right_hand = tutorial_info_panel_.transform.FindChild("RightHand").gameObject;

        var left_arrow = left_hand.transform.GetChild(0).gameObject;
        var right_arrow = right_hand.transform.GetChild(0).gameObject;

        var left_arrow_image = left_arrow.GetComponent<Image>();
        var right_arrow_image = right_arrow.GetComponent<Image>();

        bool is_next = false;
        float count = 0.0f;

        while (!is_next)
        {
            if (player_controller.getInputVerticalValue >= REACTION_VALUE)
            {
                count += Time.deltaTime;
            }
            else
            {
                count = 0.0f;
            }

            if (count >= DURATION_TIME)
            {
                is_next = true;
            }

            yield return null;
        }

        is_next = false;
        count = 0.0f;

        right_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_blue_01");
        left_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_blue_01");
        left_arrow.GetComponent<RectTransform>().localScale = new Vector3(1, -1, 1);
        right_arrow.GetComponent<RectTransform>().localScale = new Vector3(1, -1, 1);

        while (!is_next)
        {
            if (player_controller.getInputVerticalValue <= -REACTION_VALUE)
            {
                count += Time.deltaTime;
            }
            else
            {
                count = 0.0f;
            }

            if (count >= DURATION_TIME)
            {
                is_next = true;
            }

            yield return null;
        }

        tutorial_info_panel_.SetActive(false);
        is_start_ = true;
        FindObjectOfType<MissionManager>().StartMissionInfo();

        yield return null;
    }
}
