using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float power = .2f;
    private bool Shake_Camera;
    Vector3 start_Pos;
    float duration, initialDuration = .2f;

    public bool ShakeCamera
    {
        get {  return Shake_Camera; }
        set { Shake_Camera = value; }
    }
    private void Start()
    {
        start_Pos = transform.position;
        duration = initialDuration;
    }

    void Update()
    {
        ShakeCam();
    }

    void ShakeCam()
    {
        if (Shake_Camera)
        {
            if (duration > 0)
            {
                transform.position = start_Pos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime;
            }
            else
            {
                ShakeCamera = false;
                transform.position = start_Pos;
                duration = initialDuration;
            }
        }
    }
}
