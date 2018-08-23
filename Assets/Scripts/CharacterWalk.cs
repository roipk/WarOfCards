using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterWalk : MonoBehaviour {
    public GameObject player;
    public float speed = 4f;
    public float rotationSpeed = 60f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        float translation = CrossPlatformInputManager.GetAxis("Vertical") * speed;
        float rotation = CrossPlatformInputManager.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        player.transform.Translate(0, 0, translation);
        player.transform.Rotate(0, rotation, 0);
    }
}
