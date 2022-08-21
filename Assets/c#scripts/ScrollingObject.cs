using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;
    public Direction direction;
    public enum Direction
    {
        LEFT,
        RIGHT,
        TOP,
        BOTTOM,
    }



    void Update()
    {

        if(direction == Direction.LEFT)
        {
            transform.position += (Vector3.left * speed * Time.deltaTime);
        }
        if (direction == Direction.RIGHT)
        {
            transform.position += (Vector3.right * speed * Time.deltaTime);
        }

        if (direction == Direction.TOP)
        {
            transform.position += (Vector3.up * speed * Time.deltaTime);
        }
        if (direction == Direction.BOTTOM)
        {
            transform.position += (Vector3.down * speed * Time.deltaTime);
        }

    }

   
}
