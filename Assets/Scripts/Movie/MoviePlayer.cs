using UnityEngine;
using UnityEngine.UI;

public class MoviePlayer : MonoBehaviour
{
    MovieTexture movie_texture_ = null;

    [SerializeField]
    bool is_awake_ = false;

    void Start()
    {
        movie_texture_ = GetComponent<RawImage>().texture as MovieTexture;
        if (is_awake_) movie_texture_.Play();
    }

    public void Play()
    {
        GetComponent<RawImage>().color = new Color(1, 1, 1, 1);
       // movie_texture_.Play();
    }

    public bool isPlaying
    {
        get
        {
            return false;//movie_texture_.isPlaying;
        }
    }

    public void Stop()
    {
        //GetComponent<RawImage>().color = new Color(1, 1, 1, 0);
       // movie_texture_.Stop();
    }
}
