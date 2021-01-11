using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavier3 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.patrol3();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.patrol3();
    }
}
