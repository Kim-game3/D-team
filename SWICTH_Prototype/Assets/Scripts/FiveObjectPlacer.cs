using UnityEngine;

public class FiveObjectPlacer : MonoBehaviour
{
    // 配置するGameObjectのプレハブを複数指定できるようにする
    [SerializeField] private GameObject[] objectPrefabs;

    // 配置する5つの位置
    [SerializeField] private Vector3[] positions = new Vector3[5];
    [SerializeField] private Quaternion[] rotations = new Quaternion[5];

    // オブジェクト配置のための辺の長さ (インスペクターで設定)
    [SerializeField] private float sideLength = 1.0f;

    // 作成したインスタンスを保存する配列
    private GameObject[] instantiatedObjects = new GameObject[5];

    // 5つのオブジェクトの位置を計算するメソッド
    private Vector3[] CalculateFiveObjectPositions()
    {
        float side = Mathf.Sqrt(3) / 2 * sideLength;
        float height = 0f;  // 必要に応じて高さを設定

        Vector3[] vertices = new Vector3[5];
        vertices[0] = new Vector3(0, height, 0);
        vertices[1] = new Vector3(side, height, sideLength / 2);
        vertices[2] = new Vector3(side, height, -sideLength / 2);
        vertices[3] = new Vector3(-side, height, sideLength / 2);
        vertices[4] = new Vector3(-side, height, -sideLength / 2);

        return vertices;
    }

    // ランダムなプレハブを5つの位置にインスタンス化し、保存するメソッド
    public void InstantiateRandomObjects()
    {
        Vector3[] positions = CalculateFiveObjectPositions();

        for (int i = 0; i < positions.Length; i++)
        {
            // objectPrefabsの中からランダムなプレハブを選択
            GameObject randomPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            Quaternion rotation = (i < rotations.Length) ? rotations[i] : Quaternion.identity;

            // プレハブをインスタンス化して保存
            instantiatedObjects[i] = Instantiate(randomPrefab, positions[i], rotation);
        }
    }

    // 指定されたインデックスのポイントを取得するメソッド
    public Vector3 GetPointAtIndex(int index)
    {
        if (index < 0 || index >= positions.Length)
        {
            Debug.LogError("Index out of bounds");
            return Vector3.zero;  // 範囲外の場合はゼロベクトルを返す
        }

        return positions[index];
    }

    // 指定されたインデックスのインスタンスを取得するメソッド
    public GameObject GetInstanceAtIndex(int index)
    {
        if (index < 0 || index >= instantiatedObjects.Length)
        {
            Debug.LogError("Index out of bounds");
            return null;  // 範囲外の場合はnullを返す
        }

        return instantiatedObjects[index];
    }

    // 指定されたインデックスのインスタンスを削除し、その位置に新しいインスタンスを作成するメソッド
    public void ReplaceInstanceAtIndex(int indexToDelete, int indexToCreate)
    {
        if (indexToDelete < 0 || indexToDelete >= instantiatedObjects.Length || indexToCreate < 0 || indexToCreate >= objectPrefabs.Length)
        {
            Debug.LogError("Index out of bounds");
            return;  // 範囲外の場合は処理を終了
        }

        // 削除するインスタンスが存在する場合は破棄
        if (instantiatedObjects[indexToDelete] != null)
        {
            Destroy(instantiatedObjects[indexToDelete]);
        }

        // 新しいインスタンスを指定された位置にインスタンス化
        GameObject prefabToCreate = objectPrefabs[indexToCreate];
        Vector3 positionToCreate = positions[indexToDelete];
        Quaternion rotationToCreate = (indexToDelete < rotations.Length) ? rotations[indexToDelete] : Quaternion.identity;

        instantiatedObjects[indexToDelete] = Instantiate(prefabToCreate, positionToCreate, rotationToCreate);
    }
}
