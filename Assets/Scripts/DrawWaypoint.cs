using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWaypoint : MonoBehaviour
{

    public Transform target;
    int wayPointIndex;
    Transform WayPointParent;

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

        wayPointIndex = transform.GetSiblingIndex();
        WayPointParent = transform.parent;

        if (wayPointIndex >= WayPointParent.transform.childCount - 1)
        {

            target = WayPointParent.GetChild(0);

        }
        else
        {

            target = WayPointParent.GetChild(wayPointIndex + 1);

        }

        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, target.position);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.05f);



    }

    

}
