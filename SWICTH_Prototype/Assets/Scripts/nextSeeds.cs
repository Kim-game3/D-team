using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextSeeds : MonoBehaviour
{
    public int[] next;
    public GameObject[] imageSeeds;
    public Sprite[] sprites;//種の画像を入れる。
    public Image board;//貼り付ける場所

    // Start is called before the first frame update
    void Start()
    {
        nextSeedsImage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextSeedsImage()
    {
        if(sprites.Length > 0 && board != null)
        {
            int rnd = Random.Range(0,sprites.Length);
            board.sprite = sprites[rnd];
        }
    }
}
