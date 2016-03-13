using UnityEngine;
using UnityEngine.UI;

public class LimitUI : MonoBehaviour
{
    Limiter limiter_ = null;
    Text text_ = null;

    int save_sec_ = 0;

    SoundManager sound_manager_ = null;

    void Start()
    {
        foreach (var player in FindObjectsOfType<Limiter>())
        {
            if (!player.isLocalPlayer) continue;
            limiter_ = player;
        }
        text_ = GetComponent<Text>();
        sound_manager_ = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        var count = (int)limiter_.getCount;
        int min = count / 60;
        int sec = count % 60;

        int ten_sec = sec / 10;
        int one_sec = sec % 10;

        text_.text = min.ToString() + ":" + ten_sec.ToString() + one_sec.ToString();

        CountSe(min, sec);
    }

    void CountSe(int min, int sec)
    {
        if (min > 1) return;
        if (sec > 10) return;
        if (save_sec_ == sec) return;
        save_sec_ = sec;
        sound_manager_.PlaySE(17);
    }
}
