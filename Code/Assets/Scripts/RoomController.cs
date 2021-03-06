﻿using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

    //public GameObject room;
    private Animator roomAnimator;
    public Animator roomGridAnimator;
    public float delayTime = 8.0f;
    private bool patientOnTheRoom;

    // States
    // 0 - Available Room.
    // 1 - Room occupied.
    // 2 - Room on delay.
    void Start () {
        patientOnTheRoom = false;
        roomAnimator = this.GetComponent<Animator>();
        //roomAnimator.SetBool("Occupied", false); // Default Animator State - False.
        //roomGridAnimator.SetBool("Occupied", false); // Default Animator State - False.

        roomAnimator.SetInteger("state", 0);
        roomGridAnimator.SetInteger("state", 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Patient")
        {
            roomAnimator.SetInteger("state", 1);
            roomGridAnimator.SetInteger("state", 1);
            patientOnTheRoom = true;
        }
        //else if (other.tag = "Doctor") // JUST IN CASE
        //{
        //    roomAnimator.SetBool("Occupied", true);
        //} 
    }

    //void OnTriggerStay2D(Collider2D other)
    //{
    //    roomAnimator.SetInteger("state", 1);
    //    roomGridAnimator.SetInteger("state", 1);
    //}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Patient")
        {
            patientOnTheRoom = false;
            StartCoroutine(SetSensorDelay());
            //roomAnimator.SetBool("Occupied", false);
            //roomGridAnimator.SetBool("Occupied", false);
        }
    }

    public IEnumerator SetSensorDelay()
    {
        
        roomAnimator.SetInteger("state", 2);
        roomGridAnimator.SetInteger("state", 2);
        yield return new WaitForSeconds(delayTime);
        if (!patientOnTheRoom)
        {
            roomAnimator.SetInteger("state", 0);
            roomGridAnimator.SetInteger("state", 0);
        }
        
    }

    public int GetRoomState()
    {
        return roomAnimator.GetInteger("state");
    }
}
