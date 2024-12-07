using UnityEngine;

public class FieldPlacer : MonoBehaviour
{
    [SerializeField] GameObject[] Field;
    public FiveObjectPlacer fiveobjectplacer;
    public int SeedNum { get; private set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SeedsJudge(int i)
    {
        if(i < 0 || i >= Field.Length)
        {
            Debug.LogWarning("範囲外です" + i);
            return;
        }
        SeedNum = CompareSeeds(Field[i]);
        Debug.Log(SeedNum + "を渡しました");
        fiveobjectplacer?.ReplaceInstanceAtIndex(i, SeedNum);
    }

    public int CompareSeeds(GameObject obj)
    {
        Vector3 boxSize = new Vector3(2, 2, 2);
        Collider[] hitcolliders = Physics.OverlapBox(obj.transform.position, boxSize / 2,Quaternion.identity);

        if (hitcolliders.Length == 0)
        {
            Debug.Log("何も入っていないので虚無を返しました");
            return -1;
        }

        foreach (var hitcollider in hitcolliders)
        {
            Debug.Log("ここまで到達しました");
            switch (hitcollider.tag)
            {
                
                case "Sunny":
                    Debug.Log("晴れここまで到達しました");
                    return 1;
                case "Rainy":
                    Debug.Log("雨ここまで到達しました"); 
                    return 2;
                case "Thunder":
                    Debug.Log("雷ここまで到達しました");
                    return 0;
                default:
                    Debug.Log($"不明なタグ：{hitcollider.tag}");
                    break;
            }
        }

        Debug.Log("該当するタグが見つからなかったのでデフォルト値を返しました");
        return -1;
    }

    private void OnDrawGizmos()
    {
        if (Field == null) return;

        Gizmos.color = Color.cyan;
        foreach(var obj in Field)
        {
            if(obj != null)
            {
                Vector3 boxSize = new Vector3(2, 2, 2);
                Gizmos.DrawWireCube(obj.transform.position, boxSize);
            }
        }
    }
}