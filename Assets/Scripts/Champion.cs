using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class Champion : Hittable
{
    public Camera camera;
    RaycastHit hit;

    void Awake()
    {
        this.rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
        this.rb.useGravity = false;
    }

    public override void attackFunction()
    {
        
    }

    public override void Start()
    {
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var targetPos = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(targetPos, out hit, 100))
            {
                UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            }
        }


        this.rb.position = Vector3.MoveTowards(this.rb.position, hit.point, 2 * Time.deltaTime);
    }
}
