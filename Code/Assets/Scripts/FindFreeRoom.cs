using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SWS;

public class FindFreeRoom : MonoBehaviour {

    private BezierPathManager bezierPathManager;
    public List<BezierPathManager> roomPathsList;
    public List<BezierPathManager> exitPathsList;
    public List<BezierPathManager> delayPathsList;
    private BezierPathManager roomPathTaken;
    public Transform waypointManager;
    private int patientsOnPath;                         // Patients on a path.
    private bool roomVisited;                           // to set that the patient goes to a room or is in the room.
    private bool exit;                                  // exit is to control that the patient is getting out of the hospital.
    private bool waitForRoom;                           // If the rooms are taken the patient has to wait.
    private bool takingABreak;
    public PatientSpawnController patientSpawnController;
    private bool waiting;
    //public float timeOnRoom;
	// Use this for initialization
	void Start () {
        waiting = false;
        patientsOnPath = 0;
        waitForRoom = false;
        roomVisited = false;
        takingABreak = false;
        exit = false;
        roomPathsList = new List<BezierPathManager>();
        exitPathsList = new List<BezierPathManager>();
        delayPathsList = new List<BezierPathManager>();

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
            if (path.tag == "DelayPath")
            {
                bezierPathManager = path.GetComponent<BezierPathManager>();
                delayPathsList.Add(bezierPathManager);
            }
        }
	}
	
    public void CheckWhereToGo(){
        //roomVisited = false;
        // If the patient didn't visit a room.
        if (!roomVisited)
        {
            // We check all the available rooms.

            foreach (BezierPathManager roomPath in roomPathsList)
            {
                if (roomPath.GetComponent<RoomPathData>().GetRoomState() == 0)
                {

                
                    patientsOnPath = roomPath.GetComponent<RoomPathData>().GetPatientsOnPath();
                    // If the patient finds an empty room (path) we change his/her Patient Path to that roomPath.
                    if (patientsOnPath == 0)
                    {
                        waiting = false;
                        Debug.Log("Waiting is false?: " + waiting);
                        // We have found a free room and we send the patient to that room.
                        transform.GetComponent<bezierMove>().moveToPath = true;
                    
                        // We save the path to the taken room to use it later to exit from the building.
                        roomPathTaken = roomPath;
                        StartCoroutine(ChangePath(roomPath, 2.0f));

                        if (roomPath.tag == "RoomPath")
                        {
                            roomPath.transform.GetComponent<RoomPathData>().SetPatientsOnPath();
                        }
                        roomVisited = true;
                        Debug.Log("roomVisited is true?: " + waiting);
                        return;
                    }
                    else
                    {
                        continue;
                    
                    }
                }
                else
                {
                    waiting = true;
                }
            }
            
            if (waiting)
            {
                Debug.Log("Patient: " + gameObject.GetInstanceID() + " - waiting: " + waiting);
                StartCoroutine(FunctionLibrary.CallWithDelay(CheckWhereToGo, 0.5f));
            }
            
        }
        // If the patient has visited a room it goes out of the building.
        // There are special cases for Room 103 and ... TBD
        else if (roomVisited && !exit && !takingABreak)
        {
            if (roomPathTaken.name == "roomPath101")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath101"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath102")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath102"), Random.Range(2.0f, 8.0f)));
            }
                // For this Room we will set the Patient will take a Break.
            else if (roomPathTaken.name == "roomPath103")
            {
                StartCoroutine(TakeABreak(delayPathsList.Find(delayPath => delayPath.name == "roomPathDelay103"), Random.Range(2.0f, 5.0f)));
            }
            else if (roomPathTaken.name == "roomPath104")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath104"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath105")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath105"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath106")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath106"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath107")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath107"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath108")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath108"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath109")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath109"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath110")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath110"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath111")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath111"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath112")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath112"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath113")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath113"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath114")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath114"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath115")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath115"), Random.Range(2.0f, 8.0f)));
            }
            else if (roomPathTaken.name == "roomPath116")
            {
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath116"), Random.Range(2.0f, 8.0f)));
            }

            if (roomPathTaken.name != "roomPath103")
            {
                exit = true;
            }
            

        }
        else if (takingABreak)              // If the Patient is taking a break.
        {
            // If the patient has taken a break.
            if (roomPathTaken.name == "roomPathDelay103")
            {
                StartCoroutine(GetBackFromBreak(delayPathsList.Find(delayPath => delayPath.name == "roomPathDelayBack103"), Random.Range(2.0f, 5.0f)));
            }
            // If the patient has get back from the break.
            else if (roomPathTaken.name == "roomPathDelayBack103")
            {
                roomPathTaken = roomPathsList.Find(roomPath => roomPath.name == "roomPath103");
                StartCoroutine(ChangePath(exitPathsList.Find(exitPath => exitPath.name == "exitPath103"), Random.Range(2.0f, 8.0f)));
                
                takingABreak = false;
                exit = true;
            }

            
        }
        else if (exit)
        {
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        //else
        //{
        //    waiting = true;
        //}

        //if (waiting)
        //{
        //    Debug.Log("Check Again 2..." + " - roomVisited: " + roomVisited);
        //    FunctionLibrary.CallWithDelay(CheckWhereToGo, 1.0f);
        //}
    }

    public IEnumerator TakeABreak(BezierPathManager path, float time)
    {
        
        exit = false;                                           // It's not getting out yet.
        takingABreak = true;                                    // We set that it's taking a break.
        yield return new WaitForSeconds(time);                  // Wait for 'time' seconds.
        transform.GetComponent<bezierMove>().SetPath(path);     // It goes to the break path.
        roomPathTaken = path;                                   // The taken path is updated.
        this.GetComponent<Animator>().SetBool("waiting", true);
    }

    public IEnumerator GetBackFromBreak(BezierPathManager path, float time)
    {
        yield return new WaitForSeconds(time);
        this.GetComponent<Animator>().SetBool("waiting", false);
        roomPathTaken = path;                                   // The taken path is updated.
        transform.GetComponent<bezierMove>().SetPath(path);
    }

    public IEnumerator ChangePath(BezierPathManager path, float time)
    {
        
        yield return new WaitForSeconds(time);
        
        transform.GetComponent<bezierMove>().SetPath(path);

        if (roomVisited && exit)
        {
            //yield return new WaitForSeconds(10.0f); // If the patient left the room to leave the hospital we wait 10 seconds for the delay sensor.
            patientSpawnController.ReducePatient();
            roomPathTaken.transform.GetComponent<RoomPathData>().ClearPath();
        }
        
    }

}
