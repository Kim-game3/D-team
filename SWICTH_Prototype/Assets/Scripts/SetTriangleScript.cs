using UnityEngine;

public class SetTriangleScript : MonoBehaviour
{
    [SerializeField] Transform[] vertices;//配置するオブジェクト
    [SerializeField] float sideLength;//正三角形の一辺の長さ
    [SerializeField] float Hieght;


    //[SerializeField] public bool apawnPosition = false;
    [SerializeField] public GameObject[] Seeds;

    [SerializeField] public ChangeImage changeimage;

    private GameObject[] spawnSeeds;//格納場所→GMに格納しました。いらない子かも
    private GameObject randomSeed;//仮の肉体
    public float Position = 0;

    public GameManager GM;

    private Renderer[] seedsRenderers = new Renderer[5];

    private int seedLottery;

    void Start()
    {
        Vector3[] positions = CalculateFiveVertices(sideLength);

        for (int i = 0; i < vertices.Length && i < positions.Length; i++)
        {
            vertices[i].position = positions[i];
        }

        for (int i = 0; i < vertices.Length; i++)
        {
            int index = UnityEngine.Random.Range(0, 3);
            Set_Seeds(index, i);
        }
        
    }

    private void Update()
    {
        /*
            for (int i = 0; i < vertices.Length; i++)
            {
                Set_Seeds(changeimage.Keep_Index, i);
            }
            Flag_Null = false;
        }*/
    }

    //それぞれの座標を計算で指定する関数
    Vector3[] CalculateFiveVertices(float sideLength)
    {
        float Side = Mathf.Sqrt(3) / 2 * sideLength;

        //Truncated(Side, 2);

        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(0, Hieght, 0);
        vertices[1] = new Vector3(Side, Hieght, sideLength / 2);
        vertices[2] = new Vector3(Side, Hieght, -sideLength / 2);
        vertices[3] = new Vector3(-Side, Hieght, sideLength / 2);
        vertices[4] = new Vector3(-Side, Hieght, -sideLength / 2);

        return vertices;
    }

    //四捨五入をする関数
    /*float Truncated(float Side, float num)
    {
        float Rounding;
        float DecPart = Side - Mathf.FloorToInt(Side);

        int Dec1 = Mathf.FloorToInt(DecPart * Mathf.Pow(10, num));
        int Dec2 = Dec1 - Mathf.FloorToInt(Dec1 / 10) * 10;

        if(Dec2 >= 5)
        {
            Rounding = Mathf.CeilToInt(Side * Mathf.Pow(10, num - 1));
            Rounding /= Mathf.Pow(10, num - 1);
        }
        else
        {
            Rounding = Mathf.FloorToInt(Side * Mathf.Pow(10, num - 1));
            Rounding /= Mathf.Pow(10, num - 1);
        }
        return Rounding;
    }*/

    public void Set_Seeds(int index, int count)
    {
        if (Seeds == null)
        {
            return;
        }
        if (vertices[count] != null)
        {
            //Debug.Log("生成開始");
            seedLottery = index;

            Vector3 spawnPosition = vertices[count].transform.position;
            spawnPosition.y = Position;
            GM.seedBody[count] = Instantiate(Seeds[seedLottery], spawnPosition, Quaternion.identity);
            //seedsRenderers[count] = GM.seedBody[count].GetComponent<Renderer>();
        }
    }
}
