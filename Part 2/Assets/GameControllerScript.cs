﻿using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour
{
    //creates an array called allCubes?
    //array with 2 coordinates need a comma 
    private GameObject[,] allCubes;

    //declare a gameobject before using it, so the code knows what it's looking at. in gamemaker, you can program right into that specific object,
    //but in unity it's necessary to alert the code it'll be used...
    //i noticed that when you declare variables at the top, they make space in the inspector to drag them in there.
    //not 100% sure why that's necessary but it certainly feels satisfying 
    public GameObject CubePrefab;
    //you could put this in the for loop, but this way we can change it in the inspector
    int numCubesWide = 16;
    int numCubesTall = 9;
    float timeToAct = 0.0f;
    float turnLength = 1.5f;
    

    //since we defined airplane as its own class, we call it 'airplane' instead of gameobject.
    //consequently, the airplane object will have its own settings we need to define. 

    public Airplane airplane;

    void Start()
    {
        airplane = new Airplane();

        //previously defined array now has stuff inside it, so it's a new Gameobject with [16] cubes 
        allCubes = new GameObject[numCubesWide, numCubesTall];

        //in for loops, first param is start, second is end, third is incrementation
        //++ means add 1 each subsequent loop

        for (int x = 0; x < numCubesWide; x++)
        {
            for (int y = 0; y < numCubesTall; y++)
            {
                //declared the array earlier in the code, assigning it now
                //instantiates 16 cubes and then 9 rows of that 

                allCubes[x, y] = (GameObject)Instantiate(CubePrefab, new Vector3(x * 2, y * 2, 0), Quaternion.identity);
                //allCubes[x,y] references the exact place of the cube we just used, GetComponent gets the info on which script, and .x says the x value of that component     
                allCubes[x, y].GetComponent<CubeBehavior>().x = x;
                allCubes[x, y].GetComponent<CubeBehavior>().y = y;


            }
        }
        //after unity is done making the grid, it turns the first one red
        //allCubes[0, numCubesTall - 1].GetComponent<Renderer>().material.color = Color.red;

        //creates the airplane

        airplane.x = 0;
        airplane.y = 8;
        //same place as the red square..[i,j]
        allCubes[0, numCubesTall - 1].GetComponent<Renderer>().material.color = Color.red;


        //instantiate() takes parameters: the name of the object/prefab, the place, and rotation
        //i replaces the x value in this context because the x value of the cubes are increasing (will place them side by side?)

        //allCubes[i] = allCubes[0] and increments with the for loop, placing each instantiation into a new array slot [1], [2]...
        // allCubes[i,j] =  (GameObject) Instantiate (CubePrefab, new Vector3(i*2, 0, 0), Quaternion.identity);



        //make a timer
        //this timer takes place every 1.5 seconds
        timeToAct = turnLength;

       
    }

    //passing in both x,y variables previously taken
    public void ProcessClickedCube(GameObject clickedCube, int x, int y)
    {





        // If the player clicks an inactive airplane, it should highlight... we need conditionals first
        //if the player's cursor is at the x and y position of an unhighlighted red airplane 
        if (x == airplane.x && y == airplane.y && airplane.active == false)
        {
            //the airplane is now highlighted
            airplane.active = true;
            //turn the cube yellow i guess
            clickedCube.GetComponent<Renderer>().material.color = Color.yellow;
        }
        // If the player clicks an active airplane, it should unhighlight
        //we used else if because you use else if the first if expression didn't work out
        else if (x == airplane.x && y == airplane.y && airplane.active == true)
        {
            airplane.active = false;
            clickedCube.GetComponent<Renderer>().material.color = Color.red;
        }
        //if {clickedCube.

            // If the player clicks the sky and there isn’t an active airplane, 
        //   nothing happens.


            // If the player clicks the sky and there is an active airplane,
        else if (airplane.active && (x != airplane.x || y != airplane.y))
        {
            // Set the old cube to white
            allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
            allCubes[x, y].GetComponent<Renderer>().material.color = Color.yellow;
            // Update the airplane to be in the new location
            airplane.x = x;
            airplane.y = y;

        }


        //   the airplane teleports to that location 
    }


    void Update()
    {

        //check if airplaine is in its start location, and then add 10 cargo but not more than max

        //when the time is greater than 1.5 seconds
        if (Time.time > timeToAct)
        { //add more time
            timeToAct += turnLength;

            //check if airplane is in its start location
            //which it should be, if we coded correctly...
            if (airplane.x == 0 && airplane.y == 8 && airplane.cargoCapacity <= 90)
            {//and, if it is, add 10 cargo to the airplane's load 
                airplane.cargo += 10;
                print("Cargo currently is = " + airplane.cargo);

            }
        }
        
    }
}