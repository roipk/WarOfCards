using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Walk : MonoBehaviour {
    public JoyButton joyButtonAttack;
    public JoyButton joyButtonBlock;

    Animation anim;
    Rigidbody rg;
    public GameObject player;
    public GameObject enemy;
    public GameObject stamina;

    Vector2 st;
    float speedWalk = 2f;
    float speedRound;
    bool turned = false;
    bool block = false;
    bool attack = false;


    float x = 0;
    float y = 0;
    float x2 = 0;
    float y2 = 0;

    // Use this for initialization
    void Start () {
        anim = player.GetComponent<Animation>();
        rg = player.GetComponent<Rigidbody>();
        speedRound = speedWalk/2;
     //   targetq = Quaternion.Euler(0, (Mathf.Atan2(x, y) * Mathf.Rad2Deg), 0);

    }
	
	// Update is called once per frame
	void Update () {
        st = stamina.transform.localScale;
          x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
          y = CrossPlatformInputManager.GetAxisRaw("Vertical");
        var w = Mathf.Atan2(x, y) * Mathf.Rad2Deg;

        Vector3 direction = enemy.transform.position - player.transform.position;

        

         if(!block && !attack&& joyButtonBlock.Pressed && st.x > 0.05f)
         {
             block = true;

             anim.Play("Skill");
         }
        if (!block && !attack && joyButtonAttack.Pressed && st.x > 0.05f)
        {
            attack = true;

            anim.Play("Attack");
        }



        if (block && joyButtonBlock.Pressed || attack && joyButtonAttack)
         {

             if (!anim.IsPlaying("Skill") && !anim.IsPlaying("Attack"))
                 anim.Play("Idle");


         }

         if (block && !joyButtonBlock.Pressed)
         {
             block = false;
         }

        if (!anim.IsPlaying("Attack") && !joyButtonAttack.Pressed)
         {
             attack = false;
         }

        /*

         if (direction.magnitude < 10f && !block && st.x > 0.05f)
         {
             anim.Play("Attack");
         }*/

         if (x != 0 && y != 0 && !block)
         {

          
            player.transform.Translate(CrossPlatformInputManager.GetAxis("Horizontal")* speedWalk * Time.deltaTime, 0f, CrossPlatformInputManager.GetAxis("Vertical") * speedWalk* Time.deltaTime);
            

        }

         if (x!=0 || y != 0)
         {
             if (!attack && !block)
                 anim.Play("Walk");
         }
         else
         {
             if(!attack && !block)
                 anim.Play("Idle");
             rg.velocity = (player.transform.forward * 0f);

         }




        x2 = CrossPlatformInputManager.GetAxisRaw("Horizontal_2");
        y2 = CrossPlatformInputManager.GetAxisRaw("Vertical_2");
        float w2 = (Mathf.Atan2(x2, y2) * Mathf.Rad2Deg);
        float t = 0;
        if ((w2 > 90 && w2 <= 135) || (w2 > 0 && w2 <= 45) || (w2 < 180 && w >= 90) || (w2 <= 90 && w2 >= 45))
            t = 0.1f;

        else if ((w2 < -90 && w2 >= -135) || (w2 < 0 && w2 >= -45) || (w2 > -180 && w2 <= -135) || (w2 >= -90 && w2 <= -45))
            t = -0.1f;
        else
            t = 0;

        player.transform.Rotate(Vector3.up, speedRound * t * Time.deltaTime, Space.Self);


        

    }

}
