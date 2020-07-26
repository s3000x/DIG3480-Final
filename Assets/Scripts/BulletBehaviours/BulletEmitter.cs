using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
    public GameObject objForEmit;
    public float time;
    private float originalTime;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        originalTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            GameObject emitObj = (GameObject)Instantiate(objForEmit, rigidbody2D.position, Quaternion.identity);
            time = originalTime; 
        }
    }
}
