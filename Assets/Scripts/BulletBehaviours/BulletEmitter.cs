using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
    public GameObject objForEmit;
    private float time;
    public float originalTime;
    public int emitsLeft;

    Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        time = 0;
  
    }

    // Update is called once per frame
    void Update()
    {      
        Vector2 emitterPos = rigidbody2D.transform.position;
        time -= Time.deltaTime;
        if (time <= 0 && emitsLeft > 0)
        {
            GameObject instance = Instantiate (objForEmit, emitterPos, Quaternion.identity);
            time = originalTime; 
            emitsLeft -= 1;
        }
    }
}
