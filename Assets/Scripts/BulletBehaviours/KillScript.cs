using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScript : MonoBehaviour
{
    public float killTime;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        killTime -= Time.deltaTime;
        if (killTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }

    }
}
