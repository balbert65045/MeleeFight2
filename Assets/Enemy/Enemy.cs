using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour {

    public Slider HealthSlider;
    CombatController combatController;
    float AttackTime = 3;
    float TimeSinceLastAttack = 0;

    public CombatController.ActionDirection AnticipateAttackDirection;

	// Use this for initialization
	void Start () {
        combatController = GetComponent<CombatController>();
        ChoseDefence();
    }
	
	// Update is called once per frame
	void Update () {

        //// Check to Attack
        if (Time.time > TimeSinceLastAttack + AttackTime)
        {
            TimeSinceLastAttack = Time.time;
            //ChoseDefence();
            Attack();
        }
    }

    void ChoseDefence()
    {
        int AnticaptionAtackIndex = Random.Range(1, 4);
        switch (AnticaptionAtackIndex)
        {
            case 1:
                AnticipateAttackDirection = CombatController.ActionDirection.ActionLeft;
                break;
            case 2:
                AnticipateAttackDirection = CombatController.ActionDirection.ActionOverhead;
                break;
            case 3:
                AnticipateAttackDirection = CombatController.ActionDirection.ActionRight;
                break;
        }
    }


    void Attack()
    {
        combatController.SetBlocking(false);
        CombatController.ActionDirection AttackDirection = CombatController.ActionDirection.ActionOverhead;
        int AttackDirectionIndex = Random.Range(1, 4);
        switch (AttackDirectionIndex)
        {
            case 1:
                AttackDirection = CombatController.ActionDirection.ActionLeft;
                break;
            case 2:
                AttackDirection = CombatController.ActionDirection.ActionOverhead;
                break;
            case 3:
                AttackDirection = CombatController.ActionDirection.ActionRight;
                break;
        }


        combatController.Action(AttackDirection);
    }

    public void AttackedFrom(CombatController.ActionDirection PlayerAttackDirection)
    {
        Debug.Log(PlayerAttackDirection);
        Debug.Log(AnticipateAttackDirection);
        if (PlayerAttackDirection == CombatController.ActionDirection.ActionRight &&
            AnticipateAttackDirection == CombatController.ActionDirection.ActionLeft)
        {
            combatController.SetBlocking(true);
            combatController.Action(AnticipateAttackDirection);
        }
        else if(PlayerAttackDirection == CombatController.ActionDirection.ActionLeft &&
            AnticipateAttackDirection == CombatController.ActionDirection.ActionRight)
        {
            combatController.SetBlocking(true);
            combatController.Action(AnticipateAttackDirection);
        }
        else if (PlayerAttackDirection == CombatController.ActionDirection.ActionOverhead &&
            AnticipateAttackDirection == CombatController.ActionDirection.ActionOverhead)
        {
            combatController.SetBlocking(true);
            combatController.Action(AnticipateAttackDirection);
        }

    } 

    public void TakeDamage(int damage)
    {
        combatController.Hit();
        Debug.Log(this.name + " is taking damage");
        HealthSlider.value -= damage;
    }
}
