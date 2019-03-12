using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string filePath = Application.dataPath + "/Files/level" + SceneManager.sceneCountInBuildSettings + ".txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "XXXXXXXXXXXXXXXXXXXXXXXX");
        }

        string[] inputLines = File.ReadAllLines(filePath);

        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[inputLines.Length - 1 - y];

            for (int x = 0; x < line.Length; x++)
            {
                GameObject tile = Instantiate(Resources.Load("Prefabs/" + line[x]), gameObject.transform) as GameObject;
                tile.transform.position = new Vector2(x - 12, y - 5);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
    
