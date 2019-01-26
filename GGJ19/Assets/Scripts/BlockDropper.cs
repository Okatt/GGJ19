﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    // TODO: list of prefabs
    public GameObject blockPrefab;
    public GameObject blockFactoryPrefab;
    public GameObject scoreTrackerPrefab;
    public List<GameObject> currentCats;

    private BoxCollider2D boxCollider;
    private GameObject currentBlock;
    private GameObject blockFactory;
    public GameObject scoreTracker;

    private Array blockTypeValues= Enum.GetValues(typeof(Block.BlockType));

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        currentBlock = Instantiate(blockPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        blockFactory = Instantiate(blockFactoryPrefab, new Vector3(5, -1, transform.position.z), Quaternion.identity);
        scoreTracker = Instantiate(scoreTrackerPrefab, new Vector3(-5, 5, transform.position.z), Quaternion.identity);
        currentCats = new List<GameObject>();
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
            if(currentBlock.GetComponent<Block>().type == Block.BlockType.Cat)
            {
                currentCats.Add(currentBlock);
                Invoke("UpdateMoodScore", 2);
            }
            currentBlock = null;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Spawn a new block
        if (!currentBlock)
        {
            currentBlock = blockFactory.GetComponent<BlockFactory>().GetNextBlock();
            currentBlock.transform.position = transform.position;
          
            // TODO: set random block types
        }
    }

    private void UpdateMoodScore()
    {
        scoreTracker.GetComponent<ScoreTracker>().UpdateScore(currentCats);
    }
}
