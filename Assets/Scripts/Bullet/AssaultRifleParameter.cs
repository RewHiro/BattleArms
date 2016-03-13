using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LitJson;
using System;

public class AssaultRifleParameter : BaseParameter
{

    [SerializeField]
    string JSON_FILE_NAME = "";

    public override string GetName(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
            gatling_gun_parameters_[id].Name : ErrorMessageString(id);
    }

    public override string GetExplanatoryText(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].ExplanatoryText : ErrorMessageString(id);

    }

    public override float GetAttackPower(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].AttackPower : ErrorMessageFloat(id);
    }

    public float GetMaxAttackPowerRange(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].MaxAttackPowerRange : ErrorMessageFloat(id);
    }

    public float GetMinAttackPowerRange(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].MinAttackPowerRange : ErrorMessageFloat(id);
    }

    public float GetFiringSpeed(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].FiringSpeed : ErrorMessageFloat(id);
    }

    public override int GetBulletsNumber(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].BulletsNumber : ErrorMessageInt(id);

    }

    public override float GetBulletSpeed(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].BulletSpeed : ErrorMessageFloat(id);

    }

    public override float GetReloadTime(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].ReloadTime : ErrorMessageFloat(id);

    }

    public float GetVariability(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].Variability : ErrorMessageFloat(id);

    }

    public int GetHitAccuracy(int id)
    {
        return gatling_gun_parameters_.ContainsKey(id) ?
    gatling_gun_parameters_[id].HitAccuracy : ErrorMessageInt(id);

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
        var parameters = json_data["Parameter"];

        for (var i = 0; i < parameters.Count; ++i)
        {
            WeaponGatlingGunParameter temp_gatling_gun_parameter;

            temp_gatling_gun_parameter.ID = (int)parameters[i]["ID"];
            temp_gatling_gun_parameter.Name = (string)parameters[i]["Name"];
            temp_gatling_gun_parameter.AttackPower = (float)(double)parameters[i]["AttackPower"];
            temp_gatling_gun_parameter.MaxAttackPowerRange = (float)(double)parameters[i]["MaxAttackPowerRange"];
            temp_gatling_gun_parameter.MinAttackPowerRange = (float)(double)parameters[i]["MinAttackPowerRange"];
            temp_gatling_gun_parameter.FiringSpeed = (float)(double)parameters[i]["FiringSpeed"];
            temp_gatling_gun_parameter.BulletsNumber = (int)parameters[i]["BulletsNumber"];
            temp_gatling_gun_parameter.BulletSpeed = (float)(double)parameters[i]["BulletSpeed"];
            temp_gatling_gun_parameter.ReloadTime = (float)(double)parameters[i]["ReloadTime"];
            temp_gatling_gun_parameter.Variability = (float)(double)parameters[i]["Variability"];
            temp_gatling_gun_parameter.HitAccuracy = (int)parameters[i]["HitAccuracy"];
            temp_gatling_gun_parameter.ExplanatoryText = (string)parameters[i]["ExplanatoryText"];

            gatling_gun_parameters_.Add(temp_gatling_gun_parameter.ID, temp_gatling_gun_parameter);

        }

    }

    struct WeaponGatlingGunParameter
    {
        public int ID;
        public string Name;
        public float AttackPower;
        public float MaxAttackPowerRange;
        public float MinAttackPowerRange;
        public float FiringSpeed;
        public int BulletsNumber;
        public float BulletSpeed;
        public float ReloadTime;
        public float Variability;
        public int HitAccuracy;
        public string ExplanatoryText;

    }

    Dictionary<string, List<WeaponGatlingGunParameter>> json_ = new Dictionary<string, List<WeaponGatlingGunParameter>>();
    Dictionary<int, WeaponGatlingGunParameter> gatling_gun_parameters_ = new Dictionary<int, WeaponGatlingGunParameter>();

}
