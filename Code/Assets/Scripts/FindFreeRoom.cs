using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SWS;

public class FindFreeRoom : MonoBehaviour {

    private BezierPathManager bezierPathManager;
    public List<BezierPathManager> roomPathsList;
    public List<BezierPathManager> exitPathsList;
    private BezierPathManager roomPathTaken;
    public Transform waypointManager;
    private int patientsOnPath;                         // Patients on a path.
    private bool roomVisited;                           // to set that the patient goes to a room or is in the room.
    private bool exit;                                  // exit is to control that the patient is getting out of the hospital.
    private bool waitForRoom;                           // If the rooms are taken the patient has to wait.
    public PatientSpawnController patientSpawnController;
	// Use this for initialization
	void Start () {
        patientsOnPath = 0;
        waitForRoom = false;
        roomVisited = false;
        exit = false;
        roomPathsList = new List<BezierPathManager>();
        exitPathsList = new List<BezierPathManager>();

        // We go through all the Paths in the Waypoint Manager.
	    foreach (Transform path in waypointManager){
            
            // If the path is a RommPath we save it in the list.
            if (path.tag == "RoomPath")
            {
                bezierPathManager = path.GetComponent<BezierPathManager>();
                roomPathsList.Add(bezierPathManager);
            }

            if (path.tag == "ExitPath")
            {
                bezierPathManager = path.GetComponent<BezierPathManager>();
                exitPathsList.Add(bezierPathManager);
            }
        }
	}
	
    public void CheckWhereToGo(){

        // If the patient didn't visit a room.
        if (!roomVisited)
        {
            // We check all the available rooms.

            foreach (BezierPathManager roomPath in roomPathsList)
            {
                patientsOnPath = roomPath.GetComponent<RoomPathData>().GetPatientsOnPath();
                // If the patient finds an empty room (path) we change his/her Patient Path to that roomPath.
                if (patientsOnPath == 0)
                {
                    //this.transform.GetComponent<bezierMove>().pathContainer = roomPath;

                    // We have found a free room and we send the patient to that room.
                    roomVisited = true;
                    transform.GetComponent<bezierMove>().moveToPath = true;
                    
                    // We save the path to the taken room to use it later to exit from the building.
                    roomPathTaken = roomPath;
                    StartCoroutine(ChangePath(roomPath));

                    if (roomPath.tag == "RoomPath")
                    {
                        roomPath.transform.GetComponent<RoomPathData>().SetPatientsOnPath();
                    }

                    return;
                }
                else
                {
                    continue;
                    //while (patientsOnPath > 0)
                    //{
                    //    waitForRoom = true;
                    //}
                    //if (patientsOnPath == 0)
                    //{
                    //    waitForRoom = false;
                    //}
                    
                }

            }
        }
        // If the patient has visited a room it goes out of the building.
        else if (roomVisited && !exit)
        {
            if (roomPathTaken.name == "roomPath101")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath101")));
            }
            else if (roomPathTaken.name == "roomPath102")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath102")));
            }
            else if (roomPathTaken.name == "roomPath102")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath102")));
            }
            else if (roomPathTaken.name == "roomPath103")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath103")));
            }
            else if (roomPathTaken.name == "roomPath104")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath104")));
            }
            else if (roomPathTaken.name == "roomPath105")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath105")));
            }
            else if (roomPathTaken.name == "roomPath106")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath106")));
            }
            else if (roomPathTaken.name == "roomPath107")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath107")));
            }
            else if (roomPathTaken.name == "roomPath108")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath108")));
            }
            exit = true;
            roomPathTaken.transform.GetComponent<RoomPathData>().ClearPath();
            
            patientSpawnController.ReducePatient();
        } else if (exit)
        {
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        
    }

    public IEnumerator ChangePath(BezierPathManager path)
    {
        yield return new WaitForSeconds(1.0f);
        transform.GetComponent<bezierMove>().SetPath(path);
    }

}
