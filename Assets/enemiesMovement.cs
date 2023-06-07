using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesMovement : MonoBehaviour
{
    private Transform target; // Transform del objetivo (por ejemplo, el jugador)
    public float moveSpeed = 5f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    private void MoveTowardsTarget()
    {
        Vector3 targetPosition = target.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        MoveTowardsTarget();
    }
}



