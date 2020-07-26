using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 emitterPos;
    private Vector2 emitterPosB;

    private Vector2 emitterMove;

    private float speed;

    Rigidbody2D emitterBody;
    // Start is called before the first frame update
    void Start()
    {
        emitterBody = GetComponent<Rigidbody2D>();
        emitterPos = emitterBody.transform.position;
        emitterPosB = new Vector2(emitterPos.x + 3, emitterPos.y);
        speed = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(emitterPos, emitterPosB, Mathf.PingPong(speed * Time.time, 1));
    }
}
