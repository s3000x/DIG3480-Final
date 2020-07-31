using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{
    private bool canAttack;
    private int attackNum;
    private float waitTime;
    private Vector2 bossPos;
    public ParticleSystem damageEffect;
    public ParticleSystem winEffect;
    private bool canPlay;
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    public GameObject bossAnimator;
    public GameObject winMessage;
    Animator headAnim;

    public int health;
    public int maxHealth;
    public float endTime;
    // Start is called before the first frame update
    void Start()
    {
        headAnim = bossAnimator.gameObject.GetComponent<Animator>();
        bossPos = transform.position;
        canAttack = true;
        waitTime = 5.0f;
        maxHealth = health;
        canPlay = true;
        endTime = 4.0f;
    }

    void OnParticleCollision()
    {
        health -= 1;
        health = Mathf.Clamp(health, 0, maxHealth);
        EnemyHealthUI.instance.SetValue(health / (float)maxHealth);
        damageEffect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            canAttack = false;
            headAnim.SetFloat("ColorCode", 0.75f);
            winMessage.SetActive(true);
            endTime -= Time.deltaTime;
            if (canPlay == true)
            {
                winEffect.Play();
                canPlay = false;
            }
            if (endTime <= 0)
            {
                SceneManager.LoadScene("Level1");
            }

        }
        waitTime -= Time.deltaTime;
        if ((waitTime <= 0) && canAttack == true)
        {
            attackNum = Random.Range(1, 4);
            canAttack = false;

            switch (attackNum)
            {
                case 3:
                    Debug.Log("attack 3");
                    Instantiate (attack3, new Vector2 (bossPos.x - 2.5f, bossPos.y), Quaternion.identity);
                    waitTime = 5;
                    headAnim.SetFloat("ColorCode", 0.25f);
                    canAttack = true;

                    
                    break;

                case 2:
                    Debug.Log("attack 2");
                    Instantiate (attack2, new Vector2 (bossPos.x - 5, bossPos.y), Quaternion.identity);
                    waitTime = 10;
                    headAnim.SetFloat("ColorCode", 1.0f);
                    canAttack = true;
                    break;

                case 1:
                    Debug.Log("attack 1");
                    Instantiate (attack1, new Vector2 (bossPos.x - 5, bossPos.y), Quaternion.identity);
                    waitTime = 10;
                    headAnim.SetFloat("ColorCode", 0.5f);
                    canAttack = true;
                    break;
            }
        }
    }
}
