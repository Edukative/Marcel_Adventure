using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControl : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);

        Player_Controller1 controller = other.GetComponent<Player_Controller1>();

        if (controller != null)
        {

            controller.ChangeHealth(1);

            Destroy(gameObject);

        }


    }


}
