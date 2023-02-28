using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject pipe;
    [SerializeField] private GameObject pipeLong;
    [SerializeField] private GameObject pipeSide;
    [SerializeField] private int spawnTime = 2;
    [SerializeField] private float heightOffset = 2.0f;
    [SerializeField] private PlayerBehaviour playerBehaviour;
    [SerializeField] private LogicScript logicScript;
    private float counter = 0;


    // Update is called once per frame
    void Update()
    {
        if (counter <spawnTime || !playerBehaviour.HasStarted())
        {
            //if the player has not started, do this
            counter += Time.deltaTime;

        }
        else
        {
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        counter = 0;


        int score = logicScript.ViewCurrentScore();
        Debug.Log(score);
        if (score > 20)
        {
            int chance = Random.Range(1,6);
            if(chance==6)
            {
                CreatePipe(pipeLong);
            }
            else if (chance == 5)
            {
                CreatePipe(pipeSide);
            }
            else
            {
                CreatePipe(pipe);
            }
        }
        else
        {
            CreatePipe(pipe);
        }
    }

    private void CreatePipe(GameObject pipeType)
    {
        float highestPoint = transform.position.y + heightOffset;
        float lowestPoint = transform.position.y - heightOffset;
        //Instantiate(pipeType, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        if(pipeType == pipeSide)
        {
            Instantiate(pipeType, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(pipeType, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }

    }
}
