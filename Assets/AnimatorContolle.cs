using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class AnimatorContolle : MonoBehaviour
{
    public Animator Aplayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void idle()
    {
        Aplayer.Play("IdleBattle01_AR_Anim");
        Debug.Log("IdleBattle01_AR_Anim");
        Aplayer.SetBool("isDragging", false);
        Aplayer.SetBool("isForward", false);
        Aplayer.SetBool("isRight", false);
        Aplayer.SetBool("isBackward", false);
    }


    public void playerRun()
    {
        Aplayer.SetBool("isForward", true);
    }
    public void shoot()
    {
        Aplayer.Play("ShootAutoshot_AR_Anim");
    }
    public void RunBack()
    {
        Aplayer.SetBool("isBackward", true);
        //Aplayer.Play("RunBWD_AR_Anim");
    }
    public void RunLeft()
    {
        Aplayer.SetBool("isRight", true);
        
       // Aplayer.Play("RunLeft_AR_Anim");
    }
    public void Jump_()
    {
        Aplayer.Play("Jump_AR_Anim");
        Debug.Log("Jump_AR_Anim");
    }
    public void RunRight()
    {
        Aplayer.SetBool("isDragging", true);
       // Aplayer.Play("RunRight_AR_Anim");
    }
}

