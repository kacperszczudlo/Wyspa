using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        // Rzucamy promieñ do przodu z pozycji kamery na odleg³oœæ 3 jednostek
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3))
        {
            if (hit.collider.gameObject.tag == "playerDoor")
            {
                // Wyœlij wiadomoœæ do obiektu drzwi, aby wywo³a³ swoj¹ funkcjê DoorCheck
                GameObject currentDoor = hit.collider.gameObject;
                currentDoor.SendMessage("DoorCheck");
            }
        }
    }
}