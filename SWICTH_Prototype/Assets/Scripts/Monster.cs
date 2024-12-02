using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] GameManager GM;
    [SerializeField] GameObject Tongue;
    public int[] point;
    public bool jammerCheck;
    public bool pushL;
    public bool hasTriggered;
    private int Interval;
    private int rnd;
    

    Vector3 targetPosition;
    Vector3 startPositin;

    // Start is called before the first frame update
    void Start()
    {
        startPositin = transform.position;
        Interval = 5;
        jammerCheck = false;
        pushL = false;
        hasTriggered = false;
        StartCoroutine("Jammer");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pushL);
        pushL = false;
        if(jammerCheck && !hasTriggered)
        {
            Debug.Log("位置取り");
            Hunting();
            hasTriggered = true;
        }
    }

    IEnumerator Jammer()
    {
        yield return new WaitForSeconds(10.0f);

        while (true)
        {
            Debug.Log("ジャマー開始");//すぐ開始
            rnd = Random.Range(0, 5);
            targetPosition = GM.seedBody[rnd].transform.position;
            targetPosition.y += 7;
            Tongue.transform.position = targetPosition;
            Debug.Log("ジャマー終わり");//timer後に実行

            yield return new WaitUntil(() => jammerCheck == true);

            Tongue.transform.position = startPositin;
            yield return new WaitForSeconds(Interval);//インターバル
            hasTriggered = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Thunder"))
        {
            Debug.Log("雷とあたっています");
            if(pushL)
            {
                jammerCheck = true;
                pushL = false;
            }
           
        }
        else if (!other.CompareTag("Thunder"))
        {
            if(other.gameObject.name == "hitPosition")
            {

            }
            else
            {
                Debug.Log("雷以外とあたっています");
                Debug.Log("あたっているのは:" + other.gameObject.name);
                jammerCheck = false;
            }
            
        }
    }
    public void Hunting()
    {
        GM.HuntingScore();
    }

}
