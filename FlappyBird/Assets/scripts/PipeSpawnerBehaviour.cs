using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
class Pipe
{
    public string name;
    public GameObject prefab;
    public float spawnTime = 2;
    public float heightOffSet=0f;
}

public class PipeSpawnerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Pipe[] pipes;
    [SerializeField] private float spawnTime = 2;
    [SerializeField] private PlayerBehaviour playerBehaviour;
    [SerializeField] private LogicScript logicScript;
    private float counter = 0;
    private float[] chance;

    // Update is called once per frame
    private void Awake()
    {
        //the order is 
        /*
         1.normal pipe
         2.long pipe
         3.side pipe(upward)
         4.gravity changing pipe
         */
        chance = new float[pipes.Length];
        chance[0] = 100.00f;
    }


    private void Update()
    {
        if (counter <spawnTime || !playerBehaviour.HasStarted())
        {
            //if the player has not started, do this
            counter += Time.deltaTime;
        }
        else
        {
            Chance();

            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        counter = 0;

        //spawning of pipe
        Pipe selectedPipe = pipes[selectedRandomPipe()];
        CreatePipe(selectedPipe);

    }

    private int selectedRandomPipe()
    {
        float random = Random.Range(0,101);
        float accumalatedWeight = 0.0f;
        Debug.Log(random);
        for(int i = 0; i < chance.Length; i++)
        {
            accumalatedWeight+=chance[i];

            if (accumalatedWeight >= random)
            {
                Debug.Log(i);
                return i;
            }
        }
        return 0;

    }

    private void Chance()
    {
        //the order is 
        /*
         0.normal pipe
         1.long pipe
         2.side pipe(upward)
         3.gravity changing pipe
         */
        int score = logicScript.ViewCurrentScore();
        if(score >=20 && score <= 30)
        {
            chance[0] = 20;
            chance[1] = 40;
            chance[2] = 20;
            chance[3] = 20;
        }
        else if(score>30)
        {
            chance[0] = 10;
            chance[1] = 10;
            chance[2] = 20;
            chance[3] = 20;
            chance[4] = 50;
        }
    }
    private void CreatePipe(Pipe pipeType)
    {
        float highestPoint = transform.position.y + pipeType.heightOffSet;
        float lowestPoint = transform.position.y - pipeType.heightOffSet;
        spawnTime = pipeType.spawnTime;
        Instantiate(pipeType.prefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
