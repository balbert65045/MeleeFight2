using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

    // Use this for initialization
    Animator m_Animator;
    public bool Blocking = false;
    public enum ActionDirection { ActionRight, ActionLeft, ActionOverhead }

    public enum ActionState { AttackRightState, AttackLeftState, AttackOverheadState, IdleState }
    public ActionState currentActionState = ActionState.IdleState;

    public LayerMask Hitlayer;
    public CombatController Opponent;

    void Start () {
        m_Animator = GetComponent<Animator>();
        currentActionState = ActionState.IdleState;
    }
	
	// Update is called once per frame
    public void Hit()
    {
        //Debug.Log("PlayerHit");
        m_Animator.SetTrigger("Hit");
    }

    public void Attack(ActionDirection currentAction)
    {
        switch (currentAction)
        {
            case ActionDirection.ActionRight:
                m_Animator.SetTrigger("ActionRight");
                break;
            case ActionDirection.ActionLeft:
                m_Animator.SetTrigger("ActionLeft");
                break;
            case ActionDirection.ActionOverhead:
                m_Animator.SetTrigger("ActionOverhead");
                break;
        }
    }

    public void EnableAttack(ActionState aState)
    {
        GetComponentInChildren<Weapon>().SetAttackState(true);
        currentActionState = aState;
    }

    public void DisableAttack()
    {
        GetComponentInChildren<Weapon>().SetAttackState(false);
        currentActionState = ActionState.IdleState;
    }

    public void SetBlockState(ActionState aState)
    {
        currentActionState = aState;
    }

    public void CheckForBlock(ActionState aState)
    {
        Debug.Log(Opponent.currentActionState);
        Debug.Log(currentActionState);
        if (Opponent.Blocking && Opponent.currentActionState == currentActionState)
        {
            AttackInterrupt();
        }

        //RaycastHit Hit;
        
        //if (Physics.Raycast(transform.position + Vector3.forward*.5f, Vector3.forward, out Hit, 20f, Hitlayer))
        //{
        //    CombatController OpponentCombatController = Hit.transform.GetComponent<CombatController>();
        //    Debug.Log(OpponentCombatController.currentActionState);
        //    Debug.Log(currentActionState);
        //    if (OpponentCombatController.Blocking && OpponentCombatController.currentActionState == currentActionState)
        //    {
        //        Debug.Log(OpponentCombatController.currentActionState);
        //        Debug.Log(currentActionState);
        //        AttackInterrupt();
        //    }
        //}
        //else
        //{
        //    Debug.Log("NothingHit");
        //}
    }

    public void AttackInterrupt()
    {
        m_Animator.SetTrigger("AttackInterrupt");
    }

    public void ToggleBlocking()
    {
        if (Blocking)
        {
            Blocking = false;
            m_Animator.SetBool("Blocking", Blocking);
        }
        else
        {
            Blocking = true;
            m_Animator.SetBool("Blocking", Blocking);
        }
    }

}
