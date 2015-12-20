using UnityEngine;
using UnityEngine.Networking;


public class ModeClicker : MonoBehaviour
{

    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(SceneType.CUSTOMIZE);
        var my_network_lobby_manager = FindObjectOfType<MyNetworkLobbyManager>();
        my_network_lobby_manager.maxPlayers = 1;
        my_network_lobby_manager.StartHost();
        FindObjectOfType<SoundManager>().PlaySE(4);
    }

    public void LobbyStart()
    {
        var my_network_lobby_manager = FindObjectOfType<MyNetworkLobbyManager>();
        my_network_lobby_manager.maxPlayers = 6;
        my_network_lobby_manager.StartLobby();
    }

    public void MatchStart()
    {
        var my_network_lobby_manager = FindObjectOfType<MyNetworkLobbyManager>();
        my_network_lobby_manager.maxPlayers = 6;
        my_network_lobby_manager.StartMatchMaker();

        var match_maker = my_network_lobby_manager.matchMaker;

        if (my_network_lobby_manager.matches.Count == 0)
        {
            match_maker.CreateMatch(
                my_network_lobby_manager.matchName,
                my_network_lobby_manager.matchSize,
                true,
                "",
                my_network_lobby_manager.OnMatchCreate
                );
        }
        else
        {
            match_maker.ListMatches(0, 20,"", my_network_lobby_manager.OnMatchList);

            var desc = my_network_lobby_manager.matches[0];
            match_maker.JoinMatch(desc.networkId, "", my_network_lobby_manager.OnMatchJoined);
        }
    }
}
