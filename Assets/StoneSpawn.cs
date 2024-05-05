using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSpawn : MonoBehaviour
{
    private Vector2 SpawnPos;
    public GameObject spawnObject;
    GameObject tmpObject;
    private float newSpawnDuration = 1f;
    public static StoneSpawn Instance;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = transform.position;
        NewSpawnRequest();

    }
    private void Update()
    {


    }
    void SpawnNewObject()
    {
        tmpObject = Instantiate(spawnObject, SpawnPos, Quaternion.identity);

    }

    public void NewSpawnRequest()
    {
        Invoke("SpawnNewObject", newSpawnDuration);
    }

    public void RetrySpawnRequest()
    {


        Invoke("SpawnNewObject", newSpawnDuration);

        Destroy(tmpObject, 2f);


    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name.Contains("DropStone")|| collision.gameObject.name.Equals("BallDestroyPoint"))
        {

            RetrySpawnRequest();


        }
    }
    */
}
