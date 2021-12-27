using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bullet_prefab;
    public float shoot_Force= 10;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        } 
    }

    void Shoot()
    {
       GameObject bulletobj =  Instantiate(bullet_prefab, firePoint.position, firePoint.rotation);
        bulletobj.GetComponent<Rigidbody2D>().AddForce(firePoint.right * shoot_Force); 
    }
}
