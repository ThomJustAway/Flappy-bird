using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleBehaviour : MonoBehaviour
{
    private LogicScript logicScript;
    private void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("logicMachine").GetComponent<LogicScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
        logicScript.AddScore();

        }
    }
}
