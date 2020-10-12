using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    ScoreManager scoreManager;

    private void Start()
    {
        this.scoreManager = GameObject.Find("Canvas").GetComponent<ScoreManager>();
    }
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player Bullet")
        {
            this.scoreManager.AddScore(this.gameObject);
            GameObject.Find("Mothership").GetComponent<Mothership>().livingEnemies.Remove(this.gameObject);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

    }
}
