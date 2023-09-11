using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class Champion : Hittable
{
    Vector3 target;

    public override bool attackFunction(GameObject hittableObject)
    {
        Hittable hittableObjectComponent = hittableObject.GetComponent<Hittable>();
        if (hittableObjectComponent == null) return false;

        bool isInRange = Vector3.Distance(new Vector3(this.rb.transform.position.x, 0, this.rb.transform.position.z), new Vector3(hittableObject.transform.position.x, 0, hittableObject.transform.position.z)) < this.autoRange;

        if (isInRange && hittableObjectComponent.team != this.team && !hittableObjectComponent.invulnerable) {
            float physicalDamage = (hittableObjectComponent.armour > this.attackDamage) ? 0 : this.attackDamage - hittableObjectComponent.armour;
            hittableObjectComponent.healthPoints -= physicalDamage;
            UnityEngine.Debug.Log(hittableObjectComponent.healthPoints);
            return true;
        }
        return false;
    }

    public override void Start()
    {
        target = this.rb.transform.position;
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            var targetPos = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(targetPos, out hit, 100))
            {
                this.target = this.rb.transform.position;
            } else {
                
                GameObject other = hit.collider.gameObject;
                if (!attackFunction(other)){
                    target = hit.point;
                }
            }
        }

        this.rb.position = Vector3.MoveTowards(this.rb.position, target, this.speed * Time.deltaTime);
    }
}
