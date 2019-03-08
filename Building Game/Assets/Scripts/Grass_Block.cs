using System;
using UnityEngine;

public class Grass_Block : MonoBehaviour
{
    public GameObject Grass_Block1;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public static Vector3 FindPlaceToPutBlock(int i, float xPosition, float yPosition, float zPosition)
    {
        Vector3 blockPosition;
        blockPosition = new Vector3(xPosition, yPosition, zPosition);
        for (int j = 0; j < Math.Sqrt(i); j++)
        {
            for (int k = 0; k < Math.Sqrt(i); k++)
            {
                if (!Physics.CheckSphere(blockPosition, (float)0.5))
                {
                    return blockPosition;
                }
                blockPosition.Set(blockPosition.x, blockPosition.y, blockPosition.z + 2);
            }
            xPosition = xPosition + 2;
            blockPosition.Set(xPosition, blockPosition.y, zPosition);
        }
        blockPosition.Set((float)0.0, (float)0.0, (float)0.0);
        return blockPosition;
    }

    public static Vector3 GetGrassBlock(GameObject highlightedBlock)
    {
        Vector3 blockCenter = highlightedBlock.transform.position;
        return blockCenter;
    }
}
