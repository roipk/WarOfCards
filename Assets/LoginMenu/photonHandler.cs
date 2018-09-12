using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class photonHandler : MonoBehaviour {


	public photonButtons photonB;

	public GameObject mainPlayer;

    private void Awake(){
		DontDestroyOnLoad (this.transform);

		PhotonNetwork.sendRate = 50;
		PhotonNetwork.sendRateOnSerialize = 30;

		SceneManager.sceneLoaded += OnSceneFinishedLoading;
	}



	public void createNewRoom(){
		PhotonNetwork.CreateRoom (photonB.createRoomInput.text, new RoomOptions () { MaxPlayers = 4 }, null);
	}


	public void joinOrCreateRoom(){
		RoomOptions roomOptions = new RoomOptions ();
		roomOptions.MaxPlayers = 4;
		PhotonNetwork.JoinOrCreateRoom (photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);
	}


	public void moveScene(){
		photonB = null;

		PhotonNetwork.LoadLevel ("temp");
	}


	private void OnJoinedRoom(){
		moveScene ();
		Debug.Log ("We are connected to the room!");
	}


	private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode){
		if(scene.name == "MainGame"){
			spawnPlayer ();		
		}
	}


	private void spawnPlayer(){
        
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        if (PhotonNetwork.playerList.Length == 1)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[0].transform.position, mainPlayer.transform.rotation, 0);
        }

        if (PhotonNetwork.playerList.Length == 2)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, spawnPoints[1].transform.position, mainPlayer.transform.rotation, 0);
        }

    }



}
