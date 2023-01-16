using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMapGeneration : MonoBehaviour
{
    public int depth = 20;

    public int width = 256;
    public int height = 256;
    public int scale = 10;

    //public Transform[] Locations;
    //public GameObject[] Components;

    //private void Awake()
    //{
    //    for (int i = 0; i <= Locations.Length; i++)
    //    {
    //        int s = Random.Range(0, Components.Length);
    //        Instantiate(Components[s], Locations[i].position, Quaternion.identity);
    //    }
    //}

    private void Start()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.gameObject.transform.position = new Vector3(-41.6127472f, -2.38146639f, -33.4000015f);
    }

    private void Update()
    {
        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = Generate(terrain.terrainData);
    }

    TerrainData Generate(TerrainData data)
    {
        data.heightmapResolution = width + 1;

        data.size = new Vector3(width, depth, height);

        data.SetHeights(0, 0, GenerateHeights());

        return data;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                heights[i, j] = CalculateHeights(i, j);
            }
        }
        return heights;
    }

    float CalculateHeights (int x, int y)
    {
        float cordX = (float)x / width * scale;
        float cordY = (float)y / height * scale;

        return Mathf.PerlinNoise(cordX, cordY);
    }
}
