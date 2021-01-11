using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrent_off : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.BattleInfoEnd();
        if (animator.gameObject.GetComponentInChildren<AiTurrent>() != null)
        {
            AiTurrent ai = animator.gameObject.GetComponentInChildren<AiTurrent>();
            ai.shoot = false;
            ai.shootend();
            if (animator.gameObject.GetComponentInChildren<supportTurrent>() != null)
            {
                supportTurrent supportTurrent = animator.gameObject.GetComponentInChildren<supportTurrent>();
                supportTurrent.shoot = false;
                supportTurrent.shootend();
            }
        }
        if (animator.gameObject.GetComponentInChildren<MissleTurrent>() != null)
        {
            MissleTurrent missleTurrent = animator.GetComponentInChildren<MissleTurrent>();
            missleTurrent.shoot = false;
            missleTurrent.shootend();
        }
        if (animator.gameObject.GetComponentInChildren<AITurrentLight>() != null)
        {
            AITurrentLight aITurrentLight = animator.gameObject.GetComponent<AITurrentLight>();
            aITurrentLight.shoot = false;
            aITurrentLight.shootend();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
