using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
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
       GameObject bullets =  ObjectPooler.Instance.SpawnFromPool("Bullets_Default", firePoint.position, Quaternion.identity);
       bullets.GetComponent<Rigidbody2D>().AddForce(firePoint.right * shoot_Force);
    }
}
