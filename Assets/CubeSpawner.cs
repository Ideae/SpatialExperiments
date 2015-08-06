using UnityEngine;
using System.Collections;

public class CubeSpawner : MonoBehaviour {
    public GameObject cubePrefab;
    public bool randomizeOnStart = true;
    public float radius = 3f;
    public int cubeLayers = 10;
    public float inwardWaveAmp = 1f;
    public float inwardWaveFreq = 5f;
    public float rotateWaveAmp = 1f;
    public float rotateWaveFreq = 5f;

    GameObject[,] cubes;
    float cubeHeight;
    int cubeAmount;
    
    void Start () {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        if (cubes != null)
        {
            foreach(var cube in cubes)
            {
                Destroy(cube);
            }
        }

        if (randomizeOnStart)
        {
            radius = Random.Range(1f, 10f);
            cubeLayers = Random.Range(1, 40);
            inwardWaveAmp = Random.Range(0.2f, 3f);
            inwardWaveFreq = Random.Range(0.5f, 5f);
            rotateWaveAmp = Random.Range(0.2f, 3f);
            rotateWaveFreq = Random.Range(0.5f, 5f);
        }

        var renderer = cubePrefab.GetComponent<Renderer>();
        float circum = 2f * Mathf.PI * radius;
        float cubeWidth = renderer.bounds.size.x;
        cubeHeight = renderer.bounds.size.y;
        cubeAmount = (int)Mathf.Floor(circum / cubeWidth);

        cubes = new GameObject[cubeLayers, cubeAmount];

        for (var h = 0; h < cubeLayers; h++)
        {
            for (int i = 0; i < cubeAmount; i++)
            {
                Vector3 cubePos = spiralThing(h, i);
                var g = (GameObject)Instantiate(cubePrefab, cubePos, Quaternion.identity);
                g.transform.SetParent(transform);
                cubes[h, i] = g;
            }
        }
    }
	
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnCubes();
            return;
        }
        if (cubes == null) return;
        cubeAmount = cubes.GetLength(1);
        cubeLayers = cubes.GetLength(0);
        for (var h = 0; h < cubeLayers; h++)
        {
            for (int i = 0; i < cubeAmount; i++)
            {
                Vector3 cubePos = spiralThing(h, i);
                cubes[h, i].transform.position = cubePos;
            }
        }
    }

    Vector3 spiralThing(int h, int i)
    {
        float angle = 2f * Mathf.PI * (i / (float)cubeAmount);
        float radiusWave = radius + (inwardWaveAmp * Mathf.Sin(angle * inwardWaveFreq + Time.time));
        angle += rotateWaveAmp * Mathf.Sin(h * rotateWaveFreq + Time.time);
        Vector3 cubePos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radiusWave;
        cubePos.y = h * cubeHeight;
        return cubePos;
    }
}
