using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private GameObject playZone;
    private GameObject generation;
    public ParticleSystem effects;

    void Start()
    {
        playZone = GameObject.Find("PlayZone");
        generation = GameObject.Find("Generation");
    }

    void Update()
    {
        if(transform.position.x < playZone.GetComponent<Transform>().position.x || transform.position.x > generation.GetComponent<Transform>().position.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        ParticleSystem fx = Instantiate(effects, transform.position, Quaternion.identity);
        fx.GetComponent<ParticleSystem>().Play();
        Destroy(fx, 3);
    }
}
