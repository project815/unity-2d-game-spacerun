using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject[] platformPrefab;

    public float timeBetSpawnMin = 1.25f;
    public float timeBetSpawnMax = 2.25f;
    private float timeBetSpawn;

    private GameObject[] platform;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, 25);
    private float lastSpawnTime;


    public string[] Asteroid;
    public string[] Coin;
    public objectManager objectmanager;

    private void Awake()
    {
        //_Pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, maxSize: 5);
        Asteroid = new string[] { "asteroid1", "asteroid2", "asteroid3", "asteroid4", "asteroid5" };
        Coin = new string[] { "coin1", "coin2" };
    }
    [SerializeField]
    private GameObject Asetriod;

    private void Start()
    {
        //StartCoroutine(CreateAsteroidRoutine());
        //platform = new GameObject[platformPrefab.Length];

        //for(int i = 0; i < platformPrefab.Length; i++)
        //{
        //    //platform[i] = Instantiate(platformPrefab[i], Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 2.1f, 1)), Quaternion.identity);
        //}
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;
    }


    private void Update()
    {
        if (GameManager.instance.isGameOver)
        {
            return;
        }
        if (Time.time >= lastSpawnTime + timeBetSpawn)
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax);

            //for(int i = 0; i <= platformPrefab.Length; i++)
            //{
            //    platform[i].SetActive(false);
            //    platform[i].SetActive(true);
            //    //platform[i].transform.position =
            //    //    Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 1));

            //    if(platform[i].gameObject.transform.position.y <= -10f)
            //    {
            //        platform[i].transform.position =
            //         Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), -1.1f, 1));
            //    }
            //}

            //var bullet = _Pool.Get();
            //bullet.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 1));

            //currentIndex++;

            //if(currentIndex >= count)
            //{
            //    currentIndex = 0;
            //}

            SpawnAsteroid();
        }


    }
    void SpawnAsteroid()
    {
        int ranNum1 = Random.Range(0, Asteroid.Length);
        GameObject obj1 = objectmanager.MakeObj(Asteroid[ranNum1]);
        obj1.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0f, 1f), 1.1f, 1));

        int ranNum2 = Random.Range(0, Coin.Length);
        GameObject obj2 = objectmanager.MakeCoin(Coin[ranNum2]);
        obj2.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0f, 1f), 1.1f, 1));

    }

    //private Bullet CreateBullet()
    //{
    //    Bullet bullet = Instantiate(platformPrefab[0]).GetComponent<Bullet>();
    //    bullet.SetMaanagePool(_Pool);
    //    return bullet;
    //}
    //private void OnGetBullet(Bullet bullet)
    //{
    //    bullet.gameObject.SetActive(true);
    //}
    //private void OnReleaseBullet(Bullet bullet)
    //{
    //    bullet.gameObject.SetActive(false);
    //}

    //private void OnDestroyBullet(Bullet bullet)
    //{
    //    Destroy(bullet.gameObject);
    //}
    //IEnumerator CreateAsteroidRoutine()
    //{
    //    while (true)
    //    {
    //        CreateAsteroid();
    //        yield return new WaitForSeconds(3);
    //    }
    //}
    //private void CreateAsteroid()
    //{
    //    Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 2.1f, 0));
    //    pos.z = 0;
    //    Instantiate(Asetriod, pos, Quaternion.identity);

    //}

}
