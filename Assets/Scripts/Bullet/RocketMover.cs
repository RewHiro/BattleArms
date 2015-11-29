using UnityEngine;

public class RocketMover : MonoBehaviour
{
    Rigidbody rigidbody_ = null;

    float acceleration_ = 0.0f;

    void Start()
    {
        rigidbody_ = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        acceleration_ += Time.deltaTime * 10000;
        rigidbody_.AddForce(transform.forward * acceleration_, ForceMode.Acceleration);
    }
}
