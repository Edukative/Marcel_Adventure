using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{

    public GameObject wayPoints;

    float speed = 5;
    Rigidbody2D rb2d;
    bool isVertical;

    float timer;
    int direction = 1;
    public float changeTimer = 3.0f;

    public Vector2[] localNodes;

    int currentnode;
    int NextNode;
    Vector2 Velocity;
    Animator anim;

    


    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        timer = changeTimer;
        anim = GetComponent<Animator>();

        localNodes = new Vector2[transform.childCount];

        localNodes = new Vector2[wayPoints.transform.childCount];

        for(int i = 0; i <= wayPoints.transform.childCount - 1; i++)
        {


            Transform child = wayPoints.transform.GetChild(i).transform;
            //localNodes[i] = child.transform.position;
            localNodes[i] = new Vector2(child.transform.position.x, child.transform.position.y);

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
        Vector2 position = rb2d.position;
        float dist = speed * Time.deltaTime;
        UpdateAnimations(wayPointDir);

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("Magnitude" + wayPointDir.magnitude);
            Debug.Log("SqrMagnitude" + wayPointDir.sqrMagnitude);
            Debug.Log("Normalized" + wayPointDir.normalized);

        }

        if(wayPointDir.sqrMagnitude < dist * dist)
        {

            dist = wayPointDir.magnitude;
            currentnode = NextNode;
            NextNode += 1;

            if(NextNode >= localNodes.Length)
            {

                NextNode = 0;

            }

        }

        Velocity = wayPointDir.normalized * dist;


        
        /*
        if (isVertical)
        {

            position.y += Time.deltaTime * speed * direction;

        }
        else
        {

            position.x += Time.deltaTime * speed * direction;

        }
        */

        

        rb2d.MovePosition(position + Velocity);
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        Player_Controller1 player = other.gameObject.GetComponent<Player_Controller1>();

        if(player != null)
        {

            player.ChangeHealth(-1);

        }


    }

    void UpdateAnimations(Vector2 d)
    {

        this.GetComponent<Animator>().SetFloat("MoveX", d.x);
        this.GetComponent<Animator>().SetFloat("MoveY", d.y);

    }


}


/*
 
     */