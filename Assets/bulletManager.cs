using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletManager : MonoBehaviour
{
       public GameObject objectToDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("EnemyCollision"))
        {
            Destroy(collision.gameObject);
        }
    }

}

