using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {
  //creates an array called allCubes?
    private GameObject[] allCubes;

    //declare a gameobject before using it, so the code knows what it's looking at. in gamemaker, you can program right into that specific object,
    //but in unity it's necessary to alert the code it'll be used...
    //i noticed that when you declare variables at the top, they make space in the inspector to drag them in there.
    //not 100% sure why that's necessary but it certainly feels satisfying 
    public GameObject CubePrefab;
    //you could put this in the for loop, but this way we can change it in the inspector
    int numCubes = 16;

	// Use this for initialization
	void Start () {


        //previously defined array now has stuff inside it, so it's a new Gameobject with [16] cubes 
        allCubes = new GameObject[numCubes];
        //use for loops to increase i per loop
        // first param is start, second is end, third is incrementation
        //i++ means add 1 each subsequent loop
        for (int i = 0; i < numCubes; i++)
        {
            //instantiate() takes parameters: the name of the object/prefab, the place, and rotation
            //i replaces the x value in this context because the x value of the cubes are increasing (will place them side by side?)

            //allCubes[i] = allCubes[0] and increments with the for loop, placing each instantiation into a new array slot [1], [2]...
            allCubes[i] =  (GameObject) Instantiate (CubePrefab, new Vector3(i*2, 0, 0), Quaternion.identity);
        }
        


	}


    public void ProcessClickedCube(GameObject clickedCube)
    {

        foreach (GameObject oneCube in allCubes) //oneCube is 1 element of the array, like i. allCubes is a variable in GameControllerScript
        {
        //you then call each item of the array and change them individually
          oneCube.GetComponent<Renderer>().material.color = Color.white;
        }

               {
                  clickedCube.GetComponent<Renderer>().material.color = Color.red;
            }
    }



    // Update is called once per frame
    void Update()
    {
	    
	}
}
