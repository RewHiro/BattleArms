using UnityEngine.Networking;

public class Limiter : NetworkBehaviour
{
    float count_ = 60 * 5;

    public float getCount
    {
        get
        {
            return count_;
        }
    }

    [ClientRpc]
    public void RpcTellToClient(float count)
    {
        count_ = count;
    }
}
