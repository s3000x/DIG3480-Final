﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private float scale;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate (new Vector3 (0, 0, 15) * Time.deltaTime);
       transform.localScale += new Vector3 (1, 1, 1) * Time.deltaTime;

    }
}
