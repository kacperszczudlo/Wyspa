using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ThrowTrigger : MonoBehaviour
{
    // Dodano odwo³anie do celownika
    public RawImage crosshair;

    void OnTriggerEnter(Collider col) 
    {
        // Sprawdza, czy obiekt, który wszed³ do wyzwalacza, to Gracz
        if(col.gameObject.tag == "Player") 
        {
            // W³¹cza mo¿liwoœæ rzucania
            CoconutThrower.canThrow = true;
            // W³¹cza celownik
            crosshair.enabled = true;
        }
    }

    void OnTriggerExit(Collider col) 
    {
        // Sprawdza, czy obiekt, który opuœci³ wyzwalacz, to Gracz
        if(col.gameObject.tag == "Player") 
        {
            // Wy³¹cza mo¿liwoœæ rzucania
            CoconutThrower.canThrow = false;
            // Wy³¹cza celownik
            crosshair.enabled = false;
        }
    }
}