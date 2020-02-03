using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb2d;
    bool isVertical;

    float timer;
    int direction = 1;
    public float changeTimer = 3.0f;

    public Vector2[] localNodes;

    int currentnode;
    int NextNode;
    Vector2 Velocity;

    


    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        timer = changeTimer;

        localNodes = new Vector2[transform.childCount];

        for(int i = 0; i <= transform.childCount - 1; i++)
        {


            Transform child = transform.GetChild(i).transform;
            localNodes[i] = child.transform.position;
            Debug.Log("Index = " + i + "  Transform" + localNodes[i]);

        }

        currentnode = 0;
        NextNode = 1;


    }

    // Update is called once per frame
    void Update()
    {

        /*timer += -Time.deltaTime;
        if(timer < 0)
        {

            direction = -direction;
            timer = changeTimer;

        }*/

        Vector2 wayPointDir = localNodes[NextNode] - rb2d.position;
        float dist = speed * Time.deltaTime;

        /*Vector2 position = rb2d.position;

        if (isVertical)
        {

            position.y += Time.deltaTime * speed * direction;

        }
        else
        {

            position.x += Time.deltaTime * speed * direction;

        }
        */

        if(wayPointDir.sqrMagnitude < dist * dist)
        {

            dist = wayPointDir.magnitude;
            currentnode = NextNode += 1;
            if(NextNode >= localNodes.Length)
            {

                NextNode = 0;

            }

        }

        rb2d.MovePosition(position);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        Player_Controller1 player = other.gameObject.GetComponent<Player_Controller1>();

        if(player != null)
        {

            player.ChangeHealth(-1);

        }


    }

}


/*
 
     */