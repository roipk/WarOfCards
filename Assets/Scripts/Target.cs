using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public GameObject computer;
    public GameObject enemy;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = computer.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = enemy.transform.position - computer.transform.position;

         if (direction.magnitude < 10f)
         {
            anim.Play("WAIT04");
         }
         else
            anim.Play("WAIT02");
    }
}
