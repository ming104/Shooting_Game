using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject Player;

    int poolSize = 10;
    GameObject[] EnemyObjectPool;

    public float currentTime;
    float createTime = 2.0f;

    float minTime = 0.2f;
    float maxTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        EnemyObjectPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject Enemy = Instantiate(EnemyPrefab);
            Enemy.SetActive(false);
            EnemyObjectPool[i] = Enemy;
        }
    }

    // Update is called once per frame
    void Update()
    {
        CreateEnemy();
    }

    void CreateEnemy()
    {
        currentTime += Time.deltaTime;
        if (currentTime > createTime)
        {
           
            float xRan = Random.Range(-3, 3);
            for (int i = 0; i < poolSize; i++)
            {
                GameObject Enemy = EnemyObjectPool[i];
                if (Enemy.activeSelf == false)
                {
                    Enemy.transform.position = new Vector3(xRan, 6f, 0f);
                    Enemy.SetActive(true);
                    break;
                }
                
            }
            createTime = Random.Range(minTime, maxTime);
            currentTime = 0;
        }
        //Instantiate(EnemyPrefab, new Vector3(xRan, 5.5f, Player.transform.position.z), Quaternion.identity);
    }
}
