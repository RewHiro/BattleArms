using UnityEngine;
using System.Collections;

public class RotationTest : MonoBehaviour
{

    [SerializeField]
    float spedd = 100.0f;
    void Update()
    {
        transform.Rotate(spedd, 0, 0);
    }
}