﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject fixTracker;
    public ParticleSystem smokeEffect;

    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    public bool broken = true;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        timer = changeTime;
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    void Update()
    {

        if(!broken)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        if(!broken)
        {
            return;
        }

        Vector2 position = rigidbody2D.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;;
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", direction);
        }

        else
    {
        position.x = position.x + Time.deltaTime * speed * direction;;
        animator.SetFloat("MoveX", direction);
        animator.SetFloat("MoveY", direction);
    }
        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
        rigidbody2D.simulated = false;

        animator.SetTrigger("Fixed");
        EnemyCount count = fixTracker.gameObject.GetComponent<EnemyCount>();
        count.fixCount += 1;

        smokeEffect.Stop();
    }

    // Update is called once per frame

}
