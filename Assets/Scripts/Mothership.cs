using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyObject {
    public GameObject gameObject;
    public int count;
    public int score;
}

public class Mothership : MonoBehaviour
{
    public GameObject bullet;
    public EnemyObject[] enemies;
    public List<GameObject> livingEnemies;

    float fireTimer;
    private float moveTimer;
    private int moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        this.livingEnemies = new List<GameObject>();
        HatchBrood();
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Fire();
    }

    private void FixedUpdate()
    {
        if (this.livingEnemies.Count <= 0 )
        {
             this.HatchBrood();
        }
    }

    private void Move()
    {
        moveTimer -= Time.deltaTime;
        if (moveTimer < 0)
        {
            switch (moveDirection)
            {
                case 1:
                    transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
                    moveDirection = 0;
                    break;
                case -1:
                    transform.position = new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z);
                    moveDirection = 0;
                    break;
                case 0:
                    transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
                    moveDirection = Random.Range(0, 100) % 2 - 1 == 0 ? 1 : -1;
                    break;
            }

            moveTimer = 2f - 0.1f * (this.enemies.Length * this.enemies[0].count - this.livingEnemies.Count);
        }
    }

    private void Fire()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0)
        {
            int index = Random.Range(0, livingEnemies.Count);
            Debug.Log(index);
            Transform offset = livingEnemies?[index]?.transform;
            if (offset == null)
            {
                Fire();
                return;
            }
            GameObject shot = Instantiate(bullet, offset.position, Quaternion.identity);

            Destroy(shot, 3f);
            fireTimer = 2.5f;
        }
    }

    private void HatchBrood()
    {
        float y = 4.5f;
        for (int i = 0; i < enemies.Length; i++)
        {
            y -= 1.25f;
            float x = -5;
            for (int j = 0; j < enemies[i].count; j++)
            {
                x += 2f;
                this.livingEnemies.Add(Instantiate(enemies[i].gameObject, new Vector2(x, y), Quaternion.identity, this.transform));
            }
        }
    }

    public void Restart()
    {
        this.livingEnemies.ForEach(Destroy);
        this.livingEnemies = new List<GameObject>();
    }
}
