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
    float speedWalk = 4f;
    float speedRound = 60f;
    bool block = false;
    bool attack = false;
    bool death = false;
 
    float x = 0;
    float y = 0;

    void Start()
    {
        anim = player.GetComponent<Animation>();
        rg = player.GetComponent<Rigidbody>();
    }
	void Update () {
        if(player)
        {

            st = stamina.transform.localScale;
            x = CrossPlatformInputManager.GetAxis("Horizontal");
            y = CrossPlatformInputManager.GetAxis("Vertical");



            float translation = CrossPlatformInputManager.GetAxis("Vertical") * speedWalk;
            float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * speedRound;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            player.transform.Translate(0, 0, translation);
            player.transform.Rotate(0, rotation, 0);

            
            if (!block && !attack && !death && joyButtonBlock.Pressed && st.x > 0.05f)
            {
                block = true;

                anim.Play("Skill");
            }
            if (!block && !attack && !death && joyButtonAttack.Pressed && st.x > 0.05f)
            {
                attack = true;

                anim.Play("Attack");
            }
            if (!block && !attack && !death && st.x < 0.05f)
            {
                death = true;
                anim.Play("Death");
            }

            if (block && joyButtonBlock.Pressed || attack && joyButtonAttack)
            {

                if (!anim.IsPlaying("Skill") && !anim.IsPlaying("Attack")&& !anim.IsPlaying("Death"))
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



            if (x != 0 && y != 0 && !block)
            {


                player.transform.Translate(CrossPlatformInputManager.GetAxis("Horizontal") * speedWalk * Time.deltaTime, 0f, CrossPlatformInputManager.GetAxis("Vertical") * speedWalk * Time.deltaTime);


            }

            if (x != 0 || y != 0)
            {
                if (!attack && !block)
                    anim.Play("Walk");
            }
            else
            {
                if (!attack && !block && !death)
                    anim.Play("Idle");
                rg.velocity = (player.transform.forward * 0f);

            }



        }

        

    }

}
