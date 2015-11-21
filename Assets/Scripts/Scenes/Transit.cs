using UnityEngine;

public class Transit : MonoBehaviour
{

    [SerializeField]
    SceneType transit_scene_type_;

    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(transit_scene_type_);
    }
}
