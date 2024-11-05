using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    static public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score:"+score;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + score;
    }
}