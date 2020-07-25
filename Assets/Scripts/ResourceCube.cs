using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCube : MonoBehaviour
{
    public GameObject healthPickup;
    public GameObject ammoPickup;
    public GameObject Ruby;
    Vector2 currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = transform.position;
        RubyController Player = Ruby.gameObject.GetComponent<RubyController>();
    }

    public void GetResources()
    {
        RubyController Player = Ruby.gameObject.GetComponent<RubyController>();
        int RubyCurrentHealth = Player.health;
        int RubyMaxHealth = Player.maxHealth;
        Debug.Log("This is a resource cube");
        Debug.Log(RubyCurrentHealth);
        if (RubyCurrentHealth == Player.maxHealth)
        {
            Debug.Log("You get ammo");
            for (int i = Random.Range(1, 3); i < 4; i++)
            {
                Instantiate(ammoPickup, new Vector2(currentPosition.x + Random.Range(-0.8f, 0.8f), currentPosition.y + Random.Range(-0.8f, 0.5f)), Quaternion.identity);
            }
            
        }
        else
        {
            Debug.Log("You get health" + Player.maxHealth + "/" + Player.currentHealth);
            for (int i = Random.Range(1, 3); i < 4; i++)
            {
                Instantiate(healthPickup, new Vector2(currentPosition.x + Random.Range(-0.8f, 0.8f), currentPosition.y + Random.Range(-0.8f, 0.5f)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
