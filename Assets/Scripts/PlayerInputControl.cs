﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControl : MonoBehaviour {

    public float speed = 6.0F;  //move to mob
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

    public Mob mob;
    public int strength, intelligence, dexterity, health;

    public static PlayerInputControl player;
    //player stats and info


    private void Awake()
    {
        if (player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
    }

    //add turn speed
    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            //convert to forward with vertical
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            //add turn
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
