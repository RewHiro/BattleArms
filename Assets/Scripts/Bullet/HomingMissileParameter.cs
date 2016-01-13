using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using LitJson;
using System;

public class HomingMissileParameter : BaseParameter
{

    [SerializeField]
    string JSON_FILE_NAME = "";

    public override string GetName(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
            homing_missile_parameter_[id].Name : ErrorMessageString(id);
    }

    public override string GetExplanatoryText(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].ExplanatoryText : ErrorMessageString(id);

    }

    public override float GetAttackPower(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].AttackPower : ErrorMessageFloat(id);
    }

    public float GetBulletMaxRange(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].BulletMaxRange : ErrorMessageFloat(id);
    }

    public float GetExplosiveRange(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].ExplosiveRange : ErrorMessageFloat(id);
    }


    public override int GetBulletsNumber(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].BulletsNumber : ErrorMessageInt(id);

    }

    public override float GetBulletSpeed(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].BulletSpeed : ErrorMessageFloat(id);

    }

    public override float GetReloadTime(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].ReloadTime : ErrorMessageFloat(id);

    }

    public float GetLockOnTime(int id)
    {
        return homing_missile_parameter_.ContainsKey(id) ?
    homing_missile_parameter_[id].LockOnTime : ErrorMessageFloat(id);

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
        var parameters = json_data["WeaponHomingMissileParameter"];

        for (var i = 0; i < parameters.Count; ++i)
        {
            WeaponHomingMissileParameter temp_homing_missile_parameter;

            temp_homing_missile_parameter.ID = (int)parameters[i]["ID"];
            temp_homing_missile_parameter.Name = (string)parameters[i]["Name"];
            temp_homing_missile_parameter.AttackPower = (float)(double)parameters[i]["AttackPower"];
            temp_homing_missile_parameter.BulletMaxRange = (float)(double)parameters[i]["BulletMaxRange"];
            temp_homing_missile_parameter.ExplosiveRange = (float)(double)parameters[i]["ExplosiveRange"];
            temp_homing_missile_parameter.BulletsNumber = (int)parameters[i]["BulletsNumber"];
            temp_homing_missile_parameter.BulletSpeed = (float)(double)parameters[i]["BulletSpeed"];
            temp_homing_missile_parameter.ReloadTime = (float)(double)parameters[i]["ReloadTime"];
            temp_homing_missile_parameter.LockOnTime = (float)(double)parameters[i]["LockOnTime"];
            temp_homing_missile_parameter.ExplanatoryText = (string)parameters[i]["ExplanatoryText"];


            homing_missile_parameter_.Add(temp_homing_missile_parameter.ID, temp_homing_missile_parameter);

        }

    }

    struct WeaponHomingMissileParameter
    {
        public int ID;
        public string Name;
        public float AttackPower;
        public float BulletMaxRange;
        public float ExplosiveRange;
        public int BulletsNumber;
        public float BulletSpeed;
        public float ReloadTime;
        public float LockOnTime;
        public string ExplanatoryText;
    }

    Dictionary<string, List<WeaponHomingMissileParameter>> json_ = new Dictionary<string, List<WeaponHomingMissileParameter>>();
    Dictionary<int, WeaponHomingMissileParameter> homing_missile_parameter_ = new Dictionary<int, WeaponHomingMissileParameter>();

}