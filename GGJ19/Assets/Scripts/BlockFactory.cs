using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFactory : MonoBehaviour
{
    public double catRatio = 0.3;
    public List<GameObject> cats;
    public List<GameObject> objects;

    private System.Random random = new System.Random();
    private Queue<GameObject> blocks;

    // Start is called before the first frame update
    void Awake()
    {
        blocks = new Queue<GameObject>();
        for (int i = 0; i < 5; i++)
        {
            if (random.NextDouble() < catRatio)
            {
                int listNumber = random.Next(cats.Count);
                GameObject newBlock = Instantiate(cats[listNumber], new Vector3(transform.position.x, 3 + i, transform.position.z), Quaternion.identity);
                blocks.Enqueue(newBlock);
            } else
            {
                int listNumber = random.Next(objects.Count);
                GameObject newBlock = Instantiate(objects[listNumber], new Vector3(transform.position.x, 3 + i, transform.position.z), Quaternion.identity);
                blocks.Enqueue(newBlock);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetNextBlock()
    {
        var returnBlock = blocks.Dequeue();
        returnBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        Invoke("SpawnNextBlock", 0.5f);
        return returnBlock;
    }

    private void SpawnNextBlock()
    {
        if (random.NextDouble() < catRatio)
        {
            int listNumber = random.Next(cats.Count);
            GameObject newBlock = Instantiate(cats[listNumber], new Vector3(transform.position.x, 7, transform.position.z), Quaternion.identity);
            blocks.Enqueue(newBlock);
        }
        else
        {
            int listNumber = random.Next(objects.Count);
            GameObject newBlock = Instantiate(objects[listNumber], new Vector3(transform.position.x, 7, transform.position.z), Quaternion.identity);
            blocks.Enqueue(newBlock);
        }
    }
}
