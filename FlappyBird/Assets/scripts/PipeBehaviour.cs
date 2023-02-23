using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    [SerializeField] private float pipeSpeed = 5;
    [SerializeField] private float deadZone = -35;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * pipeSpeed * Time.deltaTime);
        if(transform.position.x <= deadZone)
        {
            Destroy(gameObject);
        }
    }
}
