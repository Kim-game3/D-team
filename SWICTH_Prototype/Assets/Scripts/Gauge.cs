using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    public Image scoreImage;
    public float fillAmount;
    [SerializeField] GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        scoreImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(fillAmount);
        fillAmount = Score.score / GM.maxScore;
        scoreImage.fillAmount = fillAmount;
    }
}
