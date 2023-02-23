using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpforce = 8f;
    private LogicScript logicScript;
    private bool birdAlive = true;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        logicScript = GameObject.FindGameObjectWithTag("logicMachine").GetComponent<LogicScript>();

    }

    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space) && birdAlive)
        {
            //rb.AddForce(new Vector2(0, jumpforce),ForceMode2D.Impulse);
            rb.velocity = Vector2.up * jumpforce; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logicScript.GameOver();
        birdAlive = false;
    }
}
