using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class MyNetworkDiscovery : NetworkDiscovery
{

    MyNetworkLobbyManager my_network_lobby_manager_ = null;

    void Start()
    {
        my_network_lobby_manager_ = GetComponent<MyNetworkLobbyManager>();
    }

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        var address = fromAddress.Substring(7);
        my_network_lobby_manager_.networkAddress = address;
        base.OnReceivedBroadcast(fromAddress, data);
    }
}
