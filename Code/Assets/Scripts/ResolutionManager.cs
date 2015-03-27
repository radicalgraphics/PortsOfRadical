//// (c)2015 Radical Graphics Studios
//// www.radicalgraphics.com
////
using UnityEngine;
using System.Collections;


/// <summary>
/// Resolution Manager rescales resolution based on the Camera spect ratio
/// </summary>

public class ResolutionManager : MonoBehaviour 
{
    public Transform[] toScale;                     //Elements to scale
    public Transform[] toReposition;                //Elements to reposition

    //public Renderer floor;                          //The renderer of the floor
    //public Renderer roof;                           //The renderer of the roof
    private float scaleFactor;                      //The current scale factor
    //private float repositionFactor;               // The Reposition Factor will be used to reposition any elements in the toReposition Transform array.      
    void Start()
    {
		scaleFactor = Camera.main.aspect / 1.28f;
        //repositionFactor = Camera.main.aspect; // First value test to relocate elements.
        //Rescale elements
        foreach (Transform item in toScale)
            item.localScale = new Vector3(item.localScale.x * scaleFactor, item.localScale.y * scaleFactor, item.localScale.z);

        //Reposition Elements
        foreach (Transform item in toReposition)
            item.position = new Vector3(item.position.x * scaleFactor, item.position.y, item.position.z);
            //item.position = new Vector3(item.position.x * repositionFactor, item.position.y, item.position.z); 

        //Rescale floor 
        //floor.material.mainTextureScale = new Vector2(scaleFactor, 1);
        //Rescale roof
        //roof.material.mainTextureScale = new Vector2(scaleFactor, 1);
    }
}
