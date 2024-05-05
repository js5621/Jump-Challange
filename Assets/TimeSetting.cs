using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSetting : MonoBehaviour
{
    [SerializeField]Text timerText;
    float gameProcessTime;
    int minutes;
    int seconds;
    public static TimeSetting instance; 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public int getSec()
    { 
        
            
        return this.seconds;
    }

    public int getMin()
    {
        

        return this.minutes;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.b_firstLanding)
        {
            gameProcessTime += Time.deltaTime;
            minutes = Mathf.FloorToInt(gameProcessTime / 60);
            seconds = Mathf.FloorToInt(gameProcessTime % 60);
            timerText.text = "TIME  " + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}
