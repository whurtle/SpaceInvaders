using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;

    public int speed;

    public Transform shottingOffset;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }
    }

    void FixedUpdate()
    {
        transform.Translate(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.9f, 5.9f), -4, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().NewGame();
        Destroy(collision.gameObject);
    }
}
