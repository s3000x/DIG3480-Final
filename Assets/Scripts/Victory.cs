using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public GameObject fixCount;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCount fixTracker = fixCount.GetComponent<EnemyCount>();

        if (fixTracker.fixCount == fixTracker.fixRequired)
        {
           audioSource.Stop();
        }
    }
}
