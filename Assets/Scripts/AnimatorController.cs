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
        if (enemyController.touchedPlayer)
        {
            animator.SetBool("isWalk",false);
            animator.SetBool("isAttack", true);
        }
        else
        {
            animator.SetBool("isWalk", true);
            animator.SetBool("isAttack", false);
        }
    }
}
