using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggScript : MonoBehaviour
{
    public Rigidbody2D hat;
    public Rigidbody2D man;
    public CircleCollider2D manCircleCollider2D;
    public Button restartButton;

    /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {

            }
        }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Flag"))
        {
            UIController.onAddScore();
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            hat.simulated = true;
            man.bodyType = RigidbodyType2D.Dynamic;
            manCircleCollider2D.isTrigger = false;
            restartButton.gameObject.SetActive(true);
            UIController.alive = false;
            
        }
    }
}
