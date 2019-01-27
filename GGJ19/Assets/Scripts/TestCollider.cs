using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollider : MonoBehaviour
{
    public BlockDropper blockDropper;

    private void OnTriggerEnter2D(Collider2D other)
    { 
        blockDropper.GetComponent<BlockDropper>().UpdateMoodScore();
    }
}
