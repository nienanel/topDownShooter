using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform targetToKill;

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = targetToKill.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }
}
