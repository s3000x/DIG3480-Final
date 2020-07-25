using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{

    public GameObject Ruby;
    public Text ammoText;
    public int ammoCounter;
    // Start is called before the first frame update
    void Start()
    {
     RubyController ammoCheck = Ruby.gameObject.GetComponent<RubyController>();  
    }

    // Update is called once per frame
    void Update()
    {
        RubyController ammoCheck = Ruby.gameObject.GetComponent<RubyController>(); 
        ammoCounter = ammoCheck.ammo;
        ammoText.text = ammoCounter + "";

    }
}
