using UnityEngine;
using System.Collections;

public class Matches : MonoBehaviour
{
    void OnTriggerEnter(Collider col) 
    {
        // Linia 8: Upewnij siê, ¿e u¿ywasz nawiasów OKR¥G£YCH ()
        if (col.gameObject.tag == "Player") 
        {
            // Linia 11: Zwyk³e wywo³anie metody z nawiasami OKR¥G£YMI ()
            col.gameObject.SendMessage("MatchPickup");
            // Linia 13: Zwyk³e wywo³anie metody z nawiasami OKR¥G£YMI ()
            Destroy(gameObject);
        }
    }
}