using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Wymagane do obs³ugi Text

public class TextHints : MonoBehaviour
{
    private float timer = 0.0f; // Licznik czasu do ukrywania tekstu

    // Funkcja odbiera wiadomoœæ tekstow¹ i w³¹cza komponent Text
    public void ShowHint(string message) 
    {
        Text guiText = GetComponent<Text>(); 
        guiText.text = message; // Ustaw treœæ wiadomoœci
        
        // W³¹cz komponent, jeœli jest wy³¹czony
        if (!guiText.enabled) 
        {
            guiText.enabled = true;
        }
        
        timer = 0.0f; // Zerujemy licznik czasu, aby tekst by³ widoczny przez pe³ny okres
    }

    void Update()
    {
        Text guiText = GetComponent<Text>(); 
        
        // Sprawdzanie, czy komponent jest w³¹czony
        if (guiText.enabled) 
        {
            timer += Time.deltaTime; // Zwiêkszanie licznika czasu
            
            // Ukryj tekst po 4 sekundach (lub d³u¿ej, jeœli klatka zosta³a pominiêta)
            if(timer >= 4)
            {
                guiText.enabled = false; // Wy³¹cz komponent Text
                timer = 0.0f;            // Zeruj licznik
            }
        }
    }
}