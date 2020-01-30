using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller1 : MonoBehaviour
{
    // Start is called before the first frame update

    Vector2 pos = Vector2.zero;
    public float horizontal = 0;
    public float vertical = 0;
    public float Match20 = 15.00f;
    Rigidbody2D PlayerRB2D;

    public int HealthPoints = 100;
    public int MaxHP = 100;

    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {

        PlayerRB2D = GetComponent<Rigidbody2D>();
        HealthPoints = MaxHP;

        //HealthPoints = 1;

        Anim = GetComponent<Animator>();

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

        Debug.Log(HealthPoints + "/" + MaxHP);



    }


    public void ChangeHealth(int amount)
    {

        HealthPoints = Mathf.Clamp(HealthPoints + amount, 0, MaxHP);
        Debug.Log(HealthPoints + "/" + MaxHP);


    }



}
