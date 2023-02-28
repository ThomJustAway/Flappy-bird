using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float jumpforce = 8f;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flyAudio;

    private Rigidbody2D rb;
    private LogicScript logicScript;
    private bool birdAlive = true;
    private bool hasStarted = false;
    private string flyKeyword = "fly";


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logicScript = GameObject.FindGameObjectWithTag("logicMachine").GetComponent<LogicScript>();
    }

    private void Update()
    {
        if (hasStarted)
        {
            FlyPath();
        }
        else
        {
            AwaitFlying();
        }
    }

    private void AwaitFlying()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasStarted = true;
            rb.gravityScale = 2;
            logicScript.StartGame();
            Fly(true);
        }
    }
    private void FlyPath()
    {

        if (Input.GetKeyDown(KeyCode.Space) && birdAlive )
        {
            Fly(true);
        }
        else
        {
            Fly(false);
        }
    }

    private void Fly(bool isFlying)
    {
        if (isFlying)
        {
            rb.velocity = Vector2.up * jumpforce;
            animator.SetBool(flyKeyword, isFlying);
            audioSource.clip = flyAudio;
            audioSource.Play();
            
        }
        else
        {
            animator.SetBool(flyKeyword, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdAlive = false;
    }

    public bool HasStarted()
    {
        return hasStarted;
    }
}
