using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    float lifeTime;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        EndOfLifeTime();
    }
    private void OnEnable()
    {
        lifeTime = 1;
        rb.velocity = Vector3.zero;
        transform.rotation = Player.instance.weapon.transform.rotation;
        rb.velocity = transform.forward * 50;
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
            collision.gameObject.GetComponent<IDamage>().TakeDamage(2);
            Player.instance.Push(gameObject);
        }
    }
}
