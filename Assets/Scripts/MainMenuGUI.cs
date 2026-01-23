using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenuGUI : MonoBehaviour
{
    // Zmienne publiczne do przypisania w Inspectorze Unity
    public AudioClip beep;
    public GUISkin menuSkin;
    public Rect menuArea;
    public Texture gameLogo;
    
    // Opcje skalowania menu
    public bool adjustPosition;
    public bool adjustSize;

    // Nazwa sceny, która ma siê wczytaæ po klikniêciu Play
    public string gameLevelName = "Island"; 

    // Zmienne prostok¹tów dla przycisków i instrukcji
    Rect playBtnRect;
    Rect instructionsBtnRect;
    Rect quitBtnRect;
    public Rect instructionsRect;

    // Wymiary bazowe przycisków
    float buttonWidth = 200;
    float buttonHeight = 40;
    float space = 20;

    // Wspó³czynniki skalowania (domyœlnie 1, czyli brak zmian)
    float coefX = 1.0f;
    float coefY = 1.0f;

    // Zmienna przechowuj¹ca aktualnie wyœwietlan¹ stronê menu
    string menuPage = "main";

    void Start()
    {
        // 1. Obliczanie wspó³czynników skali dla ró¿nych rozdzielczoœci
        if (adjustSize) 
        {
            coefX = Screen.width / 1024.0f;
            coefY = Screen.height / 768.0f;
            
            // Skalowanie obszaru ca³ej grupy menu
            menuArea.width *= coefX;
            menuArea.height *= coefY;
        }

        // 2. Korekta pozycji menu, aby pozosta³o wyœrodkowane/proporcjonalne
        if (adjustPosition) 
        {
            float w_2 = menuArea.width * 0.5f;
            float h_2 = menuArea.height * 0.5f;
            
            menuArea.x = (menuArea.x + w_2) * (Screen.width / 1024.0f) - w_2;
            menuArea.y = (menuArea.y + h_2) * (Screen.height / 768.0f) - h_2;
        }

        // 3. Ustawienie pozycji przycisków z uwzglêdnieniem obliczonej skali
        playBtnRect = new Rect(50 * coefX, 250 * coefY, buttonWidth * coefX, buttonHeight * coefY);
        
        instructionsBtnRect = new Rect(50 * coefX, (250 + buttonHeight + space) * coefY, 
                                       buttonWidth * coefX, buttonHeight * coefY);
        
        quitBtnRect = new Rect(50 * coefX, (250 + (buttonHeight + space) * 2) * coefY, 
                               buttonWidth * coefX, buttonHeight * coefY);

        // 4. Ustawienie obszaru dla etykiety z tekstem instrukcji
        instructionsRect = new Rect(0, 250 * coefY, 300 * coefX, buttonHeight * 3 * coefY);
    }

    void OnGUI()
    {
        // Zastosowanie Twojego GUISkin (skórki menu)
        GUI.skin = menuSkin;

        // Rozpoczêcie grupy - wszystkie wspó³rzêdne wewn¹trz s¹ liczone od (0,0) tej grupy
        GUI.BeginGroup(menuArea);

        // Rysowanie tekstury logo gry
        GUI.DrawTexture(new Rect(0, 0, 300 * coefX, 211 * coefY), gameLogo);

        // Wyœwietlanie strony G£ÓWNEJ
        if (menuPage == "main") 
        {
            if (GUI.Button(playBtnRect, "Play")) 
            {
                StartCoroutine("ButtonAction", gameLevelName);
            }

            if (GUI.Button(instructionsBtnRect, "Instructions")) 
            {
                GetComponent<AudioSource>().PlayOneShot(beep);
                menuPage = "instructions"; // Zmiana widoku na instrukcje
            }

            if (GUI.Button(quitBtnRect, "Quit")) 
            {
                StartCoroutine("ButtonAction", "quit");
            }
        }
        // Wyœwietlanie strony INSTRUKCJI
        else if (menuPage == "instructions") 
        {
            GUI.Label(instructionsRect, 
                "Obudzi³eœ siê na tajemniczej wyspie...\nZnajdŸ sposób na zwrócenie na siebie uwagi,\ninaczej zostaniesz tu na zawsze!");

            // Przycisk powrotu - umieszczony w tym samym miejscu co Quit
            if (GUI.Button(quitBtnRect, "Back")) 
            {
                GetComponent<AudioSource>().PlayOneShot(beep);
                menuPage = "main"; // Powrót do strony g³ównej
            }
        }

        // Zamkniêcie grupy
        GUI.EndGroup();
    }

    // Korutyna obs³uguj¹ca dŸwiêk i akcjê po klikniêciu
    IEnumerator ButtonAction(string levelName) 
    {
        // Odtwórz dŸwiêk
        GetComponent<AudioSource>().PlayOneShot(beep);
        
        // Poczekaj chwilê, aby gracz us³ysza³ dŸwiêk przed zmian¹ sceny
        yield return new WaitForSeconds(0.35f);

        if (levelName != "quit") 
        {
            SceneManager.LoadScene(levelName);
        }
        else 
        {
            // Zamkniêcie aplikacji lub zatrzymanie edytora
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}