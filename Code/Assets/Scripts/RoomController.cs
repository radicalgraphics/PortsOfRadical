using UnityEngine;
using System.Collections;

public class RoomController : MonoBehaviour {

    //public GameObject room;
    private Animator roomAnimator;
    public Animator roomGridAnimator;
    public float delayTime = 10.0f;
    void Start () {
        
        roomAnimator = this.GetComponent<Animator>();
        roomAnimator.SetBool("Occupied", false); // Default Animator State - False.
        roomGridAnimator.SetBool("Occupied", false); // Default Animator State - False.
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Patient")
        {
            roomAnimator.SetInteger("state", 1);
            roomGridAnimator.SetInteger("state", 1);
        }
        //else if (other.tag = "Doctor") // JUST IN CASE
        //{
        //    roomAnimator.SetBool("Occupied", true);
        //} 
    }

    void OnTriggerStay2D(Collider2D other)
    {
        roomAnimator.SetInteger("state", 1);
        roomGridAnimator.SetInteger("state", 1);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Patient")
        {
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
        roomAnimator.SetInteger("state", 0);
        roomGridAnimator.SetInteger("state", 0);
    }
}
