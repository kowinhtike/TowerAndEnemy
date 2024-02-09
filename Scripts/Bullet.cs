using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private GameObject target;

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }

    void Start()
    {
        Destroy(gameObject,8);
    }

    void Update()
    {

        //default is no need to added vector3

        Vector3 direction = (target.transform.position - transform.position + new Vector3(0,3,0)).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
