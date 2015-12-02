using UnityEngine;

public class StageCreater : MonoBehaviour
{
    [SerializeField]
    GameObject[] stage_prefabs_ = null;

    [SerializeField]
    int create_stage_num_ = 0;

    void Start()
    {
        var create_stage_num = stage_prefabs_.Length < create_stage_num_ ?
            0 : create_stage_num_;
        create_stage_num = FindObjectOfType<StageData>().stageNum;
        var stage = Instantiate<GameObject>(stage_prefabs_[create_stage_num]);
        stage.name = stage_prefabs_[create_stage_num_].name;
        stage.transform.SetParent(gameObject.transform);
    }
}
