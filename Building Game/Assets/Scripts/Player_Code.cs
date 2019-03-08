using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Code : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject Block;
    public GameObject Axe;
    public string ItemInHand;

    private void Start()
    {
        ItemInHand = "Block";
        Axe.SetActive(false);
        GameObject Grass_Block1 = GameObject.FindGameObjectWithTag("Block");
        var area = 144;
        for (int i = 0; i < area; i++)
        {
            Vector3 blockxyz = Grass_Block.FindPlaceToPutBlock(i, (float)0.0, (float)0.0, (float)0.0);
            GameObject block = Instantiate(Grass_Block1, blockxyz, Quaternion.identity);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ItemInHand = "Block";
            Block.SetActive(true);
            Axe.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            ItemInHand = "Axe";
            Axe.SetActive(true);
            Block.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0) && ItemInHand.Equals("Axe"))
        {
            Ray rayleftclick = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayleftclick, out hit, 10))
            {
                Vector3 endleftclick = rayleftclick.origin + (rayleftclick.direction * hit.distance);
                GameObject TargetBlock = new GameObject();
                TargetBlock = Physics.OverlapSphere(endleftclick, (float)0.1)[0].gameObject;
                if (TargetBlock.tag.Equals("Buildable"))
                {
                    Destroy(TargetBlock);
                }
            }
        }

        if (Input.GetMouseButtonDown(1) && ItemInHand.Equals("Block"))
        {
            Ray rayrightclick = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(rayrightclick, out hit, 10))
            {
                Vector3 endrightclick = rayrightclick.origin + (rayrightclick.direction * hit.distance);
                GameObject HighlightedBlock = new GameObject();
                HighlightedBlock = Physics.OverlapSphere(endrightclick, (float)0.1)[0].gameObject;
                Vector3 blockCenter = Grass_Block.GetGrassBlock(HighlightedBlock);
                if ((Mathf.Abs(endrightclick.x - blockCenter.x) > Mathf.Abs(endrightclick.y - blockCenter.y)) && (Mathf.Abs(endrightclick.x - blockCenter.x) > Mathf.Abs(endrightclick.z - blockCenter.z)))
                {
                    if (endrightclick.x > blockCenter.x)
                    {
                        Vector3 block_Coords = new Vector3(((int)blockCenter.x / 2 * 2) + 2, (int)blockCenter.y / 2 * 2, (int)blockCenter.z / 2 * 2);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                    if (endrightclick.x < blockCenter.x)
                    {
                        Vector3 block_Coords = new Vector3(((int)blockCenter.x / 2 * 2) - 2, (int)blockCenter.y / 2 * 2, (int)blockCenter.z / 2 * 2);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                }
                if ((Mathf.Abs(endrightclick.y - blockCenter.y) > Mathf.Abs(endrightclick.x - blockCenter.x)) && (Mathf.Abs(endrightclick.y - blockCenter.y) > Mathf.Abs(endrightclick.z - blockCenter.z)))
                {
                    if (endrightclick.y > blockCenter.y)
                    {
                        Vector3 block_Coords = new Vector3((int)blockCenter.x / 2 * 2, ((int)blockCenter.y / 2 * 2) + 2, (int)blockCenter.z / 2 * 2);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                    if (endrightclick.y < blockCenter.y)
                    {
                        Vector3 block_Coords = new Vector3((int)blockCenter.x / 2 * 2, ((int)blockCenter.y / 2 * 2) - 2, (int)blockCenter.z / 2 * 2);
                        Wood_Block.CreateBlock(block_Coords);
                    }

                }
                if ((Mathf.Abs(endrightclick.z - blockCenter.z) > Mathf.Abs(endrightclick.x - blockCenter.x)) && (Mathf.Abs(endrightclick.z - blockCenter.z) > Mathf.Abs(endrightclick.x - blockCenter.x)))
                {
                    if (endrightclick.z > blockCenter.z)
                    {
                        Vector3 block_Coords = new Vector3((int)blockCenter.x / 2 * 2, (int)blockCenter.y / 2 * 2, ((int)blockCenter.z / 2 * 2) + 2);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                    if (endrightclick.z < blockCenter.z)
                    {
                        Vector3 block_Coords = new Vector3((int)blockCenter.x / 2 * 2, (int)blockCenter.y / 2 * 2, ((int)blockCenter.z / 2 * 2) - 2);
                        Wood_Block.CreateBlock(block_Coords);
                    }
                }
            }
        }
    }
}
