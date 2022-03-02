using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public delegate void TimeAction();
    public static event TimeAction OnTimeIsUp;

    public GameObject[] tilePrefabs;

    private Vector3 nextSpawnPoint;
    private float timeRemaining = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SpawnFinishTile();
            gameObject.SetActive(false);
        }
    }

    private void SpawnTile()
    {
        GameObject temp = Instantiate(tilePrefabs[Random.Range(1,5)], nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(0).transform.position;
    }

    private void SpawnFinishTile()
    {
        Instantiate(tilePrefabs[5], nextSpawnPoint, Quaternion.identity);
    }


    private void OnEnable()
    {
        GroundTile.OnTrigger += SpawnTile;
    }

    private void OnDisable()
    {
        GroundTile.OnTrigger -= SpawnTile;   
    }
}
