using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOnDeath : MonoBehaviour
{
    private CharacterHealtSystem characterHealtSystem;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        characterHealtSystem = GetComponent<CharacterHealtSystem>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        characterHealtSystem.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        rigidbody2d.velocity = Vector2.zero;

        // 약간 반투명한 느낌으로 변경
        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>()) // 스프라이트 렌더러를 가져와라
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        // 스크립트 더이상 작동 안하도록
        foreach (Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            behaviour.enabled = false; // 가져온 걸 다 비활성화
        }
    }


}
