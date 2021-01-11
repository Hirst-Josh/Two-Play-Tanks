using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Tankette : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.ShootTarget();
        tankfsm.shootstate = true;
        AITurrentLight ai = animator.gameObject.GetComponentInChildren<AITurrentLight>();
        ai.shoot = true;
        ai.shootstart();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.shootstate = false;
        AITurrentLight ai = animator.gameObject.GetComponentInChildren<AITurrentLight>();
        ai.shoot = false;
        ai.shootend();
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
