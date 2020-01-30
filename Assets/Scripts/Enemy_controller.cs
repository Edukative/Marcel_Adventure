using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{

    public float speed;
    Rigidbody2D rb2d;
    public bool isVertical;

    float timer;
    int direction = 1;
    public float changeTimer = 3.0f;

    Animator anim;
    Vector2 looking = Vector2.right;


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        timer = changeTimer;
        anim = GetComponent<Animator>();


    }

    void Update()
    {

        speed = 5;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {

            looking.Set(move.x, move.y);
            looking.Normalize();

        }

        anim.SetFloat("look X", looking.x);
        anim.SetFloat("look Y", looking.y);
        anim.SetFloat("Speed", move.magnitude);

        Vector2 position = rb2d.position;
        position += move * speed * Time.deltaTime;




        timer += -Time.deltaTime;
        if(timer < 0)
        {

            direction = -direction;
            timer = changeTimer;

        }

        
        if (isVertical)
        {

            position.y += Time.deltaTime * speed * direction;

            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", direction);

        }
        else
        {

            position.x += Time.deltaTime * speed * direction;

            anim.SetFloat("MoveX", direction);
            anim.SetFloat("MoveY", 0);
            
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
