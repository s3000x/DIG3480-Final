using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButtonTester : MonoBehaviour
{
    private int buttons;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetButtonDown("Joystick Button 0"))
      {
          Debug.Log("This is joystick button 0" );
      }
    }
}
