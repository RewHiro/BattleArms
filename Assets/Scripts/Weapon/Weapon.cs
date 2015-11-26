using UnityEngine;

public class Weapon : MonoBehaviour
{
    BulletCreater bullet_creater_ = null;

    virtual public void OnAttack() { }
    virtual public void OnNotAttack() { }

    protected int id_ = 0;
    protected string name_ = "";
    protected string explanatory_text_ = "";
}