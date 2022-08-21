using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectManager : MonoBehaviour
{
    public GameObject asteroid1_Prefab;
    public GameObject asteroid2_Prefab;
    public GameObject asteroid3_Prefab;
    public GameObject asteroid4_Prefab;
    public GameObject asteroid5_Prefab;
    public GameObject coin1_Prefab;
    public GameObject coin2_Prefab;


    GameObject[] asteroid1;
    GameObject[] asteroid2;
    GameObject[] asteroid3;
    GameObject[] asteroid4;
    GameObject[] asteroid5;
    GameObject[] coin1; 
    GameObject[] coin2; 

    GameObject[] targetPool_obj;
    GameObject[] targetPool_coin;

    private void Awake()
    {
        asteroid1 = new GameObject[10];
        asteroid2 = new GameObject[10];
        asteroid3 = new GameObject[10];
        asteroid4 = new GameObject[10];
        asteroid5 = new GameObject[10];
        coin1 = new GameObject[5];
        coin2 = new GameObject[5];

        Generate();

    }
    void Generate()
    {
        for (int index = 0; index < asteroid1.Length; index++)
        {
            asteroid1[index] = Instantiate(asteroid1_Prefab);
            asteroid1[index].SetActive(false);
        }
        for (int index = 0; index < asteroid2.Length; index++)
        {
            asteroid2[index] = Instantiate(asteroid2_Prefab);
            asteroid2[index].SetActive(false);
        }
        for (int index = 0; index < asteroid3.Length; index++)
        {
            asteroid3[index] = Instantiate(asteroid3_Prefab);
            asteroid3[index].SetActive(false);
        }
        for (int index = 0; index < asteroid4.Length; index++)
        {
            asteroid4[index] = Instantiate(asteroid4_Prefab);
            asteroid4[index].SetActive(false);
        }
        for (int index = 0; index < asteroid5.Length; index++)
        {
            asteroid5[index] = Instantiate(asteroid5_Prefab);
            asteroid5[index].SetActive(false);
        }
        for (int index = 0; index < coin1.Length; index++)
        {
            coin1[index] = Instantiate(coin1_Prefab);
            coin1[index].SetActive(false);
        }
        for (int index = 0; index < coin2.Length; index++)
        {
            coin2[index] = Instantiate(coin2_Prefab);
            coin2[index].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {

        switch(type)
        {
            case "asteroid1":
                targetPool_obj = asteroid1;
                break;
            case "asteroid2":
                targetPool_obj = asteroid2;
                break;

            case "asteroid3":
                targetPool_obj = asteroid3;
                break;

            case "asteroid4":
                targetPool_obj = asteroid4;
                break;

            case "asteroid5":
                targetPool_obj = asteroid5;
                break;
        }
        for (int i = 0; i < targetPool_obj.Length; i++)
        {
            if (!targetPool_obj[i].activeSelf)
            {
                targetPool_obj[i].SetActive(true);
                return targetPool_obj[i];
            }
        }
        return null;
    }
    public GameObject MakeCoin(string type)
    {
        switch(type)
        {
            case "coin1":
                targetPool_coin = coin1;
                break;
            case "coin2":
                targetPool_coin = coin2;
                break;
        }
        for (int i = 0; i < targetPool_coin.Length; i++)
        {
            if (!targetPool_coin[i].activeSelf)
            {
                targetPool_coin[i].SetActive(true);
                return targetPool_coin[i];
            }
        }
        return null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
