using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public GameObject computer;
    public GameObject enemy;
    Animator anim;
    Vector3 direction;
    // Use this for initialization
    void Start () {
        anim = computer.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        if (enemy)
            direction = enemy.transform.position - computer.transform.position;
        else
            direction = computer.transform.position;
         if (direction.magnitude < 10f)
         {
            anim.Play("WAIT04");
         }
         else
        {
           // if (anim.Play("WAIT04"))
                    anim.Play("WAIT02");
        }
    }
}
