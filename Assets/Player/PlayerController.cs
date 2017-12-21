using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Enemy enemy;
    CombatController combatController;
    public Slider HealthSlider;
    Camera camera;

    public void TakeDamage(int damage)
    {
        //   Debug.Log(this.name + " is taking damage");
        combatController.Hit();
        HealthSlider.value -= damage;
    }

    void Start()
    {
        enemy = FindObjectOfType<Enemy>();
        combatController = GetComponent<CombatController>();
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("ActionRight"))
        {
            combatController.Attack(CombatController.ActionDirection.ActionRight);
        }
        if (Input.GetButtonDown("ActionLeft"))
        {
            combatController.Attack(CombatController.ActionDirection.ActionLeft);
        }
        if (Input.GetButtonDown("ActionOverhead"))
        {
            combatController.Attack(CombatController.ActionDirection.ActionOverhead);
        }
        if (Input.GetButtonDown("BlockToggle"))
        {
            combatController.ToggleBlocking();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, .7f);
    }
}
