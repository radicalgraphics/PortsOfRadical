using UnityEngine;
using System.Collections;

public class RoomPathData : MonoBehaviour {

    public int patientsOnPath;

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
	
}
