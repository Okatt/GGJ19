using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BlockType { Box, Cat, Empty, Noisy, Rough, Warm };

    public BlockType type;
}
