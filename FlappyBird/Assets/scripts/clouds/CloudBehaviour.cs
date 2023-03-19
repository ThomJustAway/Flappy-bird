using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    private float speed;
    private float endPoint;

    public void StartFloating(float speed,float endpoint)
    {
        this.speed = speed;
        this.endPoint = endpoint;
    }

    // Update is called once per frame
    void Update()
    {
        float move = speed * Time.deltaTime;
        transform.Translate(Vector3.left * move);
        if(transform.position.x < endPoint)
        {
            Destroy(gameObject);
        }
    }
}
