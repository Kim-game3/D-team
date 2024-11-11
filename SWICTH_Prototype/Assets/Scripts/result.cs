using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Image scoreGauge;
    [SerializeField] GameManager GM;
    public float ScoreResult;
    public float fillAmount;

    // Start is called before the first frame update
    void Start()
    {
        //getScore();
        ScoreResult = PlayerPrefs.GetFloat("resultScore");
        scoreGauge.fillAmount = 0;
        fillAmount = ScoreResult / GM.maxScore;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ScoreResult);
        resultText.text = "SCORE:" + ScoreResult;
        scoreGauge.fillAmount = fillAmount;
    }
}
