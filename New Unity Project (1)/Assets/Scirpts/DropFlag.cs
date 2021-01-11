using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFlag : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Flag Flag = FindObjectOfType<Flag>();
        FlagMaster flagMaster = FindObjectOfType<FlagMaster>();
        Tankfsm tankfsm = animator.gameObject.GetComponent<Tankfsm>();
        Flag.MoveToSpawn();
        animator.SetBool("HasFlag", false);
        flagMaster.SetFlagToFree();
        tankfsm.HasFlag = false;
        tankfsm.CancelInvoke("AttackFlagCarrier");
    }


}
