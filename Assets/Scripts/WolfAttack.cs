using UnityEngine;
using UnityEngine.SceneManagement;

public class WolfAttack : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Zadzia³a tylko, gdy ten konkretny collider (na g³owie) dotknie gracza
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Game Over - Wilk ugryz³ gracza!");
            
            // Odblokowanie myszki
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            SceneManager.LoadScene("Menu");
        }
    }
}