using UnityEngine;

public class EnemyIdleState : StateMachineBehaviour
{
  [SerializeField] private string[] _enemyAttacks;
    private EnemyContoller _enemyController;
    private float _enemyAttackTime = 0.0f;

    private Animator _animator;



    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      _animator = animator;
      _enemyController = animator.GetComponentInParent<EnemyContoller>();
      KeyComponent.OnKeyComponentDestroy += Enrage;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      _enemyAttackTime += Time.deltaTime;
      if(_enemyAttackTime >= _enemyController.AttackTime)
      {
        EnemyAttackState.AttackPrefab = null;
         animator.SetTrigger(_enemyAttacks[Random.Range(0,_enemyAttacks.Length)]);
         //animator.SetTrigger(_enemyAttacks[1]);
         _enemyAttackTime = 0.0f;
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    private void Enrage()
    {
      _animator.SetInteger("EnemyHealth", _enemyController.Health);
      _animator.SetBool("IsActive", true);
    }
}
