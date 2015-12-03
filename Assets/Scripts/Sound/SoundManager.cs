using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SoundManager : MonoBehaviour
{

    List<AudioSource> bgm_list_ = new List<AudioSource>();
    List<AudioSource> se_list_ = new List<AudioSource>();

    [SerializeField]
    AudioClip[] bgms_ = null;

    [SerializeField]
    AudioClip[] ses_ = null;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < bgms_.Length; ++i)
        {
            var audio_source = new AudioSource();
            audio_source.clip = bgms_[i];
            bgm_list_.Add(audio_source);
        }

        for (int i = 0; i < bgms_.Length; ++i)
        {
            var audio_source = new AudioSource();
            audio_source.clip = ses_[i];
            se_list_.Add(audio_source);
        }
    }

    void PlaySE(int num)
    {
        if (se_list_[num].isPlaying) return;
        se_list_[num].Play();
    }

    void PlayBGM(int num)
    {
        if (bgm_list_[num].isPlaying) return;
        bgm_list_[num].Play();
    }

    void StopSE()
    {
        var itr = se_list_.GetEnumerator();
        while (itr.MoveNext())
        {
            itr.Current.Stop();
        }
    }

    void StopBGM()
    {
        var itr = bgm_list_.GetEnumerator();
        while (itr.MoveNext())
        {
            itr.Current.Stop();
        }
    }
}
