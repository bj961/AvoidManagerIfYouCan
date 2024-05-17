using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyHyuk;

    int EnemyCount;
    float Speed = 0.02f;
    Sprite sprite;

    void Start()
    {
        float x = Random.Range(-2.7f, 2.7f);
        float y = 3.0f;
        //Spawn point
        transform.position = new Vector2(x, y);

        if (EnemyCount == 1)
        {
            Speed = 0.05f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // -Y Speed Control
        transform.position += Vector3.down * Speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // i want destroy this gameObject but Can't
        if (transform.position.y < -7.0f)
        {
            Destroy(gameObject);
        }
    }
}
