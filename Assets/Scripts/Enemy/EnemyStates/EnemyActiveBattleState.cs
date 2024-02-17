using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveBattleState : StateMachineBehaviour
{
    [SerializeField] private float _activeAttackTime;
    [SerializeField] private float _activeMoveTime;
    private EnemyContoller _enemyController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _enemyController = animator.GetComponentInParent<EnemyContoller>();
       //_enemyController.MoveTime = _activeMoveTime;
       //_enemyController.AttackTime = _activeAttackTime;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _enemyController.MoveTime -= Time.deltaTime;
       animator.SetFloat("MoveTime", _enemyController.MoveTime);
       _enemyController.AttackTime -= Time.deltaTime;
       animator.SetFloat("AttackTime", _enemyController.AttackTime);
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
