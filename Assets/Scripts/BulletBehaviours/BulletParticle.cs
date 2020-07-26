using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    ParticleSystem bParticle;
    public GameObject ruby;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    void OnParticleTrigger()
    {
        bParticle = this.gameObject.GetComponent<ParticleSystem>();
        RubyShip rubyControl = ruby.gameObject.GetComponent<RubyShip>();
        rubyControl.currentHealth -= 1;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
