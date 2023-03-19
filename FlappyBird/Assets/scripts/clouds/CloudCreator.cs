using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudCreator : MonoBehaviour
{
    [SerializeField] private GameObject endPoint;
    [SerializeField]  private GameObject cloud;
     private float spawnTime = 2f;
     private float heightOffSet= 4.6f;
    private void Start()
    {
        PreWarm();
        Invoke("AttemptSpawn", spawnTime);
        
    }

    private void PreWarm()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnCloud(Random.Range(-6f,11f));
        }
    }

    private void SpawnCloud(float positionx)
    {
        float heightDiff = Random.Range(-heightOffSet, heightOffSet);
        Vector3 spawnPoint = new Vector3 (positionx,transform.position.y+heightDiff,transform.position.z);
        GameObject cloneCloud =Instantiate(cloud, spawnPoint, transform.rotation);

        float speed = Random.Range(2f, 3.5f);
        float ending = endPoint.transform.position.x;
        cloneCloud.GetComponent<CloudBehaviour>().StartFloating(speed, ending);

    }

    private void AttemptSpawn()
    {
        SpawnCloud(transform.position.x);

        Invoke("AttemptSpawn", spawnTime);
    }
}
