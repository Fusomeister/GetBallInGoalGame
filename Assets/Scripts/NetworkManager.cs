using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{
    private const string VERSION = "1.0";

    public GameObject MainCamera;
    public Transform RedSpawnPoint;
    public Transform BlueSpawnPoint;

    bool connecting = false;

    // Use this for initialization
    void Start ()
	{
	    Connect();
	}

    void Connect()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

        if (PhotonNetwork.connected == true && connecting == false)
        {

            // Player has not yet selected a team.

            //GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
            //GUILayout.BeginHorizontal();
            //GUILayout.FlexibleSpace();
            //GUILayout.BeginVertical();
            //GUILayout.FlexibleSpace();

            if (GUILayout.Button("Red Team"))
            {
                SpawnMyPlayer(1);
            }

            if (GUILayout.Button("Blue Team"))
            {
                SpawnMyPlayer(2);
            }

            //GUILayout.FlexibleSpace();
            //GUILayout.EndVertical();
            //GUILayout.FlexibleSpace();
            //GUILayout.EndHorizontal();
            //GUILayout.EndArea();
        }
    }

    void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        //SpawnMyPlayer();
    }

    void SpawnMyPlayer(int teamID)
    {
        if (teamID == 1)
        {
            MainCamera.SetActive(false);
            GameObject myPlayerGO =
                (GameObject)
                PhotonNetwork.Instantiate("RedCar", RedSpawnPoint.transform.position, RedSpawnPoint.rotation, 0);
            ((MonoBehaviour) myPlayerGO.GetComponent("CarController")).enabled = true;
            ((MonoBehaviour) myPlayerGO.GetComponent("CarUserControl")).enabled = true;
            ((MonoBehaviour) myPlayerGO.GetComponent("CarAudio")).enabled = true;
            myPlayerGO.transform.FindChild("CameraFocusPoint").gameObject.SetActive(true);
        }

        if (teamID == 2)
        {
            MainCamera.SetActive(false);
            GameObject myPlayerGO =
                (GameObject)
                PhotonNetwork.Instantiate("BlueCar", BlueSpawnPoint.transform.position, BlueSpawnPoint.rotation, 0);
            ((MonoBehaviour)myPlayerGO.GetComponent("CarController")).enabled = true;
            ((MonoBehaviour)myPlayerGO.GetComponent("CarUserControl")).enabled = true;
            ((MonoBehaviour)myPlayerGO.GetComponent("CarAudio")).enabled = true;
            myPlayerGO.transform.FindChild("CameraFocusPoint").gameObject.SetActive(true);
        }
    }
}
