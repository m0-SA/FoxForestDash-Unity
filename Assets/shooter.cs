using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooter : MonoBehaviour
{

    public GameObject projectile;
    public Transform projectilePosition;
    


    [SerializeField]
    float rotation = 0f;

    [SerializeField]
    float fireRate = 1f;

    float nextFire = 0.0f;

    // Start is called before the first frame update
    void Start()
    {

    }


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
        Instantiate(projectile, projectilePosition.position, projectilePosition.rotation);
    }
}

