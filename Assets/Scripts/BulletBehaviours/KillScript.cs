﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    public float killTime;
    public bool killModeDestroy;
    public bool killModeDeactivate;

    Collider2D killCollider;
    SpriteRenderer killRender;
    private float killReset;

    private bool canKill;
    // Start is called before the first frame update
    void Start()
    {
      
       killCollider = GetComponent<Collider2D>();
       killRender = GetComponent<SpriteRenderer>();
       canKill = true;
       killReset = killTime;
       

    }

    // Update is called once per frame
    void Update()
    {
    if (killModeDestroy == true)
    {
        killTime -= Time.deltaTime;
        if (killTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
    }
    else
    {
        killTime -= Time.deltaTime;
        if (killTime <= 0.0f && canKill == true)
        {
            killCollider.enabled = !killCollider.enabled;
            killRender.enabled = !killRender.enabled;
            canKill = false;
            killModeDestroy = true;
            killTime += killReset + 3;
        }
    }
    }
}
