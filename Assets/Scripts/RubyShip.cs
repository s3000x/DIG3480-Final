﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyShip : MonoBehaviour
{
    public int health {get {return currentHealth;}}
    public int currentHealth;
    public int maxHealth;
    public float timeInvincible;
    public ParticleSystem damageEffect;
    private bool isInvincible;
    private int invincibleTimer; 
    public float speed;
    Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    Scene currentScene;



    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;       
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);
      
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;        
        position.y = position.y + speed * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
        Debug.Log("YouGotHit!");
        Destroy(other.gameObject);
        }
    }
}
