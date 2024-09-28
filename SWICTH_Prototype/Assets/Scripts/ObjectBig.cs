using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObjectBig : MonoBehaviour
{
    [SerializeField] GameObject sphere;

    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Sunny()
    {
        Debug.Log("����ł�");
        // �I�u�W�F�N�g��Y����SunnySeed��f�傫������
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Rainy()
    {
        Debug.Log("�J�ł�");
        // �I�u�W�F�N�g��Y����0.1f�傫������
        //sphere.transform.localScale += new Vector3(0, SunnySeed, 0);
    }

    public void Thunder()
    {
        Debug.Log("���ł�");
        // �I�u�W�F�N�g��Y����0.1f�傫������
        //sphere.transform.localScale += new Vector3(0, -SunnySeed*2, 0);
    }

}
