using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEnemy : MonoBehaviour
{
    public static AnimEnemy instance;
    public Enemy enemy;
    public Animator anim;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isWalking", enemy.agent.speed != 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemy.cooldown <= 0)
        {
            anim.SetTrigger("Punch");
            enemy.cooldown = 2;
        }
    }
}
