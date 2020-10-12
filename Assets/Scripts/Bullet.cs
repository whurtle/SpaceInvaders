using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    
    public float speed = 5;
    public bool direction;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        Vector2 direction = this.direction ? Vector2.up : Vector2.down;
        myRigidbody2D.velocity = direction * speed; 
        Debug.Log("Wwweeeeee");
    }
}
