using UnityEngine;
using System.Collections;

public class HPManager : MonoBehaviour
{
    public float hp { private set; get; }

    void Start()
    {
        var id = GetComponent<Identificationer>().id;
        hp = FindObjectOfType<AirFrameParameter>().GetMaxHP(id);
    }

    void OnCollisionEnter(Collision collision)
    {
        //　ダメージ処理
    }
}
