using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.Linq;

public class MyNetworkLobbyManager : NetworkLobbyManager
{

    bool is_host_ = false;
    bool is_start_ = false;

    [SerializeField]
    string JSON_FILE_NAME = "";

    [SerializeField]
    float WAIT_TIME = 10.0f;

    float count_ = 0.0f;

    public void StartLobby()
    {
        if (is_host_)
        {
            count_ = 0.0f;
            is_start_ = true;
            StartHost();
        }
        else
        {
            StartClient();
        }
    }

    public override void OnLobbyServerSceneChanged(string sceneName)
    {
        base.OnLobbyServerSceneChanged(sceneName);
        foreach (var player in FindObjectsOfType<NetworkLobbyPlayer>())
        {
            if (player.localPlayerAuthority)
            {
                Destroy(player.gameObject);
            }
        }
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);
        StopClient();

    }

    public override void OnLobbyClientConnect(NetworkConnection conn)
    {
        base.OnLobbyClientConnect(conn);
        if (is_host_) return;

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "offline") return;
        FindObjectOfType<SceneManager>().Transition(SceneType.CUSTOMIZE);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
        if (numPlayers != 2) return;
        is_start_ = false;

        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "offline") return;
        FindObjectOfType<SceneManager>().Transition(SceneType.CUSTOMIZE);
    }

    void Start()
    {
        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        JsonNode json = JsonNode.Parse(json_text);
        is_host_ = json["IsHost"].Get<bool>();
        networkAddress = json["IP"].Get<string>();
    }

    void Update()
    {
        foreach (var player in FindObjectsOfType<MyNetworkLobbyPlayer>())
        {
            if (player.isLocalPlayer)
            {
                Debug.Log("host:" + player.readyToBegin.ToString());
            }
            else
            {
                Debug.Log("local:" + player.readyToBegin.ToString());
            }
        }

        if (!is_host_) return;
        if (!is_start_) return;
        count_ += Time.deltaTime;

        if (count_ < WAIT_TIME) return;
        is_start_ = false;
        StopHost();
    }

    public override void OnLobbyServerPlayersReady()
    {
        var players = FindObjectsOfType<MyNetworkLobbyPlayer>();
        var ready = players.All(player => player.readyToBegin);
        if (!ready) return;
        base.OnLobbyServerPlayersReady();
    }

}
