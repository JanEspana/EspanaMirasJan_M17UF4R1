using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    public Player player;
    public Animator anim;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.rb.velocity.magnitude > 1)
        {
            if (player.speed > 10)
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isWalking", false);
            }
            else
            {
                anim.SetBool("isWalking", true);
                anim.SetBool("isRunning", false);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }
}
