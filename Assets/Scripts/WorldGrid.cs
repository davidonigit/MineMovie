using UnityEngine;

public class WorldGrid : MonoBehaviour
{
    public static WorldGrid Instance { get; private set; }

    const string BLOCKS_PARENT = "BlocksParent";

    private float cellSize = .5f;

    private void Awake() {
        Instance = this;
    }

    public void PlaceBlock (Vector3 position, GameObject blockPrefab) {
        Transform blockParent = GameObject.Find(BLOCKS_PARENT).transform;
        Vector3 gridPosition = GetGridPosition(position);
        GameObject block = Instantiate(blockPrefab.gameObject, gridPosition, Quaternion.identity, blockParent);
    }

    private Vector3 GetGridPosition(Vector3 position) {
        float x = Mathf.Floor(position.x);
        float y = Mathf.Floor(position.y);
        float z = Mathf.Floor(position.z);
        return new Vector3(x + .5f, y + .5f, z + .5f);
    }
}
