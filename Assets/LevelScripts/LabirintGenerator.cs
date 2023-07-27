using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabirintGenerator : MonoBehaviour
{
    public GameObject wallSample;
    public GameObject angleSample; //Right Top
    public GameObject TangleSample; //Downwards
    public GameObject XangleSample; //X
    public GameObject Player; //X

    int[][] tile_map =
        {
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 ,1 ,0 ,0 ,0 ,0 ,0, 1 },
            new int[] { 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 0 ,0 ,1 ,0 ,0 ,0 ,0 ,0, 1 },
            new int[] { 1, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0 ,0 ,1 ,0 ,0 ,0 ,0 ,0, 1 },
            new int[] { 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0 ,0 ,0 ,1 ,1 ,0 ,0 ,0, 1 },
            new int[] { 1, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0 ,0 ,0 ,0 ,1 ,1 ,0 ,0, 1 },
            new int[] { 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0 ,0 ,0 ,0 ,0 ,1 ,0 ,0, 1 },
            new int[] { 1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0 ,1 ,0 ,0 ,0 ,0 ,0 ,0, 1 },
            new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 ,1 ,1 ,0 ,0 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,1 ,0 ,0 ,0 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1 ,1 ,1 ,1 ,0 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0 ,0 ,0 ,0 ,1 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 1, 0, 0, 1, 0, 1, 0, 1, 1 ,1 ,0 ,0 ,1 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 3 ,1 ,0 ,0 ,1 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1 ,1 ,1 ,0 ,1 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0 ,0 ,1 ,1 ,1 ,0 ,1 ,0, 1 },
            new int[] { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 ,0 ,0 ,0 ,0 ,0 ,1 ,0, 1 },
            new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1 ,1 ,1 ,1 ,1 ,1 ,1, 1 }
        };
    void Start()
    {
        //int[][] tile_map =
        //{
        //    new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        //    new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        //    new int[] { 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1 },
        //    new int[] { 1, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1 },
        //    new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1 },
        //    new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1 },
        //    new int[] { 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1 },
        //    new int[] { 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1 },
        //    new int[] { 1, 0, 0, 0, 1, 0, 1, 0, 1, 0, 1 },
        //    new int[] { 1, 0, 1, 1, 0, 0, 1, 0, 1, 3, 1 },
        //    new int[] { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        //};

        for (int i1 = 0; i1 < tile_map.Length; i1++)
        {
            for (int i2 = 0; i2 < tile_map[i1].Length; i2++)
            {
                float x = (float)((i2 - Math.Round(tile_map.Length / 2.0f - 0.5f)) * 2.0f);
                float z = (float)(-(i1 - Math.Round(tile_map[i1].Length / 2.0f - 0.5f)) * 2.0f);
                if (tile_map[i1][i2] == 3)
                {
                    Player.transform.position = new Vector3 {x=x,y=1,z=z};
                }else
                if (tile_map[i1][i2] == 1)
                {
                    //Debug.Log(i1 +"  "+ i2);
                    
                    //edge angles
                    if ((i2 == tile_map[i1].Length - 1 && i1 == 0) || (i2 == tile_map[i1].Length - 1 && i1 == tile_map.Length - 1) || (i2 == 0 && i1 == tile_map.Length - 1) || (i2 == 0 && i1 == 0))
                    {
                        GameObject angle = Instantiate(angleSample);
                        int yR = 0;
                        if (i2 == tile_map[i1].Length - 1 && i1 == 0)// top right
                        {
                            angle.name = "top right";
                            yR = 0;
                        }
                        if (i2 == tile_map[i1].Length - 1 && i1 == tile_map.Length - 1)// bottom right
                        {
                            angle.name = "bottom right";
                            yR = 90;
                        }
                        if (i2 == 0 && i1 == tile_map.Length - 1)// bottom left 
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
                    else
                    if (IsXAngle(i1, i2))
                    {
                        GameObject xangle = Instantiate(XangleSample);
                        xangle.transform.position = new Vector3 { x = x, y = 4, z = z };
                    }
                    else //T angles
                        if (GetTAngleType(i1, i2) > 0)
                    {
                        //Debug.Log("i1="+i1+"  i2="+i2);
                        int yR = 0;
                        float z_angle = z, x_angle = x;
                        GameObject tangle = Instantiate(TangleSample);
                        if (i2 > 0 && i1 < tile_map.Length - 1 && i2 < tile_map[i1].Length - 1)
                            if ((tile_map[i1][i2 - 1] == 1 && tile_map[i1][i2 + 1] == 1) && (tile_map[i1 + 1][i2] == 1))// downwards
                            {
                                z_angle = z - 0.5f;
                                if (z < 0)
                                {
                                    z_angle = z + 0.5f;
                                }
                                tangle.name = "downwards";
                                yR = 0;
                            }
                        if (i1 > 0 && i2 > 0 && i2 < tile_map[i1].Length - 1)
                            if ((tile_map[i1][i2 - 1] == 1 && tile_map[i1][i2 + 1] == 1) && (tile_map[i1 - 1][i2] == 1))// upwards
                            {
                                z_angle = z - 0.5f;
                                if (z < 0)
                                {
                                    z_angle = z + 0.5f;
                                }
                                tangle.name = "upwards";
                                yR = 180;
                            }
                        if (i1 > 0 && i1 < tile_map.Length - 1 && i2 < tile_map[i1].Length - 1)
                            if ((tile_map[i1 - 1][i2] == 1 && tile_map[i1 + 1][i2] == 1) && (tile_map[i1][i2 + 1] == 1))// right
                            {
                                z_angle = z;
                                x_angle = x - 0.5f;
                                if (x < 0)
                                {
                                    x_angle = x + 0.5f;
                                }
                                tangle.name = "right";
                                yR = 270;
                            }
                        if (i1 > 0 && i1 < tile_map.Length - 1 && i2 > 0 && i2 > 0)
                            if ((tile_map[i1 - 1][i2] == 1 && tile_map[i1 + 1][i2] == 1) && (tile_map[i1][i2 - 1] == 1))// left
                            {
                                z_angle = z;
                                x_angle = x - 0.5f;
                                if (x < 0)
                                {
                                    x_angle = x + 0.5f;
                                }
                                tangle.name = "left";
                                yR = 90;
                            }

                        tangle.transform.position = new Vector3 { x = x_angle, y = 4, z = z_angle };
                        tangle.transform.rotation = Quaternion.Euler(0, yR, 0);
                    }
                    else//sides
                        if (i2 == 0 || i2 == tile_map[i1].Length - 1)
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
                        float z_angle = z, x_angle = x;
                        GameObject angle = Instantiate(angleSample);
                        int yR = 0;
                        if (tile_map[i1 + 1][i2] == 1 && tile_map[i1][i2 - 1] == 1)// top right
                        {
                            z_angle = z - 0.5f;
                            x_angle = x - 0.5f;
                            angle.name = "top right";
                            yR = 0;
                        }
                        if (tile_map[i1 - 1][i2] == 1 && tile_map[i1][i2 - 1] == 1)// bottom right
                        {
                            z_angle = z + 0.5f;
                            x_angle = x - 0.5f;
                            if (x < 0)
                            {
                                x_angle = x - 0.5f;
                            }
                            if (z < 0)
                            {
                                z_angle = z + 0.5f;
                            }
                            angle.name = "bottom right";
                            yR = 90;
                        }
                        if (tile_map[i1 - 1][i2] == 1 && tile_map[i1][i2 + 1] == 1)// bottom left 
                        {
                            z_angle = z + 0.5f;
                            x_angle = x + 0.5f;
                            if (x < 0)
                            {
                                x_angle = x + 0.5f;
                            }
                            if (z < 0)
                            {
                                z_angle = z + 0.5f;
                            }
                            angle.name = "bottom left ";
                            yR = 180;
                        }
                        if (tile_map[i1 + 1][i2] == 1 && tile_map[i1][i2 + 1] == 1)// top left
                        {
                            z_angle = z - 0.5f;
                            x_angle = x + 0.5f;
                            if (z < 0)
                            {
                                z_angle = z - 0.5f;
                            }

                            angle.name = "top left";
                            yR = 270;
                        }

                        angle.transform.rotation = Quaternion.Euler(0, yR, 0);

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
    int GetTAngleType(int index1, int index2)
    {
        if (index2 > 0 && index1 < tile_map.Length - 1 && index2 < tile_map[index1].Length - 1)
            if ((tile_map[index1][index2 - 1] == 1 && tile_map[index1][index2 + 1] == 1) && (tile_map[index1 + 1][index2] == 1))// downwards
            {
                return 1;
            }
        if (index1 > 0 && index2 > 0 && index2 < tile_map[index1].Length - 1)
            if ((tile_map[index1][index2 - 1] == 1 && tile_map[index1][index2 + 1] == 1) && (tile_map[index1 - 1][index2] == 1))// upwards
            {
                return 2;
            }
        if (index1 > 0 && index1 < tile_map.Length - 1 && index2 < tile_map[index1].Length - 1)
            if ((tile_map[index1 - 1][index2] == 1 && tile_map[index1 + 1][index2] == 1) && (tile_map[index1][index2 + 1] == 1))// right
            {
                return 3;
            }
        if (index1 > 0 && index1 < tile_map.Length - 1 && index2 > 0 && index2 > 0)
            if ((tile_map[index1 - 1][index2] == 1 && tile_map[index1 + 1][index2] == 1) && (tile_map[index1][index2 - 1] == 1))// left
            {
                return 4;
            }
        return -1;
    }
    bool IsXAngle(int index1, int index2)
    {
        if (index1 > 0 && index2 > 0 && index1 < tile_map.Length - 1 && index2 < tile_map[index1].Length - 1)
            if (tile_map[index1 - 1][index2] == 1 && tile_map[index1 + 1][index2] == 1 && tile_map[index1][index2 - 1] == 1 && tile_map[index1][index2 + 1] == 1)
            {
                return true;
            }
        return false;
    }

    void Update()
    {

    }
}
