using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class PlayerJoyStickControler : MonoBehaviour
{
    public GameObject distance_obj;
    public Text text_distance;

    public RectTransform transform_icon;
    public RectTransform transform_target;
    public PlayableDirector playerdirector;

    SpriteRenderer spriterender;


    public GameObject ground;
    public GameObject Spawner;

    private bool isDead = false;

    AudioSource audioSource;
    public AudioClip Clip_Death;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriterender = GetComponent<SpriteRenderer>();
        StartCoroutine(_invincibility());
        //GetComponent<Collider2D>().enabled = true;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Next")
        {
            playerdirector.Play();
            audioSource.Pause();
        }

        if (collision.tag == "Dead" && !isDead)
        {
            Debug.Log("Dead");
            Die();
        }
        if (collision.tag == "Disable")
        {
            Spawner.SetActive(false);
        }
        if (collision.tag == "Coin")
        {
            GameManager.instance.AddScore(10);
        }
        if (collision.tag == "Coin_2")
        {
            GameManager.instance.AddScore(20);
        }

    }

    private void FixedUpdate()
    {

        float dist = Vector3.Distance(transform.position, distance_obj.transform.position);
        text_distance.text = "LEFT DIST : " + dist.ToString("F0") + "m";
    }
    private void Update()
    {
        Get_MouseInput();
        Update_Moving();
    }


    private void Get_MouseInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform_target.position = mousePos;

        }
    }

    private void Update_Moving()
    {
        transform_icon.position = Vector3.Lerp(transform_icon.position, transform_target.position, 0.1f);
    }

    private void Die()
    {
        animator.SetTrigger("Death");
        isDead = true;
        audioSource.clip = Clip_Death;
        audioSource.loop = false;
        audioSource.Play();
        Invoke("PlayerDeath", 1.5f);
    }
    void PlayerDeath()
    {
        Destroy(gameObject);
        GameManager.instance.OnPlayerDead();
    }
    IEnumerator _invincibility()
    {
        GetComponent<Collider2D>().enabled = false;
        for (int i = 0; i < 30; i++)
        {
            if(i%2 == 0)
            {
                spriterender.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriterender.color = new Color(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.2f);
        }
        spriterender.color = new Color32(255, 255, 255, 255);
        GetComponent<Collider2D>().enabled = true;
        yield return null;
    }
}
