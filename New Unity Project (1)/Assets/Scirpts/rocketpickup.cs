using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketpickup : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.RocketPowerUp();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        tankfsm.RocketPowerUpEnd();
    }
}
