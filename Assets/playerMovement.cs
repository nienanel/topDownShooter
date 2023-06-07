using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;
    

    public Vector3 positionX;
    public Vector3 positionZ;
    private Quaternion targetRotation;

    public gunManager gun;

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gun.Fire();
        }

        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized;
        rb.velocity = movement * moveSpeed;

        if (movement != Vector3.zero)
        {
            Vector3 aimDirection = new Vector3(moveX, 0f, moveZ);
            targetRotation = Quaternion.LookRotation(aimDirection);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); ;
    }
}
