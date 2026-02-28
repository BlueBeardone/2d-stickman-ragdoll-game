using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float targetRotation;
    [SerializeField] private float force;

    public void Update()
    {
        rb.MoveRotation(Mathf.LerpAngle(rb.rotation, targetRotation, force * Time.fixedDeltaTime));
    }
}
