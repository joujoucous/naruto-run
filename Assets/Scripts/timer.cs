using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time-startTime;
        string minutes = ((int)t/60).ToString();
        string secondes = (t%60).ToString("f2");
        timerText.text = minutes+":"+secondes;
        
    }
    public void SaveTimes(){
        float t = Time.time-startTime;
        PlayerPrefs.SetFloat("score", t);
        if(PlayerPrefs.HasKey("bestScore")){
            float best=PlayerPrefs.GetFloat("bestScore");
            if(t>best){
                PlayerPrefs.SetFloat("bestScore", t);
            }
        }else{
            PlayerPrefs.SetFloat("bestScore", t);
        }
        
    }
    
}
