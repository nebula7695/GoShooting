using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float attackRate = 0.1f;

    ObjectPooler bulletPooler;
    private void Start()
    {
        bulletPooler = GetComponent<ObjectPooler>();
    }
    public void StartFiring()
    {
        StartCoroutine("TryAttack");
    }
    public void StopFiring()
    {
        StopCoroutine("TryAttack");
    }
    IEnumerator TryAttack()
    {
        while (true)
        {
            //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            bulletPooler.SpawnObject(transform.position, transform.rotation);
            yield return new WaitForSeconds(attackRate);
        }
    }
}
