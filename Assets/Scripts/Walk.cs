using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Walk : MonoBehaviour {
    protected JoyButton joyButton;

    Animation anim;
    Rigidbody rg;
    public GameObject player;
    public GameObject enemy;
    public GameObject stamina;
    Vector2 st;
    float speedWalk = 200f;
    float speedRound;
    bool turned = false;
    bool block = false;

    // Use this for initialization
    void Start () {
        anim = player.GetComponent<Animation>();
        rg = player.GetComponent<Rigidbody>();
        joyButton = FindObjectOfType<JoyButton>();
        speedRound = speedWalk / 2;
       
    }
	
	// Update is called once per frame
	void Update () {
        st = stamina.transform.localScale;
        float x = CrossPlatformInputManager.GetAxis("Horizontal");
        float y = CrossPlatformInputManager.GetAxis("Vertical");
        
        Vector3 direction = enemy.transform.position - player.transform.position;
        //Debug.Log(block);
        if(!block && joyButton.Pressed && st.x > 0.05f)
        {
            block = true;
            
            anim.Play("Skill");
        }

        if (block && joyButton.Pressed)
        {

            //Debug.Log(anim.IsPlaying("Skill"));


            if (!anim.IsPlaying("Skill"))
                anim.Play("Idle");
           
            
        }

        if (block && !joyButton.Pressed)
        {
           // Debug.Log("test 2");
            block = false;
            //anim.Play("Block");
        }

      

        if (direction.magnitude < 10f && !block && st.x > 0.05f)
        {
            anim.Play("Attack");
        }

        if (x != 0 && y != 0 && !block)
        {
            // turned = check(y, turned);
            player.transform.Rotate(Vector3.up, x* speedRound * Time.deltaTime);
           
                rg.velocity = (player.transform.forward * speedWalk) *( y * Time.deltaTime);
        }

        if (x!=0 || y != 0)
        {
            if (!anim.IsPlaying("Attack") && !block)
                anim.Play("Walk");
        }
        else
        {
            if(!anim.IsPlaying("Attack") && !block)
                anim.Play("Idle");
            player.transform.Rotate(Vector3.up,0f);
            rg.velocity = (player.transform.forward * 0f);

        }


        
        
	}

}
