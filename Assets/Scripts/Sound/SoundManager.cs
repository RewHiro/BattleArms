using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{

    List<AudioSource> bgm_list_ = new List<AudioSource>();
    List<AudioSource> se_list_ = new List<AudioSource>();

    [SerializeField]
    AudioClip[] bgms_ = null;

    [SerializeField]
    AudioClip[] ses_ = null;

    static bool is_create_ = false;

    void Awake()
    {
        if (!is_create_)
        {
            DontDestroyOnLoad(gameObject);
            is_create_ = true;

            for (int i = 0; i < bgms_.Length; ++i)
            {
                var audio_source = gameObject.AddComponent<AudioSource>();
                audio_source.clip = bgms_[i];
                audio_source.loop = true;
                bgm_list_.Add(audio_source);
            }

            for (int i = 0; i < ses_.Length; ++i)
            {
                var audio_source = gameObject.AddComponent<AudioSource>();
                audio_source.clip = ses_[i];
                se_list_.Add(audio_source);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {


    }

    public void PlaySE(int num)
    {
        //if (se_list_[num].isPlaying) return;
        se_list_[num].Play();
    }

    public void PlayBGM(int num)
    {
        if (bgm_list_[num].isPlaying) return;
        bgm_list_[num].Play();
    }

    public void StopSE()
    {
        var itr = se_list_.GetEnumerator();
        while (itr.MoveNext())
        {
            itr.Current.Stop();
        }
    }

    public void StopBGM()
    {
        var itr = bgm_list_.GetEnumerator();
        while (itr.MoveNext())
        {
            itr.Current.Stop();
        }
    }

    public void StopBGM(int num)
    {
        bgm_list_[num].Stop();
    }

    public void StopSE(int num)
    {
        se_list_[num].Stop();
    }
}
