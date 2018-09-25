﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
// script from https://stuartspixelgames.com/
 Rigidbody2D body;
 float horizontal;
 float vertical;
 float moveLimiter = 0.7f;
 public float runSpeed = 1  ; 

 void Start ()
 {
    body = GetComponent<Rigidbody2D>();
 }

void Update()
 {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical"); 
 }

void FixedUpdate ()
{ 
      if(horizontal != 0 && vertical != 0) 
            body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter , (vertical * runSpeed) * moveLimiter); 
      else 
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed); 

      // rotation by Jokeman258 · Mar 01, 2015 at 01:21 AM, Unity Forums
      Vector2 moveDirection = body.velocity;
      if (moveDirection != Vector2.zero) {
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
      }
}
}
