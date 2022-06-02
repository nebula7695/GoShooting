using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField] StageData stageData;
    float destroyWeight = 2.0f;

    ObjectPooler bulletPooler;
    ObjectPooler enemyPooler;
    private void Start()
    {
        bulletPooler = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectPooler>();
        enemyPooler = GameObject.Find("EnemySpawner").GetComponent<ObjectPooler>();
    }
    void LateUpdate()
    {
        if (transform.position.x < stageData.LimitMin.x - destroyWeight ||
            transform.position.x > stageData.LimitMax.x + destroyWeight ||
            transform.position.y < stageData.LimitMin.y - destroyWeight ||
            transform.position.y > stageData.LimitMax.y + destroyWeight)
        {
            if (gameObject.CompareTag("Projectile"))
            {
                bulletPooler.ReturnObject(gameObject);
            }
            else if (gameObject.CompareTag("Enemy"))
            {
                enemyPooler.ReturnObject(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        } 

    }
}
