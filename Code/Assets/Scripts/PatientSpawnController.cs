using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SWS;

public class PatientSpawnController : MonoBehaviour {

    public GameObject patient;
    public GameObject spawnPosition;
    public BezierPathManager path;
    private GameObject newPatient;
    public Transform waypointManagerTransform;
    private int patientNumber = 0;
    public PatientSpawnController spawnController;
    public int maxPatients;
	// Use this for initialization
    //void Start () {
	
    //}
	
    //// Update is called once per frame
    //void Update () {
	
    //}

    public void GenerateNewPatient()
    {
        if (patientNumber < maxPatients)
        {
            GameObject newPatient = Instantiate(patient, spawnPosition.transform.position, Quaternion.identity) as GameObject;
            newPatient.GetComponent<bezierMove>().pathContainer = path;
            newPatient.GetComponent<FindFreeRoom>().waypointManager = waypointManagerTransform;
            newPatient.GetComponent<FindFreeRoom>().patientSpawnController = this;
            patientNumber++;
        }
    }

    public void ReducePatient()
    {
        patientNumber--;
    }
}
