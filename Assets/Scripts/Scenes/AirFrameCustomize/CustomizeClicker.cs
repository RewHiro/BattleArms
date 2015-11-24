using UnityEngine;

public class CustomizeClicker : MonoBehaviour
{
    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(SceneType.STAGESELECT);
    }
}
