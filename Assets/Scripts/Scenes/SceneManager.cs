using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SceneManager : MonoBehaviour
{

    [SerializeField]
    SceneType start_scene_type_ = SceneType.TITLE;

    [SerializeField]
    SceneData[] scene_datas_ = null;

    Dictionary<SceneType, GameObject> scene_list_ = new Dictionary<SceneType, GameObject>();

    GameObject current_scene_ = null;

    public void Transition(SceneType scene_type)
    {
        Destroy(current_scene_);
        CreateScene(scene_type);
    }

    void Awake()
    {
        scene_list_ = scene_datas_.ToDictionary(data => data.type_, data => data.scene_prefab_);

        CreateScene(start_scene_type_);
    }

    GameObject CreateScene(SceneType scene_type)
    {
        var scene_prefab = scene_list_.ContainsKey(scene_type) ?
            scene_list_[scene_type] : scene_list_[SceneType.TITLE];

        var scene = Instantiate(scene_prefab);
        scene.name = scene_prefab.name;

        current_scene_ = scene;

        return scene;
    }
}