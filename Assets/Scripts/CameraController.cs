using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float turnSpeed =90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 direction = Vector3.zero;
        float turn = 0;
        if (Keyboard.current.wKey.isPressed)
        {
            direction += transform.forward;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            direction -= transform.forward;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            direction -= transform.right;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            direction += transform.right;
        }

        if (Keyboard.current.qKey.isPressed)
        {
            turn -= 1;
        }

        if (Keyboard.current.eKey.isPressed)
        {
            turn += 1;
        }

        transform.position += direction * Time.deltaTime * panSpeed;
        transform.Rotate(Vector3.up,  Time.deltaTime * turn * turnSpeed, Space.World );
    }
}
