using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float panSpeed = 20f;
    [SerializeField] private float turnSpeed =90f;
    [SerializeField] private float scrollSpeed = .05f;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private float camMin = 5;
    [SerializeField] private float camMax = 40;
    
    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
    }

    void Update()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 direction = transform.right * input.x + transform.forward * input.y;
        float scroll = Mouse.current.scroll.ReadValue().y;
        float turn = 0;
        if (Keyboard.current.qKey.isPressed)
        {
            turn -= 1;
        }

        if (Keyboard.current.eKey.isPressed)
        {
            turn += 1;
        }

        Vector3 futureScroll = mainCamera.transform.position + mainCamera.transform.forward * scrollSpeed * scroll;
        float dist = Vector3.Distance(mainCamera.transform.position + futureScroll,transform.position);
        if (camMin <= dist && dist <= camMax)
        {
            mainCamera.transform.position += mainCamera.transform.forward * scrollSpeed * scroll;
        }

        transform.position += direction * (Time.deltaTime * panSpeed);
        transform.Rotate(Vector3.up,  Time.deltaTime * turn * turnSpeed, Space.World );
    }
}
