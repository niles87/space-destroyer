using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] smallEnemyRef;
    [SerializeField]
    private GameObject[] largeEnemyRef;
    [SerializeField]
    private GameObject[] motherShipRef;

    private int minX = -7, maxX = 7;

    private int randomIndex;
    private float randomSpawn;

    private Vector3 pos;

    private GameObject enemy;

    private void Awake()
    {
        pos = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));

            /* 
             randomIndex = Random.Range(0, smallEnemyRef.Length);

             */
            randomSpawn = Random.Range(minX, maxX);
            // for now just 0 since all other enemy animations have not been completed
            enemy = Instantiate(smallEnemyRef[0]);

            enemy.transform.position = new Vector3(randomSpawn, pos.y);
            enemy.GetComponent<EnemyController>().speed = Random.Range(3, 8);
        }
        
    }
}
