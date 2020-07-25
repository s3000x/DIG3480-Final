using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject fixTracker;
    public int ammo;
    public ParticleSystem damageEffect;
    public ParticleSystem bulletEffect;
    public ParticleSystem healthEffect;

    public int maxHealth = 5;
    public float timeInvincible = 2.0f;

    public int health {get { return currentHealth; }}
    public int currentHealth;

    bool isInvincible;
    float invincibleTimer;

    public float speed = 3.0f;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;
    AudioSource audioSource;
    public AudioClip hitSound;
    public AudioClip throwSound;
    public AudioClip collectSound;
    public AudioClip victory;
    bool canPlay = true;
    Vector2 lookDirection = new Vector2(0,0);

    Scene currentScene;

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.zero * 0.5f, Quaternion.identity);

        
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
        ammo -= 1;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        Debug.Log(currentHealth);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount count = fixTracker.gameObject.GetComponent<EnemyCount>();
        if (count.fixCount == count.fixRequired && canPlay == true)
        {
            PlaySound(victory);
            canPlay = false;

        }
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Fire1"))
        {
            //RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.zero * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.down * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
                NonPlayableCharacter character = hit.collider.GetComponent<NonPlayableCharacter>(); 
                if (character != null)
                {
                    character.DisplayDialog();
                }

                else
                {
                    //ResourceCube();
                    ResourceCube cube = hit.collider.GetComponent<ResourceCube>();
                    cube.GetResources();
                    Destroy(hit.collider.gameObject);
                }
            }


        }

        if(Input.GetKeyDown(KeyCode.C) && ammo > 0)
        {
            Launch();

            PlaySound(throwSound);
        }
        if(Input.GetButtonDown("Fire3") && ammo > 0)
        {
            Launch();
            
            PlaySound(throwSound);
        }

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
            {
                lookDirection.Set(move.x, move.y);
                lookDirection.Normalize();
            }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(currentScene.name);
            }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ammo"))
        {
            ammo += 3;
            Destroy(other.gameObject);
            bulletEffect.Play();
            PlaySound(collectSound);

        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;        
        position.y = position.y + speed * vertical * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hit");
            damageEffect.Play();
        
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;

            PlaySound(hitSound);
        }    

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
}
