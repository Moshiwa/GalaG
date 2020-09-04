using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceGeneration : MonoBehaviour
{
    public GameObject[] stars;
    public Color[] colors;
    public float interval;

    private float minY = -6f;
    private float maxY = 6f;

    private float minSpeed = 1f;
    private float maxSpeed = 8f;

    private float minScale = 1f;
    private float maxScale = 10f;


    void Start()
    {
        InvokeRepeating("Spawn", 0, interval);
    }

    void Spawn()
    {
        GameObject star = stars[Random.Range(0, stars.Length)];
        Vector2 randomPosition = new Vector2(transform.position.x, Random.Range(minY, maxY));
        float tempScl = Random.Range(minScale, maxScale);
        Vector3 randomScale = new Vector3(tempScl, tempScl, tempScl);
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Color randomColor = colors[Random.Range(0, colors.Length)];

        GameObject s = Instantiate(star, randomPosition, Quaternion.identity);
        s.GetComponent<MoveGameObj>().speed = randomSpeed;
        s.transform.localScale = randomScale;
        s.GetComponent<SpriteRenderer>().color = randomColor;
    }
}
