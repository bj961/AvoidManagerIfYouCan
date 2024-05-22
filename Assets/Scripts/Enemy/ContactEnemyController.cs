using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactEnemyController : MonoBehaviour
{
    [SerializeField] private string targetTag = "Player";
    private string myTag = "Enemy";

    [SerializeField] private int enemyDamage = 1;

    private CharacterHealtSystem characterHealtSystem; // 캐릭터의 피

    private void Start()
    {
        characterHealtSystem = GetComponent<CharacterHealtSystem>();
    }

    // 닿았을 때
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject receiver = collision.gameObject; // 닿은 오브젝트

        if (!receiver.CompareTag(targetTag)) // 를 확인하는데, 태그가 targetTag인지 확인 후 아니라면?
        {
            return;
        }

        characterHealtSystem = collision.GetComponent<CharacterHealtSystem>();

        if (collision.gameObject.CompareTag(targetTag))
        {
            if(gameObject.CompareTag(myTag))
            {
                characterHealtSystem.ChangeHealth(-enemyDamage);
                Destroy(this.gameObject);
            }
        }
    }
}
