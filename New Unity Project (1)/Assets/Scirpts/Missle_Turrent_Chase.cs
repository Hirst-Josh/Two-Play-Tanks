using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle_Turrent_Chase : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.ShootTarget();
        tankfsm.Battelinfo();
        tankfsm.shootstate = true;
        MissleTurrent ai = animator.gameObject.GetComponentInChildren<MissleTurrent>();
        ai.shoot = true;
        ai.shootstart();
    }
  



    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        MissleTurrent ai = animator.gameObject.GetComponentInChildren<MissleTurrent>();
        tankfsm.shootstate = false;
        tankfsm.BattleInfoEnd();
        tankfsm.shootend();
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
