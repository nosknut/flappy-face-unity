using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGen : MonoBehaviour {

    public struct Pipe
    {
        public int index;
        public GameObject pipe;

        public Pipe(GameObject v1, int v2)
        {
            pipe = v1;
            index = v2;
        }
    }

    public float hMax;
    public float hMin;
    public float pipeSpace;
    public GameObject player;
    public GameObject samplePipe;
    public int numPipes;
    List<Pipe> pipes = new List<Pipe>();

    // Use this for initialization
    void Start ()
    {
        for(int i = 0; i < (numPipes - 1); i++)
        {
            
            pipes.Add(new Pipe(Instantiate(samplePipe), i));
            //Debug.Log(pipes[i].index);
        }
        generate();
    }

    void generate()
    {
        foreach (Pipe pipe in pipes)
        {

            pipe.pipe.GetComponent<Rigidbody2D>().transform.position = new Vector2((pipe.index * pipeSpace), Random.Range(hMax, hMin));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /*
        pipes.Add(new Pipe(Instantiate(samplePipe), pipes.Count));
        pipes[(pipes.Count - 1)].pipe.GetComponent<Rigidbody2D>().transform.position = new Vector2((pipes[(pipes.Count - 1)].index * pipeSpace), Random.Range(hMax, hMin));
        pipes.RemoveAt(0);
        Debug.Log("Added pipe");
        */
    }

    void Update () {
        //generate();
        /*
        pipes.Add(new Pipe(Instantiate(samplePipe), pipes.Count));
        pipes[(pipes.Count - 1)].pipe.GetComponent<Rigidbody2D>().transform.position = new Vector2((pipes[(pipes.Count - 1)].index * pipeSpace), Random.Range(hMax, hMin));
        Object.Destroy(pipes[0].pipe);
        pipes.RemoveAt(0);
        Debug.Log("Added pipe");
        */
    }
}
