using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float lifeTime = 1;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        EndOfLifeTime();
    }

    void EndOfLifeTime()
    {
        if (lifeTime <= 0)
        {
            Player.instance.Push(gameObject);
        }
        else
        {
            lifeTime -= Time.deltaTime;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<IDamage>().TakeDamage(5);
            Player.instance.Push(gameObject);
        }
    }
}
