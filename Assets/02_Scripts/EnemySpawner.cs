using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] StageData stageData;
    [SerializeField] float spawnTime;

    ObjectPooler enemyPooler;
    private void Awake()
    {
        enemyPooler = GetComponent<ObjectPooler>();
    }
    void Start()
    {
        StartCoroutine("SpawnEnemy");               
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float positionX = Random.Range(stageData.LimitMin.x, stageData.LimitMax.x);
            Vector3 enemyPosition = new Vector3(positionX, stageData.LimitMax.y + 1f);
            //Instantiate(enemyPrefab,enemyPosition,Quaternion.identity);
            enemyPooler.SpawnObject(enemyPosition, transform.rotation);

            yield return new WaitForSeconds(spawnTime);
        }
    }

}
