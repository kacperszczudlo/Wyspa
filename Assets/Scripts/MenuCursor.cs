using UnityEngine;

public class MenuCursor : MonoBehaviour
{
    void Start()
    {
        // Wymuszamy pojawienie siê kursora i jego odblokowanie
        // To naprawi problem po powrocie z gry, gdzie FPSController go blokuje.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}