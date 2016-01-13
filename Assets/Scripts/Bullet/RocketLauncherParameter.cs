using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LitJson;
using System;

public class RocketLauncherParameter : BaseParameter
{

    [SerializeField]
    string JSON_FILE_NAME = "";

    public override string  GetName(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
            rocket_launcher_parameter_[id].Name : ErrorMessageString(id);
    }

    public override string GetExplanatoryText(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].ExplanatoryText : ErrorMessageString(id);

    }

    public override float GetAttackPower(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].AttackPower : ErrorMessageFloat(id);
    }

    public float GetBulletMaxRange(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].BulletMaxRange : ErrorMessageFloat(id);
    }

    public float GetExplosiveRange(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].ExplosiveRange : ErrorMessageFloat(id);
    }


    public override int GetBulletsNumber(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].BulletsNumber : ErrorMessageInt(id);

    }

    public override float GetBulletSpeed(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].BulletSpeed : ErrorMessageFloat(id);

    }

    public override float GetReloadTime(int id)
    {
        return rocket_launcher_parameter_.ContainsKey(id) ?
    rocket_launcher_parameter_[id].ReloadTime : ErrorMessageFloat(id);

    }

    float ErrorMessageFloat(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return 0.0f;
    }

    int ErrorMessageInt(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return 0;
    }


    string ErrorMessageString(int id)
    {
        Debug.Log("ID：" + id.ToString() + "は存在しません");
        return "error";
    }

    void Awake()
    {
        JsonMapper.RegisterExporter<float>((obj, writer) => writer.Write(Convert.ToDouble(obj)));

        var json_text = File.ReadAllText(Utility.JSON_PATH + JSON_FILE_NAME);
        var json_data = JsonMapper.ToObject(json_text);
        var parameters = json_data["WeaponRocketLauncherParameter"];

        for (var i = 0; i < parameters.Count; ++i)
        {
            WeaponRocketLauncherParameter temp_rocket_launcher_parameter_;

            temp_rocket_launcher_parameter_.ID = (int)parameters[i]["ID"];
            temp_rocket_launcher_parameter_.Name = (string)parameters[i]["Name"];
            temp_rocket_launcher_parameter_.AttackPower = (float)(double)parameters[i]["AttackPower"];
            temp_rocket_launcher_parameter_.BulletMaxRange = (float)(double)parameters[i]["BulletMaxRange"];
            temp_rocket_launcher_parameter_.ExplosiveRange = (float)(double)parameters[i]["ExplosiveRange"];
            temp_rocket_launcher_parameter_.BulletsNumber = (int)parameters[i]["BulletsNumber"];
            temp_rocket_launcher_parameter_.BulletSpeed = (float)(double)parameters[i]["BulletSpeed"];
            temp_rocket_launcher_parameter_.ReloadTime = (float)(double)parameters[i]["ReloadTime"];
            temp_rocket_launcher_parameter_.ExplanatoryText = (string)parameters[i]["ExplanatoryText"];


            rocket_launcher_parameter_.Add(temp_rocket_launcher_parameter_.ID, temp_rocket_launcher_parameter_);

        }

    }

    struct WeaponRocketLauncherParameter
    {
        public int ID;
        public string Name;
        public float AttackPower;
        public float BulletMaxRange;
        public float ExplosiveRange;
        public int BulletsNumber;
        public float BulletSpeed;
        public float ReloadTime;
        public string ExplanatoryText;
    }

    Dictionary<string, List<WeaponRocketLauncherParameter>> json_ = new Dictionary<string, List<WeaponRocketLauncherParameter>>();
    Dictionary<int, WeaponRocketLauncherParameter> rocket_launcher_parameter_ = new Dictionary<int, WeaponRocketLauncherParameter>();

}