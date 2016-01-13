using UnityEngine;
using System.Collections;

public class BaseParameter : MonoBehaviour
{

    public virtual string GetName(int id) { return Name; }

    public virtual float GetAttackPower(int id) { return AttackPower; }

    public virtual int GetBulletsNumber(int id) { return BulletsNumber; }

    public virtual float GetBulletSpeed(int id){ return BulletSpeed; }

    public virtual float GetReloadTime(int id) { return ReloadTime; }

    public virtual string GetExplanatoryText(int id) { return ExplanatoryText; }

        public int ID;
        public string Name;
        public float AttackPower;
        public int BulletsNumber;
        public float BulletSpeed;
        public float ReloadTime;
        public string ExplanatoryText;
 
}
