using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    public GameObject blockPrefab;

    private BoxCollider2D boxCollider;
    private GameObject currentBlock;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        currentBlock = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }

    void Update()
    {
        // Move the dropper
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            if(currentBlock) currentBlock.transform.position = transform.position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            if(currentBlock) currentBlock.transform.position = transform.position;
        }

        // Drop the block
        if (currentBlock && Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            currentBlock = null;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Spawn a new block
        if (!currentBlock) currentBlock = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
    }
}
