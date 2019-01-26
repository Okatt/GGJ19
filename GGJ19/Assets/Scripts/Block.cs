using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum BlockType { Empty, Cat, Violet, Pink, Orange, Green, Blue};

    public BlockType type;

    private BoxCollider2D boxCollider;

    // Attitude 
    // TODO: maintain a list of likes and dislikes.

    // Raycasts to check neighbours
    public LayerMask collisionMask;
    private RaycastOrigins raycastOrigins;
    private float rayLength = 0.2f;

    private Color rayColourGood = Color.green;
    private Color rayColourBad = Color.red;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        UpdateRaycastOrigins();

        // TODO: only check whenever it makes sense, when the last dropped block has a velocity of 0?
        GetScore();
    }

    int GetScore()
    {
        // Keep track of score
        int score = 0;

        // Check neighbours
        RaycastHit2D hitLeft = Physics2D.Raycast(raycastOrigins.left, new Vector3(-1, 0), rayLength, collisionMask);
        if (hitLeft)
        {
            GameObject other = hitLeft.collider.gameObject;
            Debug.DrawRay(raycastOrigins.left, new Vector3(-1, 0) * rayLength, rayColourGood);
        }

        RaycastHit2D hitRight = Physics2D.Raycast(raycastOrigins.right, new Vector3(1, 0), rayLength, collisionMask);
        if (hitRight)
        {
            GameObject other = hitRight.collider.gameObject;
            Debug.DrawRay(raycastOrigins.right, new Vector3(1, 0) * rayLength, rayColourGood);
        }

        RaycastHit2D hitTop = Physics2D.Raycast(raycastOrigins.top, new Vector3(0, 1), rayLength, collisionMask);
        if (hitTop)
        {
            GameObject other = hitTop.collider.gameObject;
            Debug.DrawRay(raycastOrigins.top, new Vector3(0, 1) * rayLength, rayColourGood);
        }

        RaycastHit2D hitBottom = Physics2D.Raycast(raycastOrigins.bottom, new Vector3(0, -1), rayLength, collisionMask);
        if (hitBottom)
        {
            GameObject other = hitBottom.collider.gameObject;
            Debug.DrawRay(raycastOrigins.bottom, new Vector3(0, -1) * rayLength, rayColourGood);
        }

        return score;
    }

    // Returns the this block's attitude of type, value can be positive or negative.
    int GetAttitude(BlockType type)
    {
        // TODO: check this block's attitude toward type.
        return 0;
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(0.1f);

        raycastOrigins.left = new Vector2(bounds.min.x, bounds.center.y);
        raycastOrigins.right = new Vector2(bounds.max.x, bounds.center.y);
        raycastOrigins.top = new Vector2(bounds.center.x, bounds.max.y);
        raycastOrigins.bottom = new Vector2(bounds.center.x, bounds.min.y);
    }

    struct RaycastOrigins
    {
        public Vector2 left, right, bottom, top;
    }
}
