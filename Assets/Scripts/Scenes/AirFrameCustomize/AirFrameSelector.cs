using UnityEngine;
using System.Collections.Generic;

public class AirFrameSelector : MonoBehaviour
{
    [SerializeField]
    GameObject customize_light_player_ = null;

    [SerializeField]
    GameObject customize_middle_player_ = null;

    [SerializeField]
    GameObject customize_heavy_player_ = null;


    // enumに変える予定
    //　現状ボタンコンポーネントのインスペクターで変更不可なのでintでやっている
    Dictionary<int, GameObject> customize_players_ = new Dictionary<int, GameObject>();

    public void Transition()
    {
        FindObjectOfType<SceneManager>().Transition(SceneType.STAGESELECT);
    }

    public void ChangeCustomizePlayer(int type)
    {
        var current_customize_player = GameObject.FindGameObjectWithTag("Player");
        var parent = current_customize_player.transform.parent.gameObject;

        Destroy(current_customize_player);

        var customize_player_prefab = customize_players_[type];
        var customize_player = Instantiate(customize_player_prefab);

        customize_player.name = customize_player_prefab.name;
        customize_player.transform.SetParent(parent.transform);
    }

    void Start()
    {
        customize_players_.Add(0, customize_light_player_);
        customize_players_.Add(1, customize_middle_player_);
        customize_players_.Add(2, customize_heavy_player_);
    }

}
