using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    Rigidbody rb;
    [SerializeField] Transform target;
    Vector3 moveDir;
    [SerializeField] float attackDistance;
    float distanceMoved = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 dir = (target.position - transform.position);
            dir.y = 0;

            bool isInAttackRange = dir.magnitude <= attackDistance;
            if (isInAttackRange)
            {
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                moveDir = dir;
            }
            else
            {
                // Change direction after walking some distance
                if (distanceMoved >= 30)
                {
                    float angle = Random.Range(-180, 180);
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                    distanceMoved = 0;
                }
                moveDir = transform.forward;
            }
        }
    }
    void FixedUpdate()
    {
        if (target)
        {
            float actualMoveSpeed = moveSpeed * 4f;
            distanceMoved += actualMoveSpeed;
            rb.AddForce(moveDir * actualMoveSpeed, ForceMode.Force);
        }
    }
}
