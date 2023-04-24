using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    Animator animator;
    EnemyController enemyController;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyController>();
    }

    void Update()
    {
        if (gameObject.CompareTag("Zombie"))
        {
            if (enemyController.touchedPlayer)
            {
                animator.SetBool("isWalk", false);
                animator.SetBool("isAttack", true);
            }
            else
            {
                animator.SetBool("isWalk", true);
                animator.SetBool("isAttack", false);
            }
        }

        if (gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isMove",true);
            }
            else
            {
                animator.SetBool("isMove", false);
            }

            if (Input.GetMouseButton(0))
            {
                animator.SetBool("isFire", true);
            }
            else
            {
                animator.SetBool("isFire", false);
            }
        }
    }
}
