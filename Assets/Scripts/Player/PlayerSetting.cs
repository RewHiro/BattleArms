using UnityEngine.Networking;

public class PlayerSetting : NetworkBehaviour
{
    void Start()
    {
        if (isLocalPlayer)
        {
            gameObject.name = "Player01";
        }
        else
        {
            gameObject.name = "Player02";
        }
    }
}
