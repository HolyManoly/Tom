using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateMap : MonoBehaviour
{
    public GameObject[][] Map;
    public int MapWidth;
    public int MapLength;

    public int maksimalnaVisina = 10;
    public int visina;
    public List<GameObject> sprat;
    public List<GameObject> krov;
    public List<GameObject> prizemlje;
    public GameObject ulicaHor;
    public GameObject ulicaVer;
    public GameObject raskrsnica;

    void Start()
    {
        MapWidth = Random.Range(32, 33);
        MapLength = Random.Range(32, 33);

        Map = new GameObject[MapWidth][];
        for (int i = 0; i < MapWidth; i++)
            Map[i] = new GameObject[MapLength];

        for (int i = 0; i < Random.Range(30, 50); i++)
            GenerateStreet();
/*
        for (int i = 0; i < MapWidth; i++)
            for (int j = 0; j < MapLength; j++)
                if (Map[i][j] == null)
                    Map[i][j] = GenerateBuilding(i, j);
*/
        string text = "";
        for (int i = 0; i < MapWidth; i++)
        {
            for (int j = 0; j < MapLength; j++)
                if (Map[i][j].CompareTag("Road"))
                    text += " ";
                else
                    text += "x";

            text += "\n";
        }

        print(text);
    }

    private void GenerateStreet()
    {
        int startX = Random.Range(1, MapWidth - 1);
        int startY = Random.Range(1, MapLength - 1);

        int endX = Random.Range(1, MapWidth - 1);
        int endY = Random.Range(1, MapLength - 1);

        int minX = Mathf.Min(startX, endX);
        int maxX = Mathf.Max(startX, endX);
        int minY = Mathf.Min(startY, endY);
        int maxY = Mathf.Max(startY, endY);

        if (Random.Range(1, 100) % 2 == 0)
        {
            for (int i = minX; i < maxX; i++)
                GenerateStreetTile(i, minY, ulicaHor);

            for (int i = minY; i < maxY; i++)
                GenerateStreetTile(maxX, i, ulicaVer);
        }
        else
        {
            for (int i = minX; i < maxX; i++)
                GenerateStreetTile(i, maxY, ulicaHor);

            for (int i = minY; i < maxY; i++)
                GenerateStreetTile(minX, i, ulicaVer);
        }
    }

    private void GenerateStreetTile(int x, int y, GameObject tile)
    {
        float z = -20f;//x == 0 ? -10f : -10f / (x * 1f);

        //float modifier = ulicaHor.GetComponentsInChildren<SpriteRenderer>()[0].bounds.size.x;
        float modifier = 1.3f;
        if (Map[x][y] == null)
            Map[x][y] = (GameObject)Instantiate(tile, new Vector3(x * modifier, y * modifier + modifier, z), Quaternion.identity);
        else
        {
            Destroy(Map[x][y]);
            Map[x][y] = (GameObject)Instantiate(raskrsnica, new Vector3(x * modifier, y * modifier + modifier, z), Quaternion.identity);
        }
    }

    private GameObject GenerateBuilding(int x, int y)
    {
        GameObject zgrada;

        int buildingType = 2;
        float chance = Random.Range(0f, 1f);
        if (chance > 0.8f)
            buildingType = 0;
        else if (chance <= 0.8f && chance > 0.5f)
            buildingType = 1;

        float xStart = 0f;
        if (x > 0)
        {
            GameObject previous = Map[x - 1][y];
            float xModifier = 0f;
            if (previous && previous.CompareTag("Road"))
                xModifier = 4.5f;
            else if (previous && previous.CompareTag("Building"))
                xModifier = 5f;

            xStart = previous.transform.position.x + xModifier;
        }

        float yStart = 0f;
        if (y > 0)
        {
            GameObject previous = Map[x][y - 1];
            float yModifier = 0f;
            if (previous && previous.CompareTag("Road"))
                yModifier = 2.55f;
            else if (previous && previous.CompareTag("Building"))
                yModifier = 3.05f;

            yStart = previous.transform.position.y + yModifier;
        }

        visina = Random.Range(1, maksimalnaVisina);
        float z = x == 0 ? -10f : -10f / (x*1f);

        zgrada = (GameObject)Instantiate(prizemlje[buildingType], new Vector3(xStart, 
                                                                              yStart, 
                                                                              z), 
                                         Quaternion.identity);

        /*for (int i = 1; i < visina; i++)
            Instantiate(sprat[buildingType], new Vector3(xStart + 1.5f, 
                                                         yStart + 2.5f + 0.3f * i, 
                                                         z), 
                    Quaternion.identity);

        Instantiate(krov[buildingType], new Vector3(xStart + 1.5f, 
                                                    yStart + 2.5f + 0.3f * visina - 0.15f, 
                                                    z), 
                    Quaternion.identity);
                    */
        return zgrada;
    }
}
