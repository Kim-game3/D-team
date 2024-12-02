using UnityEngine;

public class sunnyGrow : MonoBehaviour
{
    //public GameObject[] seeds;//中に種が入ってます。
    public bool S_Ready = false;
    public bool S_Return = false;
    public bool S_Harvest = false;
    private Vector3 seedScale;

    // Start is called before the first frame update
    void Start()
    {
        //seedScale = transform.localScale;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //サイズは変わらないがアニメーションが再生されない。
        //transform.localScale = seedScale;
    }

    void OnTriggerEnter(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Sunny"))
        {
            S_Ready = true;
            //Debug.Log("晴れ種成長します!");
            //Debug.Log(S_Ready);
        }

        if (other.CompareTag("Thunder"))
        { 
            S_Return = true;
            //Debug.Log("ミス");
        }
    }

    void OnTriggerExit(Collider other)//こっちは機能する
    {
        if (other.CompareTag("Sunny"))
        {
            S_Ready = false;
            //Debug.Log("晴れ種成長しません!");
            //Debug.Log(S_Ready);
        }
        if (other.CompareTag("Thunder"))
        {
            S_Return = false;
            
        }
    }

}
