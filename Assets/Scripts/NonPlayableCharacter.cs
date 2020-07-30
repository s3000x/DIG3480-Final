using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NonPlayableCharacter : MonoBehaviour
{
    public int insertBuildIndexhere; 
    float waitTime;
    bool canWait;
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    public GameObject winDialog;
    public GameObject fixTracker;
    float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
        waitTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (canWait == true)
        {
        
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + insertBuildIndexhere));
            }
        }
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
        
    }
    
    public void DisplayDialog()
    {
        EnemyCount count = fixTracker.gameObject.GetComponent<EnemyCount>();
        if (count.fixCount == count.fixRequired)
        {
            timerDisplay = displayTime;
            winDialog.SetActive(true);
            canWait = true;
        }
        else
        {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
        }
    }
}
