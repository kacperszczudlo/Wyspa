using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Wymagane do obs³ugi RawImage i Text

public class Inventory : MonoBehaviour
{
    public static int charge = 0; 
    public AudioClip collectSound; 

    // HUD dla ogniw
    public Texture2D[] hudCharge;
    public RawImage chargeHudGUI; // Odwo³anie do obiektu PowerGUI (RawImage)

    // Generator
    public Texture2D[] meterCharge;
    public Renderer meter; // Odwo³anie do komponentu Renderer (np. z chargeMeter)

    // Zapa³ki
    bool haveMatches = false; // Zmienna logiczna do zapamiêtania, czy zapa³ki zosta³y podniesione
    public RawImage matchHudGUI; // Odwo³anie do obiektu MatchGUI (RawImage)
    public Text textHints;      // Odwo³anie do obiektu TextHintGUI (Text)
    bool fireIsLit = false;    // Zmienna sprawdzaj¹ca, czy ognisko jest rozpalone

    void Start()
    {
        charge = 0;
    }

    void CellPickup()
    {
        // 1. W³¹cz HUD, jeœli jest wy³¹czony (obs³uguje przypadek podniesienia ogniwa, zanim gracz podszed³ do drzwi)
        HUDon(); 

        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        charge++;

        // 2. Zmieñ teksturê HUD na podstawie nowej wartoœci charge
        chargeHudGUI.texture = hudCharge[charge];

        // 3. Zmieñ teksturê generatora na podstawie nowej wartoœci charge
        meter.material.mainTexture = meterCharge[charge];
    }

    // Nowa funkcja wywo³ywana przez SendMessage (np. ze skryptu TriggerZone)
    public void HUDon()
    {
        // Sprawdza, czy RawImage jest wy³¹czony
        if(!chargeHudGUI.enabled) 
        {
            // W³¹cza RawImage
            chargeHudGUI.enabled = true;
        }
    }

    // Funkcja wywo³ywana przez skrypt Matches
    void MatchPickup() 
    {
        haveMatches = true;
        AudioSource.PlayClipAtPoint(collectSound, transform.position);
        matchHudGUI.enabled = true; // Linia 58/59 (Krytyczna linia, musi byæ zakoñczona œrednikiem!)
    }

    // Wykrywanie kolizji z fizycznym zderzaczem (u¿ywane przez Character Controller)
    void OnControllerColliderHit(ControllerColliderHit col) 
    {
        // Sprawdzenie, czy obiekt kolizji to "campfire"
        if (col.gameObject.name == "campfire") 
        {
            // Poprawnie zagnie¿d¿ona instrukcja if/else
            if(haveMatches) // Linia 73 (Musz¹ byæ poprawne klamry otwieraj¹ce i zamykaj¹ce blok 'if')
            {
                LightFire(col.gameObject);
            } 
            else if(!fireIsLit) 
            {
                // Wyœwietlenie wskazówki
                textHints.SendMessage("ShowHint", "Móg³bym rozpaliæ ognisko do wezwania pomocy. \n Tylko czym...");
            }
        }
    }

    // Funkcja do rozpalania ogniska
    void LightFire(GameObject campfire) 
    {
        // Pobranie wszystkich komponentów ParticleSystem (FireSystem i SmokeSystem) z potomków
        ParticleSystem[] fireEmitters = campfire.GetComponentsInChildren<ParticleSystem>();

        foreach(ParticleSystem emitter in fireEmitters) 
        {
            emitter.Play();
        }

        // Uruchomienie efektu dŸwiêkowego ogniska
        campfire.GetComponent<AudioSource>().Play();

        // Informowanie o u¿yciu inwentarza (Linia 97 - Krytyczna linia, musi byæ zakoñczona œrednikiem!)
        matchHudGUI.enabled = false;
        haveMatches = false;         // Zapa³ki zosta³y u¿yte
        fireIsLit = true;            // Ognisko p³onie
    }
}