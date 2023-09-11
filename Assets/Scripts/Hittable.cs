using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team {blue, red}

public abstract class Hittable : MonoBehaviour {
    public Team team;
    public float autoRange;
    public float speed;
    public float attackDamage;
    public float abilityPower;
    public float armour;
    public float magicResist;
    public Rigidbody rb;
    public float healthPoints;
    public bool invulnerable;
    
    public void LateUpdate() {
        if (healthPoints <= 0) {
            Destroy(gameObject);
        }
    }

    abstract public bool attackFunction(GameObject hittableObject);

    abstract public void Start();

    abstract public void Update();
}