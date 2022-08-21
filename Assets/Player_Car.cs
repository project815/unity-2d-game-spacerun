using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Car : MonoBehaviour
{
    public float speed;
    public GameObject distance_obj;
    public Text text_distance;

    public WheelJoint2D joint_FrontWheel;
    public WheelJoint2D joint_BackWheel;

    public RawImage Fadein;

    public float Cartorque;
    public Rigidbody2D Car;

    public Animator animator;

    private float Movement = 0f;
    private bool isDead = false;

    public ParticleSystem Particle_CarSmoke;
    public AudioClip Clip_death;
    public AudioClip Clip_engine;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Debug.Log("Dead");
            Die();
        }
        if(other.tag == "Last")
        {
            SceneManager.LoadScene(4);

        }
    }

     private void FixedUpdate()
    {

        if (Movement == 0f)
        {
            JointMotor2D motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 100000f };
            joint_FrontWheel.motor = motor;
            joint_BackWheel.motor = motor;
            joint_FrontWheel.useMotor = false;
            joint_BackWheel.useMotor = false;
            audioSource.Pause();
            Particle_CarSmoke.Stop();
        }
        else
        {
            joint_FrontWheel.useMotor = true;
            joint_BackWheel.useMotor = true;

            JointMotor2D motor = new JointMotor2D { motorSpeed = Movement * speed, maxMotorTorque = 100000f };
            joint_FrontWheel.motor = motor;
            joint_BackWheel.motor = motor;
            audioSource.clip = Clip_engine;
            if(!audioSource.isPlaying)
            {
                Particle_CarSmoke.Play();

                audioSource.Play();
            }
            else
            {
                return;
            }
        }

        float dist = Vector3.Distance(transform.position, distance_obj.transform.position);
        text_distance.text = "LEFT DIST : " + dist.ToString("F0") + "m";
    }

    private void Update()
    {
        Movement = -CrossPlatformInputManager.GetAxisRaw("Horizontal");

    }

    private void Die()
    {
        animator.SetTrigger("Death");
        audioSource.clip = Clip_death;
        audioSource.Play();
        isDead = true;

        Invoke("PlayerDeath", 2f);
    }
    void PlayerDeath()
    {
        GameManager.instance.OnPlayerDead();
        Destroy(gameObject);
    }


}
