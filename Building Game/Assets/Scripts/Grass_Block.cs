using UnityEngine;

public class Grass_Block : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public static Vector3 findPlaceToPutBlock(Grass_Block Grass, bool xFirst, float xPosition, float yPosition, float zPosition)
    {
        Vector3 blockPosition;
        blockPosition = new Vector3(xPosition, yPosition, zPosition);
        if (!Physics.CheckSphere(blockPosition, (float)0.1))
        {
            return blockPosition;
        }
        else
        {
            if (xFirst == true)
            {
                float firstVar = xPosition;
                float secondVar = zPosition;
                firstVar = firstVar + 1;
                while (true)
                {
                    blockPosition = new Vector3(firstVar, yPosition, secondVar);
                    if (!Physics.CheckSphere(blockPosition, (float)0.1))
                    {
                        return blockPosition;
                    }
                    secondVar = secondVar + 1;
                    firstVar = firstVar - 1;
                    blockPosition = new Vector3(firstVar, yPosition, secondVar);
                    if (!Physics.CheckSphere(blockPosition, (float)0.1))
                    {
                        Player_Code.Changebool(xFirst);
                        secondVar = secondVar - 1;
                        return blockPosition;
                    }
                }
            }
            else
            {
                float firstVar = zPosition;
                float secondVar = xPosition;
                firstVar = firstVar + 1;
                while (true)
                {
                    blockPosition = new Vector3(firstVar, yPosition, secondVar);
                    if (!Physics.CheckSphere(blockPosition, (float)0.1))
                    {
                        return blockPosition;
                    }
                    secondVar = secondVar + 1;
                    firstVar = firstVar - 1;
                    blockPosition = new Vector3(firstVar, yPosition, secondVar);
                    if (!Physics.CheckSphere(blockPosition, (float)0.1))
                    {
                        firstVar = 0;
                        secondVar = 0;
                        while (!Physics.CheckSphere(blockPosition, (float)0.1))
                        {
                            firstVar = firstVar + 1;
                        }
                        blockPosition = new Vector3(firstVar, yPosition, secondVar);
                    }
                }
            }
        }
    }
}  
