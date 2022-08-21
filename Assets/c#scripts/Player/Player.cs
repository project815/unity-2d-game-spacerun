using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public float jumpForce = 700f;
    public GameObject distance_obj;
    public Text text_distance;

    private int jumpCount = 0;
    private bool isGround = false;
    private bool isDead = false;

    public GameObject ground;
    public PlayableDirector playabledirector;

    private Rigidbody2D rd;
    private Animator animator;

    AudioSource audioSource;
    public AudioClip Clip_Jump;
    public AudioClip Clip_death;

    int num;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {

        float dist = Vector3.Distance(transform.position, distance_obj.transform.position);
        text_distance.text = "LEFT DIST : " + dist.ToString("F0") + "m";
    }
    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            rd.velocity = Vector2.zero;

            rd.AddForce(new Vector2(0, jumpForce));
            audioSource.clip = Clip_Jump;
            audioSource.Play();
        }
        else if(Input.GetMouseButtonUp(0) && jumpCount > 0)
        {
            rd.velocity = rd.velocity * 0.5f;
        }
        num = Random.Range(0, 255);

    }
    private void Die()
    {
        animator.SetTrigger("Death");
        audioSource.clip = Clip_death;
        audioSource.Play();
        isDead = true;
        rd.velocity = Vector2.zero;
        ground.GetComponent<ScrollingObject>().speed = 0f;

        Invoke("PlayerDeath", 1.5f);
    }
    void PlayerDeath()
    {
        Destroy(gameObject);
        GameManager.instance.OnPlayerDead();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Dead" && !isDead)
        {
            Debug.Log("Dead");
            Die();
        }
        if (other.tag == "Coin")
        {
            GameManager.instance.AddScore(10);
            Destroy(other.gameObject);
        }
        if (other.tag == "Coin_2")
        {
            GameManager.instance.AddScore(20);
            Destroy(other.gameObject);
        }

        if(other.tag == "Next")
        {
            playabledirector.Play();
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGround = true;
            jumpCount = 0;
        } 
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
