using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDropper : MonoBehaviour
{
    public GameObject blockPrefab;
    private GameObject currentBlock;

    void Start()
    {
        currentBlock = Instantiate(blockPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentBlock && Input.GetKeyDown(KeyCode.LeftArrow) && !Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentBlock.transform.position = new Vector2(currentBlock.transform.position.x - 1, currentBlock.transform.position.y);
        }

        if (currentBlock && Input.GetKeyDown(KeyCode.RightArrow) && !Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentBlock.transform.position = new Vector2(currentBlock.transform.position.x + 1, currentBlock.transform.position.y);
        }

        if (!currentBlock && Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentBlock = Instantiate(blockPrefab, transform);
        }

        if (currentBlock && Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentBlock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            currentBlock = null;
        }
    }
}
