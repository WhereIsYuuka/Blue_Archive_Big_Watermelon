using UnityEngine;

public class GyroscopeManager : MonoBehaviour
{
    private Gyroscope gyro;

    void Awake()
    {
        if(Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        if(gyro != null && gyro.enabled)
        {
            Vector3 gravity = gyro.gravity;
            Physics.gravity = new Vector3(gravity.x, gravity.y, gravity.z) * 9.81f; // Adjust gravity based on gyroscope data
        }
    }
}