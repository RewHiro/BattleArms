using UnityEngine;
using UnityEngine.VR;

public class CameraMover : MonoBehaviour
{
    readonly Vector2 LIMIT_SLOPE = new Vector2(20.0f, 80.0f);

    [SerializeField]
    float SWING_SPEED = 5.0f;

    void Update()
    {
        if (VRDevice.isPresent) return;
        var mouse_x = Input.GetAxis("Mouse X");
        var mouse_y = Input.GetAxis("Mouse Y");

        if (mouse_x == 0.0f && mouse_y == 0.0f) return;

        var euler_angles = gameObject.transform.localEulerAngles;
        euler_angles.y += mouse_x * SWING_SPEED;
        euler_angles.x += -mouse_y * SWING_SPEED;

        euler_angles = ConvertPlsuMinus180(euler_angles);

        euler_angles.x = Mathf.Clamp(euler_angles.x, -LIMIT_SLOPE.x, LIMIT_SLOPE.x);

        euler_angles = Convert0To360(euler_angles);

        var euler_angles_y = gameObject.transform.localEulerAngles.y;
        euler_angles_y += mouse_x * SWING_SPEED;
        euler_angles.y = Mathf.Clamp(euler_angles_y, -120, 240);

        gameObject.transform.localEulerAngles = euler_angles;

    }


    float ConvertPlsuMinus180(float euler_angle)
    {
        return euler_angle > 180 ?
            euler_angle - 360 : euler_angle;
    }

    Vector3 ConvertPlsuMinus180(Vector3 euler_angles)
    {
        var temp_euler_angles = Vector3.zero;

        temp_euler_angles.x = ConvertPlsuMinus180(euler_angles.x);
        temp_euler_angles.y = ConvertPlsuMinus180(euler_angles.y);
        temp_euler_angles.z = ConvertPlsuMinus180(euler_angles.z);

        return temp_euler_angles;
    }

    float Convert0To360(float euler_angle)
    {
        return euler_angle < 0 ?
            euler_angle + 360 : euler_angle;
    }

    Vector3 Convert0To360(Vector3 euler_angles)
    {
        var temp_euler_angles = Vector3.zero;

        temp_euler_angles.x = Convert0To360(euler_angles.x);
        temp_euler_angles.y = Convert0To360(euler_angles.y);
        temp_euler_angles.z = Convert0To360(euler_angles.z);

        return temp_euler_angles;
    }
}
