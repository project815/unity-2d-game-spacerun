using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class typingEffect : MonoBehaviour
{
    Text text_mission;
    AudioSource audiosource;
    int num;

    string Mission;
    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        text_mission = GetComponent<Text>();
        num = SceneManager.GetActiveScene().buildIndex;

        switch (num)
        {
            case 1:
                Mission = "First Mission :  Dodge Obstacles & Jump on Click.";
                //첫번째 미션 : 장애물을 피하기 & 클릭 시 점프
                break;
            case 2:
                Mission = "Second Mission : Dodge Asteroids & Move on Click";
                //두번째 미션 : 운석 피하기 & 클릭 시 이동
                break;
            case 3:
                Mission = "Last Mission : Reach for Destination & Move Left and Right on Click";
                break;
            default:
                return;
        }
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(_typing());
    }

    IEnumerator _typing()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i <= Mission.Length; i++)
        {
            text_mission.text = Mission.Substring(0, i);
            audiosource.Play();
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(2f);

        for (int i = Mission.Length; i >= 0; i--)
        {
            text_mission.text = Mission.Substring(0, i);
            audiosource.Play();
            yield return new WaitForSeconds(0.05f);
        }
    }

}
