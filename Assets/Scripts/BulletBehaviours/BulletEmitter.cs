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
           GameObject instance = Instantiate (objForEmit, new Vector2 (0, 0), Quaternion.identity);
           instance.transform.position = transform.position;
           Debug.Log("" + instance.transform.position);
            Debug.Log("" + emitterPos);
            time = originalTime; 
        }
    }
}
