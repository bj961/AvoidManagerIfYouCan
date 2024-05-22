using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : PlayerInputController
{
    GameManager gameManager;

    bool controllerCheck;

    InputController2D inputController2D;
    InputAction moveAction;
    InputAction sprintAction;

    public Player1Controller()
    {

    }

    private void Awake()
    {
        inputController2D = new InputController2D();
        moveAction = inputController2D.Player.Move;
        sprintAction = inputController2D.Player.Sprint;
    }

    private void Start()
    {
        gameManager = GetComponent<GameManager>();

    }

    private void FixedUpdate()
    {
        
    }

    public void OnPlayer1()
    {
        if(gameManager.player1Prefab)
        {

        }
    }
}
