using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    public static AnimPlayer instance;
    public Player player;
    public Animator anim;
    public GameObject pokeball;
    void Awake()
    {
        instance = this;
        player = GetComponent<Player>();
        pokeball.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (!player.canJump)
        {
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);

            if (player.rb.velocity.magnitude > 1 && player.isGrounded)
            //he puesto 1 para que no se active la animacion al girar
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

        if (!Camera.instance.aiming && anim.GetBool("isAiming"))
        {
            anim.SetLayerWeight(1, 1);
            StartCoroutine(DisableLayer());
        }
    }
    IEnumerator DisableLayer()
    {
        float length = anim.GetCurrentAnimatorStateInfo(1).length;
        yield return new WaitForSeconds(length);
        anim.SetLayerWeight(1, 0);
    }
}
