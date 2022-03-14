using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text scoreText;
    int allscore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
    }
    public void addscore(int score)
        {
        allscore = allscore + score;
        }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = allscore.ToString();
    }
}
