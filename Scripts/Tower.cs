using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    private bool isReach = false;
    private GameObject generatedObj;

    void Start()
    {
        InvokeRepeating("Shoot", 1.5f, 1.5f);
       
    }

    void Update()
    {
    
    }

    void Shoot()
    {
        if (isReach)
        {
            Vector3 place = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
            // Instantiate a bullet and set its direction towards the target
            GameObject bullet = Instantiate(bulletPrefab, place, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.SetTarget(generatedObj); // Assuming your Bullet script has a method to set the target
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isReach = true;
            generatedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isReach = false;
            generatedObj = null;
        }
    }



}
