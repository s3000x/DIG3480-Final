using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{
    public GameObject Ruby;
    Vector3 rubyPos;
    Vector3 objectPos;
    public GameObject tile;
    SpriteRenderer tileRender;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        objectPos = transform.position;
        tileRender = tile.gameObject.GetComponent<SpriteRenderer>();
        rubyPos = Ruby.gameObject.transform.position;
        if(rubyPos.y > objectPos.y)
        {
            tileRender.sortingOrder = 2;
        }
        else
        {
            {
                tileRender.sortingOrder = 0;
            }
        }
    }
}
