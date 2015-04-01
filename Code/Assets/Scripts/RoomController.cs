using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

    public GameObject room;
    private Animator roomAnimator;
	
    
    void Start () {
        roomAnimator = room.GetComponent<Animator>();
        roomAnimator.SetBool("Occupied", false); // Default Animator State - False.
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Patient")
        {
            roomAnimator.SetBool("Occupied", true);
        }
        //else if (other.tag = "Doctor") // JUST IN CASE
        //{
        //    roomAnimator.SetBool("Occupied", true);
        //} 
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Patient")
        {
            roomAnimator.SetBool("Occupied", false);
        }
    }
}
