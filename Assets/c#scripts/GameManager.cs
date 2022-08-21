using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameOver = false;
    public Text scoreText;
    public Text bestscoreText;
    public GameObject gameoverUI;
    public GameObject missionUI;


    private static int score;
    private static int bestscore;

    AudioSource audioSource;
    public AudioClip Cilp_Score;
    public AudioClip Cilp_Lose;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scoreText.text = "SCORE : " + score;
        bestscoreText.text = "BEST SCORE : " + bestscore;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SoundManager.instance.GetComponent<AudioSource>().Play();

        }

    }
    public void AddScore(int plusScore)
    {
        if(!isGameOver)
        {
            score += plusScore;
            scoreText.text = "SCORE : " + score;
            audioSource.clip = Cilp_Score;
            audioSource.Play();

        }
    }

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUI.SetActive(true);
        missionUI.SetActive(false);
        audioSource.clip = Cilp_Lose;
        audioSource?.Play();  
        if (score >= bestscore)
        {
            bestscore = score;
            bestscoreText.text = "BEST SCORE : " + bestscore;
        }
        score = 0;
        SoundManager.instance.GetComponent<AudioSource>().Pause();

    }
}
