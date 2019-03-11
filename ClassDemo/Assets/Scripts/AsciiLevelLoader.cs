using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + "/level0.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "X");
        }

        string[] inputLines = File.ReadAllLines(filePath);

        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];
    
            for (int x = 0; x < line.Length; x++)
            {
/*                if (line[x] == 'X')
                {
                    //make a wall
                    GameObject newWall = Instantiate(Resources.Load("Prefabs/Wall")) as GameObject;
                    newWall.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
                }
                else if (line[x] == 'P')
                {
                    //make a wall
                    GameObject newPlayer = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
                    newPlayer.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
                }
                else if (line[x] == 'G')
                {
                    //make a wall
                    GameObject newGold = Instantiate(Resources.Load("Prefabs/Gold")) as GameObject;
                    newGold.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
                }
                else if (line[x] == 'T')
                {
                    //make a wall
                    GameObject newTrap = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;
                    newTrap.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
                }*/

                GameObject tile = null;

                switch (line[x])
                {
                    case 'X':
                        tile = Instantiate(Resources.Load("Prefabs/Wall")) as GameObject;
                        break;
                    case 'P':
                        tile = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
                        break;
                    case 'G':
                        tile = Instantiate(Resources.Load("Prefabs/Gold")) as GameObject;
                        break;
                    case 'T':
                        tile = Instantiate(Resources.Load("Prefabs/Trap")) as GameObject;
                        break;
                    default:
                        tile = null;
                        break;
                }

                if (tile != null)
                {
                    tile.transform.position = new Vector2(x - line.Length/2f, inputLines.Length/2f - y);
                }
            }        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
