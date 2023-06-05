using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotiManager : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform gun;

    private Rigidbody[] bulletArray = new Rigidbody[6];
    public float bulletSpeed = 10f;
    private int bulletsShot = 0;
    private float shootInterval = 5f;
    private float timeTroShoot = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeTroShoot += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && bulletsShot < bulletArray.Length)
        {
            ShootingBullets();
        }

        if (bulletsShot == bulletArray.Length && timeTroShoot >= shootInterval)
        {
            DestroyBullets();
            timeTroShoot = 0f;
        }
    }

    void ShootingBullets()
    {
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(bullet, gun.position, Quaternion.Euler(90f,0f,0f)) as Rigidbody;
        bulletInstance.AddForce(gun.forward * 100 * bulletSpeed);

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
