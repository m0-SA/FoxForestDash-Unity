using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectilePosition;

    [SerializeField]
    float fireRate = 1f,
        speed = 10f;

    float nextFire = 0.0f;

    void Update()
    {
 
    if (Time.time > nextFire)
        {
             nextFire = Time.time + fireRate;
            fireProjectile();
        }
    }


    void fireProjectile()
    {
        GameObject instance = Instantiate(projectile, projectilePosition.position, projectilePosition.rotation);
        instance.GetComponent<projectile>().speed = speed;
    }
}

