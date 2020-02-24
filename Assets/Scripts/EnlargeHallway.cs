using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeHallway : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, 1, 1 + Mathf.Abs(player.transform.position.z / 10));
    }
}
