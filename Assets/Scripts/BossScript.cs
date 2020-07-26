using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private bool canAttack;
    private int attackNum;
    private float waitTime;
    private Vector2 bossPos;

    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    // Start is called before the first frame update
    void Start()
    {
        bossPos = transform.position;
        canAttack = true;
        waitTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if ((waitTime <= 0) && canAttack == true)
        {
            attackNum = Random.Range(1, 4);
            canAttack = false;
            Debug.Log("" + attackNum);

            switch (attackNum)
            {
                case 3:
                    Debug.Log("attack 3");
                    Instantiate (attack3, new Vector2 (bossPos.x - 2.5f, bossPos.y), Quaternion.identity);
                    waitTime = 5;
                    canAttack = true;

                    
                    break;

                case 2:
                    Debug.Log("attack 2");
                    Instantiate (attack2, new Vector2 (bossPos.x - 5, bossPos.y), Quaternion.identity);
                    waitTime = 10;
                    canAttack = true;
                    break;

                case 1:
                    Debug.Log("attack 1");
                    Instantiate (attack1, new Vector2 (bossPos.x - 5, bossPos.y), Quaternion.identity);
                    waitTime = 10;
                    canAttack = true;
                    break;
            }
        }
    }
}
