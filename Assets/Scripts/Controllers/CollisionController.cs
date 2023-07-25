using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    [Header("Events")]
    public GameEvent packagePickup;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected: " + collision.gameObject.name + " and: " + gameObject.name);
        Debug.Log("Trigger detected: " + collision.gameObject.name);


        this.packagePickup.Raise();
        //if(collision.gameObject.name == "foo")
        //{

        //}
        Debug.Log("Trigger detected");
        Debug.Log("Package pickup");
       
    }
}
