using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hittable : MonoBehaviour {
    [SerializeField]
    float autoRange;
    [SerializeField]
    float speed;
    [SerializeField]
    float attackDamage;
    [SerializeField]
    float abilityPower;
    [SerializeField]
    float armour;
    [SerializeField]
    float magicResis;
    [SerializeField]
    protected Rigidbody rb;
    [SerializeField]
    float healthPoints;

    abstract public void attackFunction();

    abstract public void Start();

    abstract public void Update();
}