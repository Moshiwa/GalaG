using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveGameObj : MonoBehaviour
{
    public float speed;
    public Vector2 _direction;


    void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime, Space.World);
    }
}
