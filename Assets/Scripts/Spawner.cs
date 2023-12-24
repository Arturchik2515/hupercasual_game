using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private bool isVertical = true;
    [SerializeField] private float spawnTime = 5;
    [SerializeField] private float k = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        while (true)
        {
            SpawnEnemy();
            if(spawnTime > 0.5) spawnTime = spawnTime - k;
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void SpawnEnemy()
    {
       if(isVertical)
       {
            float topY = transform.position.y + transform.localScale.y/2;
            float bottomY = transform.position.y - transform.localScale.y/2;
            float spawnY = Random.Range(bottomY, topY);
            Vector3 enemyPos = new Vector3(transform.position.x, spawnY, 0);
            Instantiate(enemy, enemyPos, Quaternion.identity);
       }
       else
       {
            float leftX = transform.position.x - transform.localScale.x/2;
            float rightX = transform.position.x + transform.localScale.x/2;
            float spawnX = Random.Range(leftX, rightX);
            Vector3 enemyPos = new Vector3(spawnX, transform.position.y, 0);
            Instantiate(enemy, enemyPos, Quaternion.identity);
       } 
    }
}
