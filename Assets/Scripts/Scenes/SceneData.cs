using UnityEngine;
using System;

public enum SceneType
{
    TITLE,
    MODE,
    GAME
}

[Serializable]
public struct SceneData
{
    public GameObject scene_prefab_;
    public SceneType type_;
}