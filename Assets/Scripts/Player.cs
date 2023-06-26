using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    public Vector3 moveDirection;
    //public Vector3 dir;
    private bool enableMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation to movement direction
        float horizontal = -1 * Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = transform.forward * horizontal + transform.right * vertical;
        rb.AddForce(moveDirection.normalized * 5 * .5f, ForceMode.Force);
    }

    void FixedUpdate()
    {
    }
}
