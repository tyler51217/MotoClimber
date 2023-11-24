using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEggScript : MonoBehaviour
{

    public Rigidbody2D hat;
    public Rigidbody2D man;
    public CircleCollider2D manCircleCollider2D;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            hat.simulated = true;
            man.bodyType = RigidbodyType2D.Dynamic;
            manCircleCollider2D.isTrigger = false;

        }
    }

}
