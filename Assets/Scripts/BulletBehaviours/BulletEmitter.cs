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
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalTime = time;
        Debug.Log("" + objForEmit);
  
    }

    // Update is called once per frame
    void Update()
    {      
        Vector2 emitterPos = rigidbody2D.transform.position;
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate (objForEmit, emitterPos + Vector2.up, Quaternion.identity);
            Debug.Log("" + emitterPos);
            time = originalTime; 
        }
    }
}
