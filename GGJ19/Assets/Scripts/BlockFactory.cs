using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    public GameObject blockPrefab;

    private Queue<GameObject> blocks;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new Queue<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            GameObject newBlock = Instantiate(blockPrefab, new Vector3(5, 0 + i, transform.position.z), Quaternion.identity);
            newBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            blocks.Enqueue(newBlock);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetNextBlock()
    {
        var returnBlock = blocks.Dequeue();
        returnBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Invoke("SpawnNextBlock", 0.5f);
        return returnBlock;
    }

    private void SpawnNextBlock()
    {
        GameObject newBlock = Instantiate(blockPrefab, new Vector3(5, 7, transform.position.z), Quaternion.identity);
        newBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        blocks.Enqueue(newBlock);
        Debug.Log("Block spawned");
    }
}
