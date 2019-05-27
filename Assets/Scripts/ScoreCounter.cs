using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;
    private GameObject scoreText;

    // Use this for initialization
    void Start()
    {
        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
        //ScoreTextに初期スコアを表示
        this.scoreText.GetComponent<Text>().text = "Score: " + this.score;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.score += 10;
        }
        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.score += 5;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.score += 20;
        }
        else if (collision.gameObject.tag == "SmallStarTag")
        {
            this.score += 1;
        }
        this.scoreText.GetComponent<Text>().text = "Score: " + this.score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
