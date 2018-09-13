using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
public class Vb_Start : MonoBehaviour , IVirtualButtonEventHandler
{
#pragma warning disable CS0618 // Type or member is obsolete

    public GameObject player;
    public GameObject canvas;
    public GameObject enemy;
    GameObject vbBtnStart;
    GameObject vbBtnReStart;
    GameObject vbBtnExit;
    GameObject vbBtnYes;
    GameObject vbBtnNo;
    GameObject exitGame;
    GameObject exitYes;
    GameObject exitNo;
    GameObject question;
    GameObject startbtn;
    GameObject reStartbtn;
    GameObject stickControl;
    bool exit;
    bool start;


    // Use this for initialization
    void Start () {
        stickControl = GameObject.Find("MoveStickControl");
        vbBtnStart = GameObject.Find("BtnStartGame");
        vbBtnStart.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbBtnReStart = GameObject.Find("BtnReStartGame");
        vbBtnReStart.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbBtnExit = GameObject.Find("VirtualButtonQuit");
        vbBtnExit.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbBtnYes = GameObject.Find("VirtualButtonQuitYes");
        vbBtnYes.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        vbBtnNo = GameObject.Find("VirtualButtonQuitNo");
        vbBtnNo.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);


        startbtn = GameObject.Find("startBtn");
        reStartbtn = GameObject.Find("reStartBtn");
        question = GameObject.Find("TxtExit");
        exitGame = GameObject.Find("ExitGame");
        exitYes = GameObject.Find("ExitYes");
        exitNo = GameObject.Find("ExitNo");
        startbtn.active = true;
        reStartbtn.active = false;
        exitYes.active = false;
        exitNo.active = false;
        question.active = false;
        stickControl.active = false;

        exit = false;
        start = false;
        
        player.active = false;
        enemy.active = false;
        canvas.active = false;
       
    }



	// Update is called once per frame
	void Update () {
		
	}


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log(vb.gameObject.name);


        if (vb.gameObject.name == "BtnStartGame" && !start && !exit)
        {
            startbtn.active = false;
        }
        if (vb.gameObject.name == "VirtualButtonQuit")
            exitGame.active = false;
        
        if (vb.gameObject.name == "VirtualButtonQuitYes")
            exitYes.active = false;

        if (vb.gameObject.name == "VirtualButtonQuitNo")
        {
            exitYes.active = false;
            exitNo.active = false;
            question.active = false;
            reStartbtn.active = false;
        }
        if (vb.gameObject.name == "BtnReStartGame" && start && exit)
        {
            Debug.Log("in");
            reStartbtn.active = false;
        }
        
    } 
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        if (vb.gameObject.name == "BtnStartGame" && !start && !exit)
        {
            start = true;
            vbBtnStart.active = true;
            player.active = true;
            canvas.active = true;
            stickControl.active = true;
            enemy.active = true;
            
        }
        if (vb.gameObject.name == "BtnReStartGame" )
        {
            if(start && exit)
                Application.LoadLevel(Application.loadedLevel);
        }
        if (vb.gameObject.name == "VirtualButtonQuit")
        { 
            exit = true;
            exitGame.active = true;
            exitYes.active = true;
            exitNo.active = true;
            question.active = true;
            if(start)
                reStartbtn.active = true;

            
            startbtn.active = false;
            player.active = false;
            enemy.active = false;
            canvas.active = false;
            stickControl.active = false;

        }
        if (vb.gameObject.name == "VirtualButtonQuitYes")
        {
            if (!exitYes.active && exit)
                Application.Quit();
        }
        if (vb.gameObject.name == "VirtualButtonQuitNo")
        {
            if (!exitNo.active && exit) 
            {
                question.active = false;
                exitYes.active = false;
                exitNo.active = false;
                reStartbtn.active = false;
                exit = false;

                if(start)
                {
                    player.active = true;
                    enemy.active = true;
                    canvas.active = true;
                    stickControl.active = false;
                }
                else
                    startbtn.active = true;


            }
        }
    }







#pragma warning restore CS0618 // Type or member is obsolete
}
