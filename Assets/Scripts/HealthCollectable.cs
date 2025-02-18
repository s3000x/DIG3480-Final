﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(1);
            controller.healthEffect.Play();
            Destroy(gameObject);

            controller.PlaySound(collectedClip);
        }
    }
}
