using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("box"))
        {
            Destroy(collision.gameObject);
            ObjectPooler.Instance.poolDictionary["Bullets_Default"].Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            
            ObjectPooler.Instance.poolDictionary["Bullets_Default"].Enqueue(this.gameObject);
            this.gameObject.SetActive(false);
        }

        /*  else
          {
              if (collision.gameObject.CompareTag("ground"))
              {
                  Destroy(this.gameObject);
                  ObjectPooler.Instance.poolDictionary["Bullets_Default"].Enqueue(this.gameObject);
                  this.gameObject.SetActive(false);
              }
          }*/



    }





}
