using UnityEngine;
using System;
using UnityEngine.UIElements;
using Oculus.Interaction;

public class BlockItem : MonoBehaviour
{

    [SerializeField]
    private GameObject blockPrefab;

    private bool isGrabbed = false;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        // Item grabbed from ItemHolder
        if (transform.localPosition != Vector3.zero && !isGrabbed) {
            isGrabbed = true;
            ThrowItem();
        }
    }

    private void ThrowItem() {
        transform.parent = null;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    private void OnCollisionEnter(Collision collision) {
        WorldGrid.Instance.PlaceBlock(transform.position, blockPrefab);
        Destroy(gameObject);
    }
}

