using UnityEngine;
using UnityEngine.Networking;

public class Weapon : MonoBehaviour
{

    [SerializeField]
    GameObject arm_ = null;

    virtual public void OnAttack() { }
    virtual public void OnNotAttack() { }

    protected int id_ = 0;
    protected string name_ = "";
    protected string explanatory_text_ = "";
}