using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGeneration : MonoBehaviour
{
    public GameObject[] enemys;
    public float minDelay;
    public float maxDelay;
    private float minY = -4.3f;
    private float maxY = 4.3f;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Repeat()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        Vector2 randomPosition = new Vector2(transform.position.x, Random.Range(minY, maxY));
        GameObject e = Instantiate(enemys[Random.Range(0, enemys.Length)], randomPosition, Quaternion.identity);
        Repeat();
    }
}
