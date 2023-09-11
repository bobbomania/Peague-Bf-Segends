using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class Structure : Hittable
{
    
    public GameObject[] towers;
    public GameObject[] inhibs;
    public override bool attackFunction(GameObject hittableObject)
    {
        return false;
    }

    public override void Start()
    {

    }
    public override void Update()
    {
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