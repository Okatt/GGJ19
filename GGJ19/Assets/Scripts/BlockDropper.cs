using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDropper : MonoBehaviour
{
    // TODO: list of prefabs
    public GameObject blockFactoryPrefab;
    public GameObject scoreTrackerPrefab;
    public GameObject moodUpdateTriggerPrefab;

    public List<GameObject> currentCats;

    private BoxCollider2D boxCollider;
    private GameObject currentBlock;
    private GameObject blockFactory;
    public GameObject scoreTracker;

    private void Awake()
    {
        scoreTracker = Instantiate(scoreTrackerPrefab, new Vector3(-5, 5, transform.position.z), Quaternion.identity);
        blockFactory = Instantiate(blockFactoryPrefab, new Vector3(-8, -1, transform.position.z), Quaternion.identity);
    }

    void Start()
    {
        currentBlock = blockFactory.GetComponent<BlockFactory>().GetNextBlock();
        currentBlock.transform.position = transform.position;

        boxCollider = GetComponent<BoxCollider2D>();
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
            GameObject moodUpdateTrigger = Instantiate(moodUpdateTriggerPrefab, currentBlock.transform);
            moodUpdateTrigger.GetComponent<TestCollider>().blockDropper = GetComponent<BlockDropper>();
            currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;          
            currentBlock.GetComponent<AttitudeDisplay>().Hide();
            if(currentBlock.GetComponent<Block>().type == Block.BlockType.Cat)
            {
                currentCats.Add(currentBlock);
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

    public void UpdateMoodScore()
    { 
        scoreTracker.GetComponent<ScoreTracker>().UpdateScore(currentCats);
        
    }
}
