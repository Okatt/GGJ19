﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BlockType { Empty, Cat, Violet, Pink, Orange, Green, Blue};

    public BlockType type;

    private BoxCollider2D boxCollider;

    // Attitude
    public int mood;
    public List<AttitudeData> attitude;

    // Raycasts to check neighbours
    public LayerMask collisionMask;
    private RaycastOrigins raycastOrigins;
    private float rayLength = 0.2f;

    private Color rayColour;
    private Color rayColourGood = Color.green;
    private Color rayColourNeutral = Color.grey;
    private Color rayColourBad = Color.red;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        UpdateRaycastOrigins();

        // TODO: only check whenever it makes sense, when the last dropped block has a velocity of 0?
        UpdateMood();
    }

    private void UpdateMood()
    {
        // Recalculate mood
        mood = 0;

        // Check neighbours
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastOrigins.left, new Vector3(-1, 0), rayLength, collisionMask);
        if (hitLeft)
        {
            GameObject other = hitLeft.collider.gameObject;
            int attitude = GetAttitude(other.GetComponent<Block>().type);

            if (attitude != 0) { rayColour = attitude > 0 ? rayColourGood : rayColourBad; }
            else { rayColour = rayColourNeutral; }
            Debug.DrawRay(raycastOrigins.left, new Vector3(-1, 0) * rayLength, rayColour);

            mood += attitude;            
        }

        RaycastHit2D hitRight = Physics2D.Raycast(raycastOrigins.right, new Vector3(1, 0), rayLength, collisionMask);
        if (hitRight)
        {
            GameObject other = hitRight.collider.gameObject;
            int attitude = GetAttitude(other.GetComponent<Block>().type);

            if (attitude != 0) { rayColour = attitude > 0 ? rayColourGood : rayColourBad; }
            else { rayColour = rayColourNeutral; }
            Debug.DrawRay(raycastOrigins.right, new Vector3(1, 0) * rayLength, rayColour);

            mood += attitude;
        }

        RaycastHit2D hitTop = Physics2D.Raycast(raycastOrigins.top, new Vector3(0, 1), rayLength, collisionMask);
        if (hitTop)
        {
            GameObject other = hitTop.collider.gameObject;
            int attitude = GetAttitude(other.GetComponent<Block>().type);

            if (attitude != 0) { rayColour = attitude > 0 ? rayColourGood : rayColourBad; }
            else { rayColour = rayColourNeutral; }
            Debug.DrawRay(raycastOrigins.top, new Vector3(0, 1) * rayLength, rayColour);

            mood += attitude;
        }

        RaycastHit2D hitBottom = Physics2D.Raycast(raycastOrigins.bottom, new Vector3(0, -1), rayLength, collisionMask);
        if (hitBottom)
        {
            GameObject other = hitBottom.collider.gameObject;
            int attitude = GetAttitude(other.GetComponent<Block>().type);

            if (attitude != 0) { rayColour = attitude > 0 ? rayColourGood : rayColourBad; }
            else { rayColour = rayColourNeutral; }
            Debug.DrawRay(raycastOrigins.bottom, new Vector3(0, -1) * rayLength, rayColour);

            mood += attitude;  
        }
    }

    // Returns the this block's attitude of type, value can be positive or negative.
    private int GetAttitude(BlockType type)
    {
        for (int i = 0; i < attitude.Count; i++)
        {
            AttitudeData data = attitude[i];
            if (data.type == type) return data.value;
        }
        return 0;
    }

    private void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(0.1f);

        raycastOrigins.left = new Vector2(bounds.min.x, bounds.center.y);
        raycastOrigins.right = new Vector2(bounds.max.x, bounds.center.y);
        raycastOrigins.top = new Vector2(bounds.center.x, bounds.max.y);
        raycastOrigins.bottom = new Vector2(bounds.center.x, bounds.min.y);
    }

    [System.Serializable]
    public struct AttitudeData
    {
        public BlockType type;
        public int value;
    }

    private struct RaycastOrigins
    {
        public Vector2 left, right, bottom, top;
    }
}