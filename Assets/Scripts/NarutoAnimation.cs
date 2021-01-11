using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarutoAnimation : MonoBehaviour
{
    private Animator animator;
    private bool isJumping=false;
    private bool isRunning=false;


    void Start(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!isJumping){
            animator.SetBool("jump",true);
            isJumping=true;
        }else if(Input.GetKeyUp(KeyCode.Space)&&isJumping){
            animator.SetBool("jump",false);
            isJumping=false;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)&&!isRunning){
            animator.SetBool("run",true);
            isRunning=true;
        }else if(Input.GetKeyUp(KeyCode.UpArrow)&&isRunning){
            animator.SetBool("run",false);
            isRunning=false;
        }
    }
}
