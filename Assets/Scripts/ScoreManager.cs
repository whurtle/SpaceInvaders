using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private int score;
    private static int highScore;

    private EnemyObject[] enemyTypes;

    public Text scoreText;
    public Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        this.enemyTypes = GameObject.Find("Mothership").GetComponent<Mothership>().enemies;
        score = 0;

        highScoreText.text = highScore.ToString().PadLeft(4, '0');
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(GameObject enemy)
    {
        int enemyScore = enemyTypes.Where(t => t.gameObject.tag == enemy.tag).First().score;
        this.score += enemyScore;
        if (this.score > highScore)
        {
            highScore = this.score;
        }

        scoreText.text = score.ToString().PadLeft(4, '0');
        highScoreText.text = highScore.ToString().PadLeft(4, '0');
    }

    public void ResetScore()
    {
        this.score = 0;

        this.scoreText.text = "0000";
    }
}
