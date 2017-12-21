using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour {

    public Slider HealthSlider;
    CombatController combatController;
    float AttackTime = 3;
    float TimeSinceLastAttack = 0;

	// Use this for initialization
	void Start () {
        combatController = GetComponent<CombatController>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Time.time > TimeSinceLastAttack + AttackTime)
        {
            TimeSinceLastAttack = Time.time;
            combatController.Attack(CombatController.ActionDirection.ActionLeft);
        }
    }

    public void TakeDamage(int damage)
    {
        combatController.Hit();
        Debug.Log(this.name + " is taking damage");
        HealthSlider.value -= damage;
    }
}
