using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    Enemy enemy;
    CombatController combatController;
    public Slider HealthSlider;
    Camera camera;

    public Image SwordImage;
    public Image ShieldImage;

    bool BlockingValue = true;

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


        SwordImage.gameObject.SetActive(BlockingValue);
        ShieldImage.gameObject.SetActive(!BlockingValue);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("ActionRight"))
        {
            combatController.Action(CombatController.ActionDirection.ActionRight);
        }
        if (Input.GetButtonDown("ActionLeft"))
        {
            combatController.Action(CombatController.ActionDirection.ActionLeft);
        }
        if (Input.GetButtonDown("ActionOverhead"))
        {
            combatController.Action(CombatController.ActionDirection.ActionOverhead);
        }
        if (Input.GetButtonDown("BlockToggle"))
        {
            BlockingValue = !BlockingValue;

            SwordImage.gameObject.SetActive(BlockingValue);
            ShieldImage.gameObject.SetActive(!BlockingValue);
            combatController.ToggleBlocking();
        }
    }

    public void AttackEnemyMessage(CombatController.ActionDirection AttackDirection)
    {
        enemy.AttackedFrom(AttackDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, .7f);
    }
}
