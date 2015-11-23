using UnityEngine;
using System.IO;

public class Identificationer : MonoBehaviour
{

    [SerializeField]
    string JSON_FILE_NAME = "";

    public int id { get { return id_; } }

    public void ChangeID()
    {
        ReadJson();
    }

    void Awake()
    {
        ReadJson();
    }

    void ReadJson()
    {
        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        JsonNode json = JsonNode.Parse(json_text);
        id_ = (int)json["Player"].Get<long>();
        if (id_ < 0) id_ = 0;
    }

    [SerializeField]
    int id_ = 0;
}
