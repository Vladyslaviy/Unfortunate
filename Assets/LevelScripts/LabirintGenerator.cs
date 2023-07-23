using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirintGenerator : MonoBehaviour
{
    public GameObject wallSample;
    public GameObject angleSample; //Right Top
    void Start()
    {
        //int[][] tile_map =
        //{
        //    new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        //    new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        //    new int[] { 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1 },
        //    new int[] { 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1 },
        //    new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1 },
        //    new int[] { 1, 0, 1, 0, 1, 3, 1, 0, 1, 0, 1 },
        //    new int[] { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 },
        //    new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1 },
        //    new int[] { 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1 },
        //    new int[] { 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1 },
        //    new int[] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        //};
        int[][] tile_map =
        {
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 3, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        };
        for (int i1 = 0; i1 < tile_map.Length; i1++)
        {
            for (int i2 = 0; i2 < tile_map[i1].Length; i2++)
            {
                try
                {
                    if (tile_map[i1][i2] == 1)
                    {
                        float x = (i2 - 5.0f) * 2.0f;
                        float z = -(i1 - 5.0f) * 2.0f;
                        //edge angles
                        if ((i2 == tile_map.Length - 1 && i1 == 0) || (i2 == tile_map[i1].Length - 1 && i1 == tile_map.Length - 1) || (i2 == 0 && i1 == tile_map[i1].Length - 1) || (i2 == 0 && i1 == 0))
                        {
                            GameObject angle = Instantiate(angleSample);
                            int yR = 0;
                            if (i2 == tile_map.Length - 1 && i1 == 0)// top right
                            {
                                angle.name = "top right";
                                yR = 0;
                            }
                            if (i2 == tile_map[i1].Length - 1 && i1 == tile_map.Length - 1)// bottom right
                            {
                                angle.name = "bottom right";
                                yR = 90;
                            }
                            if (i2 == 0 && i1 == tile_map[i1].Length - 1)// bottom left 
                            {
                                angle.name = "bottom left";
                                yR = 180;
                            }
                            if (i2 == 0 && i1 == 0)// top left
                            {
                                angle.name = "top left";
                                yR = 270;
                            }
                            angle.transform.rotation = Quaternion.Euler(0, yR, 0);
                            float x_angle = x - 0.5f, z_angle = z - 0.5f;
                            if (x < 0)
                            {
                                x_angle = x + 0.5f;
                            }
                            if (z < 0)
                            {
                                z_angle = z + 0.5f;
                            }
                            angle.transform.position = new Vector3 { x = x_angle, y = 4, z = z_angle };
                        }
                        else//sides
                            if (i2 == 0 || i2 == tile_map.Length - 1)
                        {
                            GameObject wallSide = Instantiate(wallSample);
                            wallSide.transform.rotation = Quaternion.Euler(0, 0, 0);
                            wallSide.transform.position = new Vector3 { x = x, y = 4, z = z };
                        }
                        else//top bottom
                            if (i1 == 0 || i1 == tile_map.Length - 1)
                        {
                            GameObject wallTop = Instantiate(wallSample);
                            wallTop.transform.rotation = Quaternion.Euler(0, 90, 0);
                            wallTop.transform.position = new Vector3 { x = x, y = 4, z = z };
                        }
                        else//hard(inside) angles
                            if ((tile_map[i1 + 1][i2] == 1 && tile_map[i1][i2 + 1] == 1) ||     // top left
                                (tile_map[i1 + 1][i2] == 1 && tile_map[i1][i2 - 1] == 1) ||     // top right
                                (tile_map[i1 - 1][i2] == 1 && tile_map[i1][i2 + 1] == 1) ||     // bottom left 
                                (tile_map[i1 - 1][i2] == 1 && tile_map[i1][i2 - 1] == 1))       // bottom right
                        {
                            GameObject angle = Instantiate(angleSample);
                            int yR = 0;
                            if (tile_map[i1 + 1][i2] == 1 && tile_map[i1][i2 - 1] == 1)// top right
                            {
                                yR = 0;
                            }
                            if (tile_map[i1 - 1][i2] == 1 && tile_map[i1][i2 - 1] == 1)// bottom right
                            {
                                yR = 90;
                            }
                            if (tile_map[i1 - 1][i2] == 1 && tile_map[i1][i2 + 1] == 1)// bottom left 
                            {
                                yR = 180;
                            }
                            if (tile_map[i1 + 1][i2] == 1 && tile_map[i1][i2 + 1] == 1)// top left
                            {
                                yR = 270;
                            }
                            angle.transform.rotation = Quaternion.Euler(0, yR, 0);
                            float x_angle=x-0.5f, z_angle = x - 0.5f;
                            if (x < 0)
                            {
                                x_angle = x + 0.5f;
                            }
                            if (z < 0)
                            {
                                z_angle = z + 0.5f;
                            }
                            angle.transform.position = new Vector3 { x = x_angle, y = 4, z = z_angle };
                            //GameObject wallTop = Instantiate(wallSample);
                            //GameObject wallSide = Instantiate(wallSample);
                            //wallTop.transform.rotation = Quaternion.Euler(0, 90, 0);
                            //wallSide.transform.rotation = Quaternion.Euler(0, 0, 0);
                            //wallTop.transform.position = new Vector3 { x = x, y = 4, z = z };
                            //wallSide.transform.position = new Vector3 { x = x, y = 4, z = z };
                        }
                        else //top bottom simple wall
                            if (tile_map[i1][i2 - 1] == 1 || tile_map[i1][i2 + 1] == 1)
                        {
                            GameObject wallSide = Instantiate(wallSample);
                            wallSide.transform.rotation = Quaternion.Euler(0, 90, 0);
                            wallSide.transform.position = new Vector3 { x = x, y = 4, z = z };
                        }
                        else //side simple wall
                            if (tile_map[i1 - 1][i2] == 1 || tile_map[i1 + 1][i2] == 1)
                        {
                            GameObject wallTop = Instantiate(wallSample);
                            wallTop.transform.rotation = Quaternion.Euler(0, 0, 0);
                            wallTop.transform.position = new Vector3 { x = x, y = 4, z = z };
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.LogWarning(e.Message);
                    throw e;
                }
            }
        }
    }

    void Angle()
    {
        GameObject wallTop = Instantiate(wallSample);
        GameObject wallSide = Instantiate(wallSample);
        wallTop.transform.rotation = Quaternion.Euler(0, 90, 0);
        wallSide.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    GameObject WallTopBottom()
    {
        GameObject wallTopBottom = wallSample;
        wallTopBottom.transform.rotation = Quaternion.Euler(0, 90, 0);
        return wallTopBottom;
    }
    GameObject WallSide()
    {
        GameObject wallSide = wallSample;
        wallSide.transform.rotation = Quaternion.Euler(0, 0, 0);
        return wallSide;
    }
    void Update()
    {

    }
}
