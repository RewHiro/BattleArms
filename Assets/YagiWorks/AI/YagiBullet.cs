using UnityEngine;

using System.Collections;

public class YagiBullet : MonoBehaviour
{
    [SerializeField]
    float bulletSpeed = 0.0f;


    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletSpeed);
    }
}