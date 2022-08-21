using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    public enum Direction
    {
        LEFT,
        TOP,
    }
    public Direction direction;
    private float width;

    // Start is called before the first frame update
    void Start()
    {
        if(direction == Direction.TOP)
        {
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            width = col.size.y;
        }

        if (direction == Direction.LEFT)
        {
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            width = col.size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -width && direction == Direction.TOP)
        {
            RePosition_TOP();
        }
        if (transform.position.x <= -width && direction == Direction.LEFT)
        {
            RePosition_LEFT();
        }
    }
    private void RePosition_TOP()
    {
        Vector2 offset = new Vector2(0, width * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
    private void RePosition_LEFT()
    {

        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
