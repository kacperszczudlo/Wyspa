using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MainMenuBtns : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string levelToLoad;
    public Sprite normalTexture;
    public Sprite rollOverTexture;
    public AudioClip beep;
    public bool quitButton = false;

    // Funkcja wywo³ywana po najechaniu myszk¹
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = rollOverTexture;
    }

    // Funkcja wywo³ywana po zjechaniu myszk¹
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().sprite = normalTexture;
    }

    // Funkcja wywo³ywana po klikniêciu (puszczeniu przycisku)
    public void OnPointerUp(PointerEventData eventData)
    {
        if (quitButton)
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
        else
        {
            GetComponent<AudioSource>().PlayOneShot(beep);
            SceneManager.LoadScene(levelToLoad);
        }
    }

    // Pusta funkcja wymagana przez interfejs
    public void OnPointerDown(PointerEventData eventData)
    {
    }
}