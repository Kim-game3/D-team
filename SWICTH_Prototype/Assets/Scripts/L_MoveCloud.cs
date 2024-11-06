using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_MoveCloud : MonoBehaviour
{
    [SerializeField] float speed = -1200f;
    [SerializeField] float moveDistance;

    private float startPosX;
    public static bool L_moveStart = false;

    // Start is called before the first frame update
    void Start()
    {
        // èâä˙à íuÇãLò^
        startPosX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (L_moveStart)
        {
            moveObject();
        }
    }

    public void moveObject()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
