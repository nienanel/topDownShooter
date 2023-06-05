using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementZ = Input.GetAxis("Vertical");

        moveInput = new Vector3(movementX, 0f, movementZ);
        //moveVelocity = transform.forward * movementSpeed * moveInput.sqrMagnitude;

    }

    private void FixedUpdate()
    {
        Vector3 targetDirection = moveInput.normalized;
        moveVelocity = targetDirection * movementSpeed;

        rb.velocity = moveVelocity;
        if (targetDirection.magnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            rb.rotation = Quaternion.Lerp(rb.rotation, targetRotation, 0.1f);
        }
    }

}


/* insania balas con tiempo entre las balas y usar destoy para que cada cierto tiemp en el uptade se destruyan las balas disparadas*/