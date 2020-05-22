using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNumber : MonoBehaviour
{
    public int roomNumber;
    public static int roomNumberEnemy;
    public static int roomnumberPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            roomNumberEnemy = roomNumber;
        }
        if (other.gameObject.tag == "Player")
        {
            roomnumberPlayer = roomNumber;
        }
    }
}
