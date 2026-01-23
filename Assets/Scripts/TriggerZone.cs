using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class TriggerZone : MonoBehaviour
{
    // Zmienne publiczne, które muszą zostać przypisane w Inspectorze
    public AudioClip lockedSound;    
    public Light doorLight;          
    public Text textHints;          

    void OnTriggerEnter(Collider col)
    {
        // Sprawdzamy, czy kolidujący obiekt to Gracz
        if (col.gameObject.tag == "Player")
        {
            // Otwieranie drzwi: Wymagane 4 ogniwa
            if (Inventory.charge == 4) 
            {
                // WYSYŁANIE WIADOMOŚCI DO DRZWI
                transform.parent.Find("door").SendMessage("DoorCheck");
                
                // Usuń HUD i zmień kolor światła, jeśli to pierwsze wejście
                if (GameObject.Find("PowerGUI")) 
                {
                    Destroy(GameObject.Find("PowerGUI")); 
                    doorLight.color = Color.green;         
                }
            }
            // Jeśli minigra została wygrana, ale gracz ma tylko 3 ogniwa (np. jeszcze nie zebrał 4.)
            else if (CoconutWin.haveWon)
            {
                // Nie wyświetlaj wskazówek o mocy, ponieważ ogniwo jest teraz dostępne.
                // Po prostu odtwarzamy dźwięk zamknięcia, jeśli gracz podchodzi do drzwi, ale ma < 4 ogniw.
                transform.parent.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound); 
            }
            // Wskazówka 2: Zebrano 1-3 ogniwa (tylko jeśli gra nie została jeszcze wygrana)
            else if (Inventory.charge > 0 && Inventory.charge < 4) 
            {
                textHints.SendMessage("ShowHint", "Drzwi ani drgną... \n pewnie potrzebują więcej mocy..."); 
                // Odtwarzanie dźwięku zamknięcia
                transform.parent.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound); 
            }
            // Wskazówka 3: Zebrano 0 ogniw
            else // Inventory.charge == 0
            {
                // Odtwarzanie dźwięku zamknięcia
                transform.parent.Find("door").GetComponent<AudioSource>().PlayOneShot(lockedSound); 
                
                // Włącz HUD (wywołanie funkcji w Inventory)
                col.gameObject.SendMessage("HUDon"); 
                
                textHints.SendMessage("ShowHint", "Te drzwi wyglądają na zamknięte, \n być może generator wymaga \n odpowiedniego zasilania..."); 
            }
        }
    }
    
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Resetuje wskazówkę tekstową przy wyjściu ze strefy
            textHints.SendMessage("ShowHint", ""); 
        }
    }
}