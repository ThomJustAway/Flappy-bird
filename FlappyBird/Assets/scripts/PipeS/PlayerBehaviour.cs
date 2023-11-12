using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float jumpforce = 8f;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flyAudio;
    [SerializeField] private float rotationSpeed;

    private Vector2 moveMentDirection;
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

    private void FixedUpdate()
    {
        HandleRotation();
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
            moveMentDirection = new Vector2(0,1f);
        }
        else
        {
            animator.SetBool(flyKeyword, false);
            moveMentDirection = new Vector2(0, -1);
        }

    }

    private void HandleRotation()
    {
        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, moveMentDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        Debug.Log("The target Rotation is " + targetRotation);
        Debug.Log("The rotation is " +rotation);
        rb.MoveRotation(rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdAlive = false;
    }

    public void ReverseGravity()
    {
        jumpforce = jumpforce * -1;
        Debug.Log(transform.rotation.x);
        if (transform.rotation.x > 0.5)
        {
            
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else
        {
            transform.rotation = new Quaternion(180, 0, 0, 1);

        }
    }
    public bool HasStarted()
    {
        return hasStarted;
    }
}
