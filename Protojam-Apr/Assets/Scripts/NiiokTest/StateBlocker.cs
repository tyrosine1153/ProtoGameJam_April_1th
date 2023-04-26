using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateBlocker : StateMachineBehaviour
{
    public enum TriggerState
    {
        None,
        Hurt,
        Die,
        Roll,
        Shoot,
        Run,
        Gran,
    }

    [SerializeField]
    TriggerState state;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        switch(state)
        {
            case TriggerState.Die:
                animator.SetBool(StringRef.Instance.ID_Die, false);
                break;
            case TriggerState.Hurt:
                animator.SetBool(StringRef.Instance.ID_Hurt, false);
                break;
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateExit(animator, stateInfo, layerIndex);

        switch(state)
        {
            case TriggerState.Roll:
                animator.SetBool(StringRef.Instance.ID_Roll, false);
                break;
            case TriggerState.Shoot:
                animator.SetBool(StringRef.Instance.ID_Shoot, false);
                break;
            case TriggerState.Run:
                animator.SetBool(StringRef.Instance.ID_Run, false);
                break;
            case TriggerState.Gran:
                animator.SetBool(StringRef.Instance.ID_Grab, false);
                break;
        }
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
