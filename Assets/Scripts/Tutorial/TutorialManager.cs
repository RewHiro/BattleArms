using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class TutorialManager : MonoBehaviour
{

    const float REACTION_VALUE = 0.1f;
    const float DURATION_TIME = 1.0f;

    bool is_start_ = false;

    [SerializeField]
    GameObject tutorial_info_panel_ = null;

    [SerializeField]
    Text text_ = null;

    MissionManager mission_manager_ = null;

    SoundManager sound_manager_ = null;

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
        sound_manager_ = FindObjectOfType<SoundManager>();
    }

    public void Skip()
    {
        Destroy(transform.GetChild(0).gameObject);
        is_start_ = true;
        FindObjectOfType<MissionManager>().StartMissionInfo();
        sound_manager_.PlaySE(4);
    }

    public void StartTutorial()
    {
        Destroy(transform.GetChild(0).gameObject);
        StartCoroutine("Tutorial");
        sound_manager_.PlaySE(4);
    }

    void Move(Vector2 position)
    {
        var right_hand = tutorial_info_panel_.transform.FindChild("RightHand").gameObject;
        right_hand.GetComponent<RectTransform>().anchoredPosition = position;
    }


    //TODO：実装できてからリファ
    IEnumerator Tutorial()
    {

        tutorial_info_panel_.SetActive(true);
        var player_controller = FindObjectOfType<PlayerController>();

        var left_hand = tutorial_info_panel_.transform.FindChild("LeftHand").gameObject;
        var right_hand = tutorial_info_panel_.transform.FindChild("RightHand").gameObject;

        var left_arrow = tutorial_info_panel_.transform.FindChild("LeftArrow").gameObject;
        var right_arrow = tutorial_info_panel_.transform.FindChild("RightArrow").gameObject;

        var right_hand_image = right_hand.GetComponent<Image>();
        var left_hand_image = left_hand.GetComponent<Image>();

        var left_arrow_image = left_arrow.GetComponent<Image>();
        var right_arrow_image = right_arrow.GetComponent<Image>();

        bool is_next = false;
        float count = 0.0f;

        left_hand.GetComponent<Animator>().SetTrigger("FrontMove");
        right_hand.GetComponent<Animator>().SetTrigger("FrontMove");

        yield return new WaitForSeconds(2.0f);

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

        sound_manager_.PlaySE(19);


        is_next = false;
        count = 0.0f;

        right_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_blue_01");
        left_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_blue_01");
        left_arrow.GetComponent<RectTransform>().localScale = new Vector3(1, -1, 1);
        right_arrow.GetComponent<RectTransform>().localScale = new Vector3(1, -1, 1);

        left_hand.GetComponent<Animator>().SetTrigger("BackMove");
        right_hand.GetComponent<Animator>().SetTrigger("BackMove");

        text_.text = "後進";

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

        sound_manager_.PlaySE(19);
        is_next = false;
        count = 0.0f;

        right_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_green");
        left_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_green");
        left_arrow.GetComponent<RectTransform>().localScale = Vector3.one;
        left_arrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90);
        right_arrow.GetComponent<RectTransform>().localScale = Vector3.one;
        right_arrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90);

        left_hand.GetComponent<Animator>().SetTrigger("LeftMove");
        right_hand.GetComponent<Animator>().SetTrigger("LeftMove");

        text_.text = "左移動";

        while (!is_next)
        {
            if (player_controller.getInputHorizontalValue <= -REACTION_VALUE)
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

        sound_manager_.PlaySE(19);
        is_next = false;
        count = 0.0f;

        right_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_blue");
        left_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_blue");
        left_arrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -90);
        right_arrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -90);

        left_hand.GetComponent<Animator>().SetTrigger("RightMove");
        right_hand.GetComponent<Animator>().SetTrigger("RightMove");

        text_.text = "右移動";

        while (!is_next)
        {
            if (player_controller.getInputHorizontalValue >= REACTION_VALUE)
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

        sound_manager_.PlaySE(19);
        left_arrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 90);
        right_arrow.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -90);

        left_hand.GetComponent<Animator>().SetTrigger("LeftMove");
        right_hand.GetComponent<Animator>().SetTrigger("RightMove");

        text_.text = "ジャンプ";

        while (!player_controller.isInputJump)
        {
            yield return null;
        }

        sound_manager_.PlaySE(19);
        is_next = false;
        count = 0.0f;

        left_arrow_image.color = new Color(1, 1, 1, 0);
        right_hand_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_hand_03");
        right_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_ring");
        right_arrow.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        right_arrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(120.0f, -16.2f);
        right_arrow.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 20);

        left_hand.GetComponent<Animator>().SetTrigger("Idle");
        right_hand.GetComponent<Animator>().SetTrigger("Idle");
        right_arrow.GetComponent<Animator>().SetTrigger("Anim");

        text_.text = "右武器攻撃";

        while (!is_next)
        {
            if (player_controller.isInputRightAttack)
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

        sound_manager_.PlaySE(19);
        is_next = false;
        count = 0.0f;

        left_arrow_image.color = new Color(1, 1, 1, 1);
        right_arrow_image.color = new Color(1, 1, 1, 0);
        right_hand_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_hand_01");
        left_hand_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_hand_03");
        left_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_ring");
        left_arrow.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        left_arrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(70.0f, -16.2f);
        left_arrow.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 20);

        left_arrow.GetComponent<Animator>().SetTrigger("Anim");
        right_arrow.GetComponent<Animator>().SetTrigger("Idle");

        text_.text = "左武器攻撃";

        while (!is_next)
        {
            if (player_controller.isInputLeftAttack)
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

        sound_manager_.PlaySE(19);
        is_next = false;
        count = 0.0f;

        right_arrow_image.color = new Color(1, 1, 1, 1);
        right_hand_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_hand_03");

        left_arrow.GetComponent<Animator>().SetTrigger("Idle");
        right_arrow.GetComponent<Animator>().SetTrigger("Idle");

        text_.text = "背中武器攻撃";

        yield return null;

        left_arrow.GetComponent<Animator>().SetTrigger("Anim");
        right_arrow.GetComponent<Animator>().SetTrigger("Anim");

        while (!is_next)
        {
            if (player_controller.isInputBothHandAttack)
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

        sound_manager_.PlaySE(19);
        left_hand_image.color = new Color(1, 1, 1, 0);
        right_arrow_image.color = new Color(1, 1, 1, 0);

        left_arrow_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_arrow_swip");
        right_hand_image.sprite = Resources.Load<Sprite>("Tutorial/tuto_hand_02");

        right_hand.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -25);
        left_arrow.GetComponent<RectTransform>().anchoredPosition = new Vector2(90.0f, -17.2f);
        left_arrow.GetComponent<RectTransform>().sizeDelta = new Vector2(60, 20);
        left_arrow.GetComponent<Image>().fillOrigin = 1;

        text_.text = "ターゲットの切り替え";

        while (!player_controller.isChangeTarget)
        {
            yield return null;
        }

        sound_manager_.PlaySE(19);
        tutorial_info_panel_.SetActive(false);
        is_start_ = true;
        FindObjectOfType<MissionManager>().StartMissionInfo();

        yield return null;
    }
}
