using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class EnemyCount : MonoBehaviour
{
    public int fixCount;
    public int fixRequired;
    public Text fixText;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
       fixText.text = "Robots Fixed: " + fixCount + "/" + fixRequired;
       if (fixCount == fixRequired)
       {
           fixText.text = "Huzzah!";
           audioSource.Stop();

       } 
    }
}
