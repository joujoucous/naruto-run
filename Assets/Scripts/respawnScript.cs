using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class respawnScript : MonoBehaviour
{
    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject buche;
    public GameObject naruto;
    public int vies = 3;

    [SerializeField] Image[] ImgVies;
    
    void Awake()
    {
        naruto = GameObject.Find("player");
    }
    void OnTriggerEnter (Collider col)
    {        
        if(col.transform.tag == "Player")
       {

            Instantiate(buche, naruto.transform.position, Quaternion.identity);
            naruto.SetActive(false);
            Color c=ImgVies[vies].color;
            c.a=0;
            ImgVies[vies].color=c;
            StartCoroutine(waiter());  

        }
    }
   IEnumerator waiter()
    {
        yield return new WaitForSeconds(3);
        
        if(vies==3){
            naruto.transform.position = spawnPoint1.transform.position;
            naruto.SetActive(true);  
        }else if(vies==2){
            naruto.transform.position = spawnPoint2.transform.position;
            naruto.SetActive(true);  
        }else if(vies==1){
            naruto.transform.position = spawnPoint3.transform.position;
            naruto.SetActive(true);  
        }else{
            GameObject canevas = GameObject.Find("Canvas");
            timer time = canevas.GetComponent<timer>();
            time.SaveTimes();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        vies--;
    }
}
