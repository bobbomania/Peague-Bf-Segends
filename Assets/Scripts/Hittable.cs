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
    public float attackSpeed;
    public float abilityPower;
    public float armour;
    public float magicResist;
    public float healthPoints;
    public float timeLeft;
    public Rigidbody rb;
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