using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Count : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startCountdown());
    }

    IEnumerator startCountdown()
    {
        int countDowntime = 3;

        while(countDowntime > 0)
        {
            countText.text = countDowntime.ToString();
            yield return new WaitForSeconds(1.0f);
            countDowntime--;
        }

        countText.text = "Start!";
        R_MoveCloud.R_moveStart = true;
        L_MoveCloud.L_moveStart = true;

        yield return new WaitForSeconds (0.5f);
        countText.text =  "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
