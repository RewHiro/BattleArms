using UnityEngine;
using System;

public enum SceneType
{
    TITLE,
    MODE,
    LOBBY,
    CUSTOMIZE,
    STAGESELECT,
    GAME
}

[Serializable]
public struct SceneData
{
    public GameObject scene_prefab_;
    public SceneType type_;
}