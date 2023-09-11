using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class Structure : Hittable
{
    
    public GameObject[] towers;
    public GameObject[] inhibs;
    bool isAttacking;
    GameObject target;
    public override bool attackFunction(GameObject hittableObject)
    {
        UnityEngine.Debug.Log("tower hitting");
        Hittable hittableObjectComponent = hittableObject.GetComponent<Hittable>();        
        float physicalDamage = (hittableObjectComponent.armour > this.attackDamage) ? 0 : this.attackDamage - hittableObjectComponent.armour;
        hittableObjectComponent.healthPoints -= physicalDamage;
        UnityEngine.Debug.Log(hittableObjectComponent.healthPoints);
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Champion champ = other.gameObject.GetComponent<Champion>();
        if (champ != null && champ.team != this.team) {
            isAttacking = true;
            target = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAttacking = false;
        target = null;
    }

    public override void Start()
    {

    }
    public override void Update()
    {
        if (isAttacking && timeLeft <= 0) {
            attackFunction(target);
            timeLeft = attackSpeed;
        } else {
            if (timeLeft > 0){ //cos gab a lil crybaby and doesnt want the time to go to -8 rotated 90 degrees
                timeLeft -= Time.deltaTime;
            }
        }

        if (inhibs.Length > 0) { // IF WE CARE ABOUT INHIBS!!!!!!!!!!!!!!!!!
            foreach (GameObject inhib in inhibs) {
                if (inhib == null) {
                    foreach (GameObject tower in towers) {
                        if (tower != null) {
                            gameObject.GetComponent<Hittable>().invulnerable = true;
                            return;
                        }                    
                    }
                    gameObject.GetComponent<Hittable>().invulnerable = false;
                    return;
                }
            }
            gameObject.GetComponent<Hittable>().invulnerable = true;
        } else {
            foreach(GameObject tower in towers) {
                if (tower != null) {
                    gameObject.GetComponent<Hittable>().invulnerable = true;
                    return;
                }
            }
            gameObject.GetComponent<Hittable>().invulnerable = false;
        }
    }
}