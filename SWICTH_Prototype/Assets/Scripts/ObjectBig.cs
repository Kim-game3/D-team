using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObjectBig : MonoBehaviour
{
    [SerializeField] GameObject sphere;
    [SerializeField] float SunnySeed = 0.5f;

   

    // Start is called before the first frame update
    void Start()
    {
        // 0.1�b���Ƃ�ScaleObject���J��Ԃ�
        InvokeRepeating("ScaleObject", 0f, 0.1f);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Sunny()
    {
        
        // �I�u�W�F�N�g��Y����SunnySeed��f�傫������
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Rainy()
    {
        // �I�u�W�F�N�g��Y����0.1f�傫������
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Thunder()
    {
        // �I�u�W�F�N�g��Y����0.1f�傫������
        //sphere.transform.localScale += new Vector3(0, -SunnySeed*2, 0);
    }

    void ScaleObject()
    {
        // �I�u�W�F�N�g�������傫������
        transform.localScale += new Vector3(0f, 0.1f, 0f);
    }

    public void myEnd()
    {
        CancelInvoke();
    }

}
