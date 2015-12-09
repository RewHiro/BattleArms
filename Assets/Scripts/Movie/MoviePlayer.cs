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
        movie_texture_.Play();
    }
}
