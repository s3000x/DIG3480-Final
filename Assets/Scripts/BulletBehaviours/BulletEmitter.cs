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
        GameObject objToEmit;
        objToEmit = objForEmit.gameObject;
        Debug.Log("" + objToEmit);
        time -= Time.deltaTime;
        if (time <= 0)
        {
            Instantiate (objToEmit, new Vector2(rigidbody2D.transform.position.x, rigidbody2D.transform.position.y), Quaternion.identity);
            time = originalTime; 
        }
    }
}
