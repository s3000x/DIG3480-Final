using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    private Vector2 emitterPos;
    private Vector2 emitterPosB;

    private Vector2 emitterMove;

    public float speed;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        emitterPos = rigidbody2D.transform.position;
        //emitterPosB = new Vector2(emitterPos.x, emitterPos.y - 12);
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.AddForce(Vector2.down * speed);
        //transform.position = Vector2.Lerp(emitterPos, emitterPosB, speed * Time.time);
    }
}
