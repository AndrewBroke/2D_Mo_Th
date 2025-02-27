using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Transform leftUp;
    public Transform rightUp;
    public Transform rightDown;
    public Transform leftDown;
    public Transform map;

    public float scale = 1;
    // �� ������� ��������� ��� �����
    public float xStep = 1;
    public float yStep = 1;

    // ������� ��� ������
    public GameObject[] groundTiles;
    public GameObject[] sandTiles;
    public GameObject water;
    public GameObject[] trees;
    public float xOrg = 0;
    public float yOrg = 0;

    // ������ � ������ �����
    int width;
    int height;

    // Start is called before the first frame update
    void Start()
    {
        // ������� ���������� ������
        width = (int)(rightUp.position.x - leftUp.position.x)/(int)xStep;
        height = (int)(rightUp.position.y - rightDown.position.y) / (int)yStep;
        xOrg = Random.Range(0, 100);
        yOrg = Random.Range(0, 100);

        // ���������� �����
        Spawn();
    }

    void Spawn()
    {
        for(float x = leftUp.position.x; x <= rightUp.position.x; x += xStep)
        {
            for (float y = leftUp.position.y; y > leftDown.position.y; y -= yStep)
            {


                //GameObject newTile = Instantiate(tile, new Vector3(x, y, 0), Quaternion.identity);
                //newTile.transform.SetParent(map);

                // ���������� ���
                float xCoord = xOrg + x / width * scale;
                float yCoord = yOrg + y / height * scale;
                float noise = Mathf.PerlinNoise(xCoord, yCoord);
                // 0 - 0.4 -> �����
                // 0.41 - 0.75 -> �����
                // 0.76 - 1 -> ����
                if(noise <= 0.6f)
                {
                    // ����� �����
                    int groundIndex = Random.Range(0, groundTiles.Length);
                    GameObject ground = groundTiles[groundIndex];
                    // ����� �����
                    GameObject newGround = Instantiate(ground,
                        new Vector3(x, y, 0), Quaternion.identity);
                    // �������� � ������ ������
                    newGround.transform.SetParent(map);

                    int treeChance = Random.Range(1, 101);
                    if(treeChance < 5)
                    {
                        int treeIndex = Random.Range(0, trees.Length);
                        GameObject tree = trees[treeIndex];
                        GameObject newTree = Instantiate(
                            tree,
                            new Vector3(x, y, 0),
                            Quaternion.identity
                            );
                        newTree.transform.SetParent(map);
                    }
                }
                else if(noise <= 0.75)
                {
                    // ����� �����
                    int sandIndex = Random.Range(0, sandTiles.Length);
                    GameObject sand = sandTiles[sandIndex];
                    GameObject newSand = Instantiate(
                        sand,
                        new Vector3(x, y, 0),
                        Quaternion.identity
                        );
                    newSand.transform.SetParent(map);
                }
                else
                {
                    // ����� ����
                    GameObject newWater = Instantiate(
                        water,
                        new Vector3(x, y, 0),
                        Quaternion.identity
                        );
                    newWater.transform.SetParent(map);
                }

                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
