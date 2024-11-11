using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI resultText;
    static public float score;
    static public int result;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score:"+score;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
        scoreText.text = "Score:" + score;
        //Debug.Log(result);
        result = (int)score;
    }

}
