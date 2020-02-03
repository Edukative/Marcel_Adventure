﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWaypoint : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, target.position);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.05f);

    }

    

}
