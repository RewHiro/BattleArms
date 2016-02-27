using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionManager : MonoBehaviour
{

    [SerializeField]
    GameObject bg_panel_ = null;

    [SerializeField]
    GameObject info_panel_ = null;

    bool is_drawed_ = false;

    public bool IsDrawed
    {
        get
        {
            return is_drawed_;
        }
    }

    void Start()
    {
        bg_panel_.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        info_panel_.GetComponent<Image>().color = new Color(1, 1, 1, 0);
    }

    public void StartMissionInfo()
    {
        StartCoroutine(DrawMissionInfo());
    }

    IEnumerator DrawMissionInfo()
    {
        var bg_image = bg_panel_.GetComponent<Image>();
        var info_image = info_panel_.GetComponent<Image>();

        var color = bg_image.color;

        while (color.a <= 1.0f)
        {
            color.a += Time.deltaTime;
            bg_image.color = color;
            info_image.color = color;
            yield return null;
        }

        yield return new WaitForSeconds(2.0f);

        while (color.a > 0.0f)
        {
            color.a += -Time.deltaTime;
            bg_image.color = color;
            info_image.color = color;
            yield return null;
        }

        is_drawed_ = true;

        yield return null;
    }
}
