using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//notes: miningSpeed wasn't specified in the new directions. Should it still only be mining every 3 seconds?
//kept it as-is for now

//Wasn't sure whether to track Ore or Supply to decide when to spawn more
//solved w/ process of elimination

public class GameControl : MonoBehaviour
{
    public static int bronzeOre;
    public static int silverOre;
    public static int goldOre;
    public static int bronzeScore;
    public static int silverScore;
    public static int goldScore;
    int bronzeSupply;
    int silverSupply;
    int goldSupply;
    int miningSpeed;
    int bx; //tracks x position of bronze cube
    int by; //tracks y position of bronze cube
    int sx; //tracks x position of silver cube
    int sy; //track y position of silver cube
    int mineTime;
    public static int score;


    public GameObject cubePrefab;
    public GameObject silverPrefab;
    public GameObject goldPrefab;
    public Material bronzeColor;
    public Material silverColor;
    public Material goldColor;

    Vector3 cubePosition;
    GameObject currentBCube;
    GameObject currentSCube;
    GameObject currentGCube;

    // Use this for initialization
    void Start()
    {
        bronzeOre = 0;
        silverOre = 0;
        goldOre = 0;
        bronzeSupply = 3;
        silverSupply = 2;
        goldSupply = 0;
        miningSpeed = 3;
        bx = 0;
        by = 0;
        sx = 0;
        sy = 0;
        mineTime = 0;
        bronzeScore = 1;
        silverScore = 10;
        goldScore = 100;
    }

    // Update is called once per frame
    void Update()
    {
        //controls positioning of cubes
        bx = Random.Range(-5, 5);
        by = Random.Range(-4, 4);
        sx = Random.Range(-5, 5);
        sy = Random.Range(-4, 4);

        //every 3 seconds, prints the players bronze and silver amounts
        if (Time.time > mineTime)
        {
            
            //starts the mining process
           if (mineTime >= miningSpeed)
            {
                //mines bronze ore
                if (bronzeSupply < 4)
                {
                    bronzeSupply += 1;
                } else {
                    bronzeOre += 1;
                    bronzeSupply -= 1;
                    //spawns bronze cubes
                    if (bronzeOre != 0)
                    {   
                        currentBCube = Instantiate(cubePrefab, cubePosition, Quaternion.identity);
                        currentBCube.GetComponent<Renderer>().material = bronzeColor;
                        gameObject.GetComponent<CubeBehaviour>();
                        cubePosition = new Vector3(bx, by, 0);
                    }
                    
                }

                //mines silver ore
                if (bronzeSupply >= 4)
                {
                    silverSupply += 1;
                } else { 
                silverOre += 1;
                silverSupply -= 1;
                    //spawns silver cubes
                    if (silverOre != 0)
                    {   
                        currentSCube = Instantiate(silverPrefab, cubePosition, Quaternion.identity);
                        currentSCube.GetComponent<Renderer>().material = silverColor;
                        cubePosition = new Vector3(sx, sy, 0);
                    }
                }
            }
           if (bronzeOre == 2 && silverOre == 2)
            {
                goldSupply += 1;
                goldOre += 1;
                if (goldOre != 0)
                {
                    currentGCube = Instantiate(goldPrefab, cubePosition, Quaternion.identity);
                    currentGCube.GetComponent<Renderer>().material = goldColor;
                    cubePosition = new Vector3(-3, 0, 0);
                    goldOre = -1;
                }
            }
            mineTime += 1;
            print("You have " + bronzeOre + " Bronze Ore, and " + silverOre + " Silver Ore.");
            
        }
    }
}