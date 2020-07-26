using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private bool canAttack;
    private int attackNum;
    private float waitTime;

    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        waitTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            attackNum = Random.Range(1, 4);
            Debug.Log("" + attackNum);

            switch (attackNum)
            {
                case 3:
                    Debug.Log("attack 3");
                    Instantiate (attack3, Vector2.zero, Quaternion.identity);

                    
                    break;

                case 2:
                    Debug.Log("attack 2");
                    Instantiate (attack2, Vector2.zero, Quaternion.identity);
                    break;

                case 1:
                    Debug.Log("attack 1");
                    Instantiate (attack1, Vector2.zero, Quaternion.identity);
                    break;
            }
        }
    }
}
