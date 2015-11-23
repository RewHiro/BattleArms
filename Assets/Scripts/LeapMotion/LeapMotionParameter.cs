using UnityEngine;
using System.IO;
using LitJson;

public class LeapMotionParameter : MonoBehaviour
{
    [SerializeField]
    string JSON_FILE_NAME = "";

    public bool isDebug
    {
        get; private set;
    }

    public Vector3 getMoveMent
    {
        get; private set;
    }

    public Vector3 getPosition
    {
        get; private set;
    }

    public float getReferencePoint
    {
        get; private set;
    }

    public float getReactionValue
    {
        get; private set;
    }

    public float getReactionBoostValue
    {
        get; private set;
    }

    public float getReactionJumpValue
    {
        get; private set;
    }

    void Awake()
    {
        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        var json_data = JsonMapper.ToObject(json_text);

        isDebug = (bool)json_data["Debug"];

        var move_ment = json_data["Movement"];
        getMoveMent = new Vector3(
            (float)(double)move_ment["X"], 
            (float)(double)move_ment["Y"], 
            (float)(double)move_ment["Z"]);

        var position = json_data["Position"];
        getPosition = new Vector3(
            (float)(double)position["X"],
            (float)(double)position["Y"],
            (float)(double)position["Z"]);

        getReferencePoint = (float)(double)json_data["ReferencePoint"]["X"];
        getReactionValue = (float)(double)json_data["ReactionValue"];
        getReactionBoostValue = (float)(double)json_data["ReactionBoostValue"];
        getReactionJumpValue = (float)(double)json_data["ReactionJumpValue"];
    }


}
