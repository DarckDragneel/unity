using UnityEngine;

public class Player : MonoBehaviour
{
    public float Run = 8f;
    public float rotationSpeed = 250f;
    public Animator an;
    private float x, y;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
        }
    }

    void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, 0, y) * Run;
        Vector3 targetPosition = rb.position + movement * Time.fixedDeltaTime;

        rb.MovePosition(targetPosition);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.RotateTowards(rb.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }

        an.SetFloat("Run.x", x);
        an.SetFloat("Run.y", y);
    }
}
