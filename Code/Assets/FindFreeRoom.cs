using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SWS;

public class FindFreeRoom : MonoBehaviour {

    private BezierPathManager bezierPathManager;
    private List<BezierPathManager> roomPathsList;
    public Transform waypointManager;
    private int patientsOnPath;
	// Use this for initialization
	void Start () {

        roomPathsList = new List<BezierPathManager>();
        // We go through all the Paths in the Waypoint Manager.
	    foreach (Transform path in waypointManager){
            
            // If the path is a RommPath we save it in the list.
            if (path.tag == "RoomPath")
            {
                bezierPathManager = path.GetComponent<BezierPathManager>();
                roomPathsList.Add(bezierPathManager);
            }
            
        }
	}
	
    public void CheckAvailableRoom(){

        foreach (BezierPathManager roomPath in roomPathsList)
        {
            Debug.Log("New Path: " + roomPath.name);
            int patientsOnPath = roomPath.GetComponent<RoomPathData>().GetPatientsOnPath();
            // If the patient finds an empty room (path) we change his/her Patient Path to that roomPath.
            if (patientsOnPath == 0)
            {
                Debug.Log("Are we inside the if? YES");
                //this.transform.GetComponent<bezierMove>().pathContainer = roomPath;

                transform.GetComponent<bezierMove>().moveToPath = true;

                StartCoroutine(ChangePath(roomPath));
                
                

                return;
            }
        }
    }

    public IEnumerator ChangePath(BezierPathManager roomPath)
    {
        yield return new WaitForSeconds(0.5f);
        transform.GetComponent<bezierMove>().SetPath(roomPath);
        roomPath.transform.GetComponent<RoomPathData>().SetPatientsOnPath();
        
        //transform.GetComponent<bezierMove>().StartMove();
    }
}
