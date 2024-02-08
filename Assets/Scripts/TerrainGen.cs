using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour {

    public struct Terrain
    {
        public int index;
        public GameObject terrain;

        public Terrain(GameObject _terrain, int _index)
        {
            terrain = _terrain;
            index = _index;
        }
    }
    
    public float terrainSpacing;
    public GameObject player;
    public GameObject sampleTerrain;
    public GameObject roof;

    public int numTerrains;

    List<Terrain> terrains = new List<Terrain>();
    
    void Start()
    {
        for (int i = 0; i < (numTerrains - 1); i++)
        {

            terrains.Add(new Terrain(Instantiate(sampleTerrain), i));
            //Debug.Log(terrains[i].index);
        }
        generate();
    }

    void generate()
    {
        foreach (Terrain terrain in terrains)
        {
            
            terrain.terrain.GetComponent<Rigidbody2D>().transform.position = new Vector2((terrain.index * terrainSpacing), terrain.terrain.GetComponent<Rigidbody2D>().transform.position.y);
        }
    }

    void moveTerrain()
    {
        foreach(Terrain terrain in terrains) {
            terrain.terrain.GetComponent<Rigidbody2D>().transform.position = new Vector2((terrain.index * terrainSpacing), terrain.terrain.GetComponent<Rigidbody2D>().transform.position.y);
        }
    }

    void moveRoof()
    {
        roof.GetComponent<Rigidbody2D>().transform.position = new Vector2(player.GetComponent<Rigidbody2D>().transform.position.x, roof.GetComponent<Rigidbody2D>().transform.position.y);
    }

    void Update()
    {
        moveRoof();

    }
}