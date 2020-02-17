using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{

    Transform Ruby;
    Rigidbody2D RubyRB;
    public float RVel;
    Camera Cam;
    Player_Controller1 RUBY;
    public float moving = 0;


    void Start()
    {

        
        Ruby = GameObject.Find("Ruby").GetComponent<Transform>();
        RubyRB = GameObject.Find("Ruby").GetComponent<Rigidbody2D>();
        RUBY = GameObject.Find("Ruby").GetComponent<Player_Controller1>();

        Cam = GetComponent<Camera>();

        for(int i = 0; i <= 90; i++)
        {

            Debug.Log("i = " + i + "    Cos = " + Mathf.Cos(i));

        }

    }

    void Update()
    {

        transform.position = Ruby.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        RVel = Mathf.Pow(RUBY.Match20 * RUBY.horizontal * Time.deltaTime * RUBY.Match20 * RUBY.horizontal * Time.deltaTime 
                           + RUBY.Match20 * RUBY.vertical * Time.deltaTime * RUBY.Match20 * RUBY.vertical * Time.deltaTime, 0.5f);

        
        //Debug.Log(RVel * 4);
        moving = Mathf.Clamp(moving, 0.01f, 1);
        if(Mathf.Approximately(RUBY.Match20 * RUBY.horizontal, 0.0f) && Mathf.Approximately(RUBY.Match20 * RUBY.vertical, 0.0f))
        {

            //moving += -0.02f;
            //moving = Mathf.Lerp(moving, 0, 0.05f);
            moving += -Mathf.Pow(moving, 1.13f);

        }
        else
        {

            //moving += 0.02f;
            //moving = Mathf.Lerp(moving, 1, 0.05f);
            moving += Mathf.Pow(moving, 0.15f * moving);

        }

        moving = Mathf.Clamp(moving, 0.0f, 1.0f);

        Cam.orthographicSize = Mathf.Lerp(5, 7, Mathf.Clamp01(RVel * 4) * moving);


    }



}
