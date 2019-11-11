using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller1 : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 pos = Vector2.zero;
    float horizontal = 0;
    float vertical = 0;
    float Match20 = 15.00f;
    Rigidbody2D PlayerRB2D;

    // Start is called before the first frame update
    void Start()
    {

        PlayerRB2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        pos = transform.position;
        pos.x = pos.x + Match20 * horizontal * Time.deltaTime;
        pos.y = pos.y + Match20 * vertical * Time.deltaTime;
        //transform.position = pos;
        PlayerRB2D.MovePosition(pos);       
        
        //Debug.Log("Horizontal" + horizontal);
        //Debug.Log("Vertical" + vertical);







    }
}
