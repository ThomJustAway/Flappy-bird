using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeReverseMiddleBehaviour : MonoBehaviour
{
    private LogicScript logicScript;
    private GameObject player;
    private void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("logicMachine").GetComponent<LogicScript>();
        player = GameObject.FindGameObjectWithTag("player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(player);
        if (collision.gameObject.layer == 3)
        {
            logicScript.AddScore();
            Rigidbody2D playerRigidbody2D = player.GetComponent<Rigidbody2D>();
            PlayerBehaviour playerBehaviour = player.GetComponent<PlayerBehaviour>();
            playerRigidbody2D.gravityScale *= -1;
            playerBehaviour.ReverseGravity();
            
        }
    }
}
