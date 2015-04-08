using UnityEngine;
using System.Collections;

public class RoomPathData : MonoBehaviour {

    public int patientsOnPath;
    public RoomController roomController;
	void Start () {
        patientsOnPath = 0;
	}

    public int GetPatientsOnPath()
    {
        return patientsOnPath;
    }

    public void SetPatientsOnPath()
    {
        patientsOnPath++;
    }
    public void ClearPath()
    {
        patientsOnPath = 0;
    }
	public int GetRoomState()
    {
        return roomController.GetRoomState();
    }
}
