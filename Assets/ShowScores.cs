using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScores : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        float best=PlayerPrefs.GetFloat("bestScore");
        float current=PlayerPrefs.GetFloat("score");
        if(best==current){
            string minutes = ((int)current/60).ToString();
            string secondes = (current%60).ToString("f2");
            
            scoreText.text = "New best score : "+minutes+":"+secondes+"\n";
       
        }else{
            string bestMinutes = ((int)best/60).ToString();
            string bestSecondes = (best%60).ToString("f2");

            string minutes = ((int)current/60).ToString();
            string secondes = (current%60).ToString("f2");
            
            scoreText.text = "Your score : "+minutes+":"+secondes+"\n"+"Best score : "+bestMinutes+":"+bestSecondes;
        }
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
