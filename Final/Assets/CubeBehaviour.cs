using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    public Material bronzeHighlight;
    public Material silverHighlight;
    public Material goldHighlight;
    public Material bronzeColor;
    public Material silverColor;
    public Material goldColor;
    public GameObject bronzeSound;
    public GameObject silverSound;
    public GameObject goldSound;

    public OreType Cubetype;

    void OnMouseDown()
    {
        if (Cubetype == OreType.Bronze)
        {
            GameControl.bronzeOre--;
            GameControl.score = GameControl.score + GameControl.bronzeScore;
            Instantiate(bronzeSound);
        } else if (Cubetype == OreType.Silver)
        {
            GameControl.silverOre--;
            GameControl.score = GameControl.score + GameControl.silverScore;
            Instantiate(silverSound);
        } else if (Cubetype == OreType.Gold)
        {
            GameControl.goldOre--;
            GameControl.score = GameControl.score + GameControl.goldScore;
            Instantiate(goldSound);
        }

        Destroy(gameObject);

        print("Score: " + GameControl.score);
    }

    void OnMouseOver()
    {
        if (Cubetype == OreType.Bronze)
        {
            GetComponent<Renderer>().material = bronzeHighlight;
        }
        else if (Cubetype == OreType.Silver)
        {
            GetComponent<Renderer>().material = silverHighlight;
        }
        else if (Cubetype == OreType.Gold)
        {
            GetComponent<Renderer>().material = goldHighlight;
        }
    }

    void OnMouseExit()
    {
        if (Cubetype == OreType.Bronze)
        {
            GetComponent<Renderer>().material = bronzeColor;
        }
        else if (Cubetype == OreType.Silver)
        {
            GetComponent<Renderer>().material = silverColor;
        }
        else if (Cubetype == OreType.Gold)
        {
            GetComponent<Renderer>().material = goldColor;
        }
    }

}
