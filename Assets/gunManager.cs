using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform gun;
    public float firePower = 20f;

    private Rigidbody[] bulletArray = new Rigidbody[6];
    private int bulletsShot = 0;
    private float shootInterval = 3f;
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && bulletsShot < bulletArray.Length)
        {
          Fire();
        }

        if (bulletsShot == bulletArray.Length && elapsedTime >= shootInterval)
        {
            DestroyBullets();
            elapsedTime = 0f;
        }

    }

    public void Fire()
    {
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(bullet, gun.position, Quaternion.Euler(90f, 0f, 0f));
        bulletInstance.AddForce(gun.forward * 100 * firePower);

        bulletArray[bulletsShot] = bulletInstance;
        bulletsShot++;
    }

    void DestroyBullets()
    {
        for (int i = 0; i < bulletArray.Length; i++)
        {
            if (bulletArray[i] != null)
            {
                Destroy(bulletArray[i].gameObject);
            }
        }

        bulletsShot = 0;
    }
}
