using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] inhibs;
    void Update()
    {
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
    }
}