using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkLobbyPlayer : NetworkLobbyPlayer
{

    MoviePlayer movie_player_ = null;
    bool is_ready_ = false;
    bool is_send_server_ = false;


    public override void PreStartClient()
    {
        movie_player_ = FindObjectOfType<MoviePlayer>();
        base.PreStartClient();
    }

    public void Ready()
    {
        is_ready_ = true;
    }

    void Update()
    {
        if (!is_ready_) return;
        if (movie_player_.isPlaying) return;
        if (is_send_server_) return;
        is_send_server_ = true;
        SendReadyToBeginMessage();
    }
}
