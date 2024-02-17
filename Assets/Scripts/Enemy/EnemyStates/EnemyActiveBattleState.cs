using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveBattleState : StateMachineBehaviour
{
   [SerializeField] private float _activeMultiplier;
    private EnemyContoller _enemyController;
    private float _enemyAttackTime = 0.0f;
    private float _enemyMoveTime = 0.0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _enemyController = animator.GetComponentInParent<EnemyContoller>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      _enemyAttackTime += Time.deltaTime;
      _enemyMoveTime += Time.deltaTime;
      if(_enemyAttackTime >= _enemyController.AttackTime/_activeMultiplier)
      {
         animator.SetBool("IsAttacking", true);
         _enemyAttackTime = 0.0f;
      }
      if(_enemyMoveTime >= _enemyController.MoveTime/_activeMultiplier)
      {
         animator.SetBool("IsMoving", true);
         _enemyMoveTime = 0.0f;
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
