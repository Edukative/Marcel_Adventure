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



    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        timer = changeTimer;


    }

    // Update is called once per frame
    void Update()
    {

        timer += -Time.deltaTime;
        if(timer < 0)
        {

            direction = -direction;
            timer = changeTimer;

        }

        Vector2 position = rb2d.position;

        if (isVertical)
        {

            position.y += Time.deltaTime * speed * direction;

        }
        else
        {

            position.x += Time.deltaTime * speed * direction;

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
