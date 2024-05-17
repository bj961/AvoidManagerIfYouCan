using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyUrock;

    int EnemyCount;
    float Speed = 0.02f;

    void Start()
    {
        //x = - 2.7 ~ 2.7 ���̱��� ����������ǥ
        float x = Random.Range(-2.7f, 2.7f);

        //y = 3.0 ���� - 7.0���� ����Ʈ�� ����
        float y = 3.0f;
        transform.position = new Vector2(x, y);

        if (EnemyCount == 1)
        {
            Speed = 0.05f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //-Y Down Speed ����
        transform.position += Vector3.down * Speed;

        if (transform.position.y < -7.0f)
        {
            //Destroy GameObject
        }
        //esle(transform.position.y == Charter) �ε����� GameOver();
    }
}
