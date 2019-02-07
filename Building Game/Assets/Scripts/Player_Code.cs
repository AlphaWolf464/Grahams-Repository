using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Code : MonoBehaviour
{
    public bool xFirst;
    private void Start()
    {
        Grass_Block Grass_Block1 = new Grass_Block();
        for (int i = 0; i < 9; i++)
        {
            Vector3 blockxyz = Grass_Block.findPlaceToPutBlock(Grass_Block1, xFirst, (float)0.0, (float)0.0, (float)0.0);
            Instantiate(Grass_Block1, blockxyz, Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5))
            {
                Vector3 end = ray.origin + (ray.direction * hit.distance);
                Vector3 blockCenter = gameObject.transform.position;
                if ((Mathf.Abs(end.x - blockCenter.x) > Mathf.Abs(end.y - blockCenter.y)) && (Mathf.Abs(end.x - blockCenter.x) > Mathf.Abs(end.z - blockCenter.z)))
                {
                    if (end.x > blockCenter.x)
                    {
                        Vector3 block_Coords = new Vector3(blockCenter.x + 1, blockCenter.y, blockCenter.z);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                    if (end.x < blockCenter.x)
                    {
                        Vector3 block_Coords = new Vector3(blockCenter.x - 1, blockCenter.y, blockCenter.z);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                }
                if ((Mathf.Abs(end.y - blockCenter.y) > Mathf.Abs(end.x - blockCenter.x)) && (Mathf.Abs(end.y - blockCenter.y) > Mathf.Abs(end.z - blockCenter.z)))
                {
                    if (end.y > blockCenter.y)
                    {
                        Vector3 block_Coords = new Vector3(blockCenter.x, blockCenter.y + 1, blockCenter.z);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                    if (end.y < blockCenter.y)
                    {
                        Vector3 block_Coords = new Vector3(blockCenter.x, blockCenter.y - 1, blockCenter.z);
                        Wood_Block.CreateBlock(block_Coords);
                    }

                }
                if ((Mathf.Abs(end.z - blockCenter.z) > Mathf.Abs(end.x - blockCenter.x)) && (Mathf.Abs(end.z - blockCenter.z) > Mathf.Abs(end.x - blockCenter.x)))
                {
                    if (end.z > blockCenter.z)
                    {
                        Vector3 block_Coords = new Vector3(blockCenter.x, blockCenter.y, blockCenter.z + 1);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                    if (end.z < blockCenter.z)
                    {
                        Vector3 block_Coords = new Vector3(blockCenter.x, blockCenter.y, blockCenter.z - 1);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                }
            }
        }
    }

    public static void Changebool(bool boolean)
    {
        if (boolean == true)
        {
            boolean = false;
        }
        else
        {
            boolean = true;
        }
    }

    private void FixedUpdate()
    {

    }
}
