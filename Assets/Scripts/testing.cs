using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    public Vector3 dimension1;
    public Vector3 dimension2;
    int currentDimension;
    Vector3 currenDimensionOffset;
    public Transform player;

    void Start()
    {
        currentDimension = 1;
    }
    void Update()
    {
        switch (currentDimension)
        {
            case 1:
                currenDimensionOffset = dimension1;
                break;
            case 2:
                currenDimensionOffset = dimension2;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentDimension != 1)
        {
            player.position = player.position - currenDimensionOffset + dimension1;
            currentDimension = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && currentDimension != 2)
        {
            player.position = player.position - currenDimensionOffset + dimension2;
            currentDimension = 2;
        }
    }
}
