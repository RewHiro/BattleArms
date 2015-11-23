using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LitJson;
using System;

public class AirFrameParameter : MonoBehaviour
{

    [SerializeField]
    string JSON_FILE_NAME = "";

    public float GetMass(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].Mass : ErrorMessageFloat(id);
    }

    public float GetDrag(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].Drag : ErrorMessageFloat(id);
    }

    public float GetMoveSpeed(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].MoveSpeed : ErrorMessageFloat(id);
    }

    public float GetSwingSpeed(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].SwingSpeed : ErrorMessageFloat(id);
    }

    public float GetBoostPower(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].BoostPower : ErrorMessageFloat(id);
    }

    public float GetJumpPower(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].JumpPower : ErrorMessageFloat(id);
    }

    public float GetMaxBoostValue(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].MaxBoostValue : ErrorMessageFloat(id);
    }

    public float GetMaxHP(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].MaxHP : ErrorMessageFloat(id);
    }

    public float GetArmorValue(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].ArmorValue : ErrorMessageFloat(id);
    }

    public string GetName(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].Name : ErrorMessageString(id);
    }

    public string GetExplanatoryText(int id)
    {
        return parameters_.ContainsKey(id) ?
            parameters_[id].ExplanatoryText : ErrorMessageString(id);
    }

    void Awake()
    {
        JsonMapper.RegisterExporter<float>((obj, writer) => writer.Write(Convert.ToDouble(obj)));

        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        var json_data = JsonMapper.ToObject(json_text);
        var parameters = json_data["Parameters"];


        for (var i = 0; i < parameters.Count; i++)
        {
            Parameter temp_parameter;

            temp_parameter.ID = (int)parameters[i]["ID"];
            temp_parameter.Mass = (float)(double)parameters[i]["Mass"];
            temp_parameter.Drag = (float)(double)parameters[i]["Drag"];
            temp_parameter.MoveSpeed = (float)(double)parameters[i]["MoveSpeed"];
            temp_parameter.SwingSpeed = (float)(double)parameters[i]["SwingSpeed"];
            temp_parameter.BoostPower = (float)(double)parameters[i]["BoostPower"];
            temp_parameter.JumpPower = (float)(double)parameters[i]["JumpPower"];
            temp_parameter.MaxBoostValue = (float)(double)parameters[i]["MaxBoostValue"];
            temp_parameter.MaxHP = (float)(double)parameters[i]["MaxHP"];
            temp_parameter.ArmorValue = (float)(double)parameters[i]["ArmorValue"];
            temp_parameter.Name = (string)parameters[i]["Name"];
            temp_parameter.ExplanatoryText = (string)parameters[i]["ExplanatoryText"];

            parameters_.Add(temp_parameter.ID, temp_parameter);
            parameters_test_.Add(temp_parameter);
        }

        json_.Add("Parameters", parameters_test_);

        string test = JsonMapper.ToJson(json_);

        Debug.Log(test);
    }

    // いい方法が思いつかない……
    float ErrorMessageFloat(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return 0.0f;
    }

    string ErrorMessageString(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return "error";
    }

    struct Parameter
    {
        public int ID;
        public float Mass;
        public float Drag;
        public float MoveSpeed;
        public float SwingSpeed;
        public float BoostPower;
        public float JumpPower;
        public float MaxBoostValue;
        public float MaxHP;
        public float ArmorValue;
        public string Name;
        public string ExplanatoryText;
    }


    Dictionary<string, List<Parameter>> json_ = new Dictionary<string, List<Parameter>>();
    List<Parameter> parameters_test_ = new List<Parameter>();
    Dictionary<int, Parameter> parameters_ = new Dictionary<int, Parameter>();

}

