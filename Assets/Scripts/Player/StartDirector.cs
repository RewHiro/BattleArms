using UnityEngine.Networking;
using UnityEngine;

public class StartDirector : NetworkBehaviour
{
    [SyncVar]
    bool is_start_ = false;

    public bool isStart
    {
        get
        {
            return is_start_;
        }
    }

    [SerializeField]
    GameObject movie_ = null;

    MoviePlayer movie_player_ = null;

    [Command]
    void CmdStart()
    {
        is_start_ = true;
    }

    void Start()
    {
        if (!isLocalPlayer) return;
        movie_player_ = movie_.GetComponent<MoviePlayer>();
    }

    void Update()
    {
        //if (!isLocalPlayer) return;
        //if (movie_player_.isPlaying) return;
        //movie_player_.Stop();
        //is_start_ = true;
        //CmdStart();
    }
}
