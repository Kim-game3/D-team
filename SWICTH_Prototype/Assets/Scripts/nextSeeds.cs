using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextSeeds : MonoBehaviour
{
    public int[] next;
    public GameObject[] imageSeeds;
    public Sprite[] sprites;//í‚Ì‰æ‘œ‚ğ“ü‚ê‚éB
    public Image board;//“\‚è•t‚¯‚éêŠ

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
