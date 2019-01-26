using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    // TODO: list of prefabs
    public GameObject blockPrefab;
    public GameObject blockFactoryPrefab;

    private BoxCollider2D boxCollider;
    private GameObject currentBlock;
    private GameObject blockFactory;

    private Array blockTypeValues= Enum.GetValues(typeof(Block.BlockType));
    private static System.Random RNG = new System.Random();

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        currentBlock = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        blockFactory = Instantiate(blockFactoryPrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        // TODO: set random block types
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
        if (!currentBlock)
        {
            Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            // TODO: set random block types
        }
    }
}
