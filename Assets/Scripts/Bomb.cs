using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Gameover")
        {
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            Application.LoadLevel("platformer");
        }
    }
}