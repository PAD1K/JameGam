using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : StateMachineBehaviour
{
    private EnemyContoller _enemyController;
    private float _enemyMoveTime = 5.0f;
    private float _enemyActiveMoveTime = 3.0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _enemyController = animator.GetComponentInParent<EnemyContoller>();

       if(!animator.GetBool("IsActive"))
        {
            Debug.Log("Enemy Moved");
            _enemyController.MoveTime = _enemyMoveTime;
            animator.SetFloat("MoveTime", _enemyController.MoveTime);
        }
        else
        {
            Debug.Log("Enemy Agro Moved");
            _enemyController.MoveTime = _enemyActiveMoveTime;
            animator.SetFloat("MoveTime", _enemyController.MoveTime);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
