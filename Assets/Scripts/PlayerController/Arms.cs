using UnityEngine;
using UnityEngine.InputSystem;

public class Arms : MonoBehaviour
{
    [SerializeField] float speed = 300f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Camera cam;

    private float rotationZ;
    [SerializeField] bool isHolding = false;

    private void Update()
    {
        Vector3 playerPos = new Vector3(cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x, cam.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y, 0);
        Vector3 differance = playerPos - transform.position;
        rotationZ = Mathf.Atan2(differance.x, -differance.y) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        if (isHolding)
        {
            rb.MoveRotation(Mathf.LerpAngle(rb.rotation, rotationZ, speed * Time.fixedDeltaTime));
        }
    }

    public void ControlArm(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            isHolding = true;
        }
        if (context.canceled)
        {
            isHolding = false;
        }


    }
}
