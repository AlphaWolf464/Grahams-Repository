using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Block : MonoBehaviour
{
    bool IsConnectedToGround;
    static Vector3 positionofblock;
    // Start is called before the first frame update
    void Start()
    {
        IsConnectedToGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 zerozerozero = new Vector3((float)0.0, (float)0.0, (float)0.0);
        if (Physics.CheckSphere(positionofblock, (float)0.01) && !(positionofblock == zerozerozero))
        {
            Vector3 RightPosition = new Vector3((float)(positionofblock.x - 2.1), positionofblock.y, positionofblock.z);
            Vector3 LeftPosition = new Vector3((float)(positionofblock.x + 2.1), positionofblock.y, positionofblock.z);
            Vector3 AbovePosition = new Vector3(positionofblock.x, (float)(positionofblock.y + 2.1), positionofblock.z);
            Vector3 BelowPosition = new Vector3(positionofblock.x, (float)(positionofblock.y - 2.1), positionofblock.z);
            Vector3 BackPosition = new Vector3(positionofblock.x, positionofblock.y, (float)(positionofblock.z + 2.1));
            Vector3 FrontPosition = new Vector3(positionofblock.x, positionofblock.y, (float)(positionofblock.z - 2.1));
            if (Physics.CheckSphere(RightPosition, (float)0.1))
            {
                GameObject RightBlock = Physics.OverlapSphere(RightPosition, (float)0.1)[0].gameObject;
                if (RightBlock.tag.Equals("Buildable") && RightBlock.GetComponent<Wood_Block>().IsConnectedToGround == true)
                {
                    IsConnectedToGround = true;
                }
            }
            else
            {
                if (Physics.CheckSphere(LeftPosition, (float)0.1))
                {
                    GameObject LeftBlock = Physics.OverlapSphere(LeftPosition, (float)0.1)[0].gameObject;
                    if (LeftBlock.tag.Equals("Buildable") && LeftBlock.GetComponent<Wood_Block>().IsConnectedToGround == true)
                    {
                        IsConnectedToGround = true;
                    }
                }
                else
                {
                    if (Physics.CheckSphere(AbovePosition, (float)0.1))
                    {
                        GameObject AboveBlock = Physics.OverlapSphere(AbovePosition, (float)0.1)[0].gameObject;
                        if ((AboveBlock.tag == "Block") || (AboveBlock.tag.Equals("Buildable") && AboveBlock.GetComponent<Wood_Block>().IsConnectedToGround == true))
                        {
                            IsConnectedToGround = true;
                        }
                    }
                    else
                    {
                        if (Physics.CheckSphere(BelowPosition, (float)0.1))
                        {
                            GameObject BelowBlock = Physics.OverlapSphere(BelowPosition, (float)0.1)[0].gameObject;
                            if ((BelowBlock.tag == "Block") || (BelowBlock.tag.Equals("Buildable") && BelowBlock.GetComponent<Wood_Block>().IsConnectedToGround == true))
                            {
                                IsConnectedToGround = true;
                            }
                        }
                        else
                        {
                            if (Physics.CheckSphere(BackPosition, (float)0.1))
                            {
                                GameObject BackBlock = Physics.OverlapSphere(BackPosition, (float)0.1)[0].gameObject;
                                if (BackBlock.tag.Equals("Buildable") && BackBlock.GetComponent<Wood_Block>().IsConnectedToGround == true)
                                {
                                    IsConnectedToGround = true;
                                }
                            }
                            else
                            {
                                if (Physics.CheckSphere(FrontPosition, (float)0.1))
                                {
                                    GameObject FrontBlock = Physics.OverlapSphere(FrontPosition, (float)0.1)[0].gameObject;
                                    if (FrontBlock.tag.Equals("Buildable") && FrontBlock.GetComponent<Wood_Block>().IsConnectedToGround == true)
                                    {
                                        IsConnectedToGround = true;
                                    }
                                }
                                else
                                {
                                    IsConnectedToGround = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        if (IsConnectedToGround == false && Physics.CheckSphere(positionofblock, (float)0.1))
        {
            Destroy(Physics.OverlapSphere(positionofblock, (float)0.1)[0].gameObject);
        }
    }

    public static void CreateBlock(Vector3 BlockCoords)
    {
        GameObject Wood_Block1 = GameObject.FindGameObjectWithTag("Buildable");
        positionofblock = BlockCoords;
        GameObject block = Instantiate(Wood_Block1, BlockCoords, Quaternion.identity);
    }

    public bool GetConnected()
    {
        return IsConnectedToGround;
    }
}
