using UnityEngine;
using UnityEngine.UI;

public class LimitUI : MonoBehaviour
{
    Limiter limiter_ = null;
    Text text_ = null;

    void Start()
    {
        foreach (var player in FindObjectsOfType<Limiter>())
        {
            if (!player.isLocalPlayer) continue;
            limiter_ = player;
        }
        text_ = GetComponent<Text>();
    }

    void Update()
    {
        var count = (int)limiter_.getCount;
        int min = count / 60;
        int sec = count % 60;

        text_.text = min.ToString() + ":" + sec.ToString();
    }
}
