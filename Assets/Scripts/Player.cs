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
        // // Mouse to rotation
        // Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.AngleAxis(angle, Vector3.down);

        //Debug.Log(dir);

        // Rotation to movement direction
        float horizontal = -1 * Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        moveDirection = transform.forward * horizontal + transform.right * vertical;
        rb.AddForce(moveDirection.normalized * 5f, ForceMode.Force);
        // if (mouseClicked) {
        //     energyCounter++;
        // }
        // if (mouseReleased) {
        //     Debug.Log("Zo'n grote vuurbal jonguh");
        // }
    }

    void FixedUpdate()
    {
    }
}
