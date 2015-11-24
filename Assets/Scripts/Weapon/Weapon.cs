using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    virtual public void OnAttack() { }
    virtual public void OnNotAttack() { }

    protected int id_ = 0;
    protected string name_ = "";
    protected string explanatory_text_ = "";
}
