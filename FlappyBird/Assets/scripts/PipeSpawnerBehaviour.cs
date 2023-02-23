using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pipe;
    [SerializeField] private int spawnTime = 2;
    [SerializeField] private float heightOffset = 0.5f;
    private float counter = 0;
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {

        if (counter <spawnTime)
        {
            counter += Time.deltaTime;

        }
        else
        {
            counter = 0;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x,Random.Range(lowestPoint,highestPoint),0), transform.rotation);

    }
}
