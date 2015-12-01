using UnityEngine;
using System.Collections.Generic;

public class CustomizeClicker : MonoBehaviour
{
    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(SceneType.STAGESELECT);
    }
}
