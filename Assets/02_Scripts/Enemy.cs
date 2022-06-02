using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float damage = 1f;
    [SerializeField] int scorePoint = 100;
    [SerializeField] GameObject explosionPrefab;

    PlayerController playerController;
    ObjectPooler enemyPooler;
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        enemyPooler = GameObject.Find("EnemySpawner").GetComponent<ObjectPooler>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHP>().TakeDamage(damage);
            OnDie();
        }
    }
    public void OnDie()
    {
        GameObject cloneExp = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        playerController.Score += scorePoint;
        //Destroy(gameObject);        
        enemyPooler.ReturnObject(gameObject);
        Destroy(cloneExp.gameObject, 1f);
    }
}
