using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{



    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other);

        Player_Controller1 controller = other.GetComponent<Player_Controller1>();

        if (controller != null)
        {
            

             controller.ChangeHealth(-15);
            
        }


    }

}
