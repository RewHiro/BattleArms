using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkLobbyPlayer : NetworkLobbyPlayer
{

    MoviePlayer movie_player_ = null;
    bool is_ready_ = false;
    bool is_send_server_ = false;
    bool is_sound_ = false;
    SoundManager sound_manager_ = null;

    public override void PreStartClient()
    {
        movie_player_ = FindObjectOfType<MoviePlayer>();
        sound_manager_ = FindObjectOfType<SoundManager>();
        base.PreStartClient();
    }

    public void Ready()
    {
        is_ready_ = true;
    }

    void Update()
    {
        if (!is_ready_) return;

        if (!sound_manager_.IsPlaySE(15))
        {
            if (!is_sound_)
            {
                is_sound_ = true;
                sound_manager_.PlaySE(16);
            }
        }
        if (movie_player_.isPlaying) return;
        if (is_send_server_) return;
        movie_player_.Stop();
        is_send_server_ = true;
        SendReadyToBeginMessage();
    }
}
