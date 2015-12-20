using UnityEngine;

public class UIRotater : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.LookAt(
            Camera.main.transform);
        gameObject.transform.Rotate(new Vector3(0, 180, 0));
    }
}
