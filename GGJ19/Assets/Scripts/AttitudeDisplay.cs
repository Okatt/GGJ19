using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttitudeDisplay : MonoBehaviour
{
    public GameObject attitudeIconPrefab;

    public Sprite nullIcon;
    public Sprite catIcon;
    public Sprite softIcon;
    public Sprite plantIcon;
    public Sprite soundIcon;

    private List<GameObject> icons;
    private Block block;

    private float offset = 1;

    void Start()
    {
        icons = new List<GameObject>();
        block = GetComponent<Block>();

        CreateIcons();
    }

    void Update()
    {
        UpdateIcons();
    }

    private void CreateIcons()
    {
        icons.Clear();

        foreach (Block.BlockType type in System.Enum.GetValues(typeof(Block.BlockType)))
        {
            int attitude = block.GetAttitude(type);
            if (attitude != 0)
            {
                GameObject icon = Instantiate(attitudeIconPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                icon.GetComponent<SpriteRenderer>().sprite = GetImage(type);
                icons.Add(icon);
            }
        }
    }

    private Sprite GetImage(Block.BlockType type)
    {
        switch (type)
        {
            case Block.BlockType.Cat:
                return catIcon;
            case Block.BlockType.Plant:
                return plantIcon;
            case Block.BlockType.Soft:
                return softIcon;
            case Block.BlockType.Sound:
                return soundIcon;
            default:
                return nullIcon;

        }
    }

    private void UpdateIcons()
    {
        for (int i = 0; i < icons.Count; i++)
        {
            icons[i].transform.position = new Vector3(transform.position.x + offset * i + 1, transform.position.y, transform.position.z);
        }
    }
}
