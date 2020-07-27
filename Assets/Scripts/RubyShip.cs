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
    private float invincibleTimer; 
    public float speed;
    Rigidbody2D rigidbody2d;
    private float horizontal;
    private float vertical;
    private float originalSpeed;
    Scene currentScene;
    public GameObject hitbox;
    public ParticleSystem projectileEffect;
    Vector2 lookDirection = new Vector2(0, 1);
    public int coolDown = 1;



    // Start is called before the first frame update
    void Start()
    {
        originalSpeed = speed;
        currentScene = SceneManager.GetActiveScene();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;       
    }

    void Launch()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
           projectileEffect.Play();
        }

        if (Input.GetButtonUp("Fire3"))
        {
            projectileEffect.Stop();
        }
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        if (Input.GetButtonDown("Submit"))
        {
            hitbox.SetActive(true);
            speed = originalSpeed - 4.0f;
        }

        if (Input.GetButtonUp("Submit"))
        {
            hitbox.SetActive(false);
            speed = originalSpeed;
        }
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(currentScene.name);
        }
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
            if (isInvincible)
            return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            currentHealth -= 1;
        Destroy(other.gameObject);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        }
    }

    void OnParticleCollision()
    {
        Debug.Log("A particle collision");
         if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
            currentHealth -= 1;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
}
