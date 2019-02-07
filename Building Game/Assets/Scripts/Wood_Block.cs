using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_Block : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void CreateBlock(Vector3 BlockCoords)
    {
        Wood_Block block = new Wood_Block();
        block = hit.transform.BlockCoords;
        Instantiate(block, BlockCoords, Quaternion.identity);
    }
}
