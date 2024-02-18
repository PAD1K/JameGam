using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActiveBattleState : StateMachineBehaviour
{
   [SerializeField] private string[] _enemySpecialAttacks;
   [SerializeField] private float _enemyAttackTimeMultiplier;

   public delegate void EnemyActiveStateChange();
    public static event EnemyActiveStateChange OnEnemyHealthLowered;

    private EnemyContoller _enemyController;
    private float _enemyAttackTime = 0.0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       _enemyController = animator.GetComponentInParent<EnemyContoller>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if(_enemyController.Health <= animator.GetInteger("EnemyHealth") - 25)
      {
         animator.SetBool("IsActive", false);
         OnEnemyHealthLowered?.Invoke();
      }
      _enemyAttackTime += Time.deltaTime;
      if(_enemyAttackTime >= _enemyController.AttackTime * _enemyAttackTimeMultiplier)
      {
        EnemyAttackState.AttackPrefab = null;
         //animator.SetTrigger(_enemySpecialAttacks[Random.Range(0,_enemyAttacks.Length)]);
         animator.SetTrigger(_enemySpecialAttacks[0]);
         _enemyAttackTime = 0.0f;
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
