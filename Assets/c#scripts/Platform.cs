using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    //public GameObject[] obstacles;
    //private bool stepped = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.SetActive(false);
        }
        
    }
    //private void OnEnable()
    //{
    //    int random_num = Random.Range(0, obstacles.Length);
    //    stepped = false;
    //    obstacles[random_num].SetActive(true);

    //    //for (int i = 0; i < obstacles.Length; i++)
    //    //{
    //    //    if( == 0)
    //    //    {
    //    //    }
    //    //    else
    //    //    {
    //    //        obstacles[i].SetActive(false);
    //    //    }
    //    //}
    //}
    private void Start()
    {
        //Destroy(this.gameObject, 10);

    }
}
