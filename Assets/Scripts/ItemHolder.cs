using UnityEngine;

public class ItemHolder : MonoBehaviour
{
    [SerializeField]
    private Transform controllerTransform;

    [SerializeField]
    private BlockItem[] blockItems;

    private BlockItem currentBlock;
    private float yOffset = .3f;

    private void Start() {
        SpawnItem(blockItems[0]);
    }

    private void Update() {
        // Keep position
        if (controllerTransform != null) {
            Vector3 newPosition = controllerTransform.position;
            newPosition.y += yOffset;

            transform.position = newPosition;
        }

        // Handle BlockItems
        if (currentBlock == null) {
            SpawnItem(blockItems[0]);
        }
    }

    private void SpawnItem(BlockItem item) {
        if (currentBlock == null) {
            currentBlock = Instantiate(item, transform);
        }
    }
}
