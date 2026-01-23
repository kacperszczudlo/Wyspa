using UnityEngine;
using System.Collections;

public class DoorManager : MonoBehaviour
{
    bool doorIsOpen = false;
    float doorTimer = 0.0f;

    public float doorOpenTime = 3.0f;
    public AudioClip doorOpenSound;
    public AudioClip doorShutSound;

    public BoxCollider doorCollider; // Referencja do Box Collidera drzwi

    void Start()
    {
        // Upewnij siê, ¿e collider jest aktywny na pocz¹tku (drzwi zamkniête)
        if (doorCollider != null)
        {
            doorCollider.enabled = true;
        }
    }

    // Ta funkcja bêdzie wywo³ywana przez inny skrypt (np. TriggerZone)
    public void DoorCheck()
    {
        if (!doorIsOpen)
        {
            Door(doorOpenSound, true, "dooropen", gameObject);
        }
    }

    void Door(AudioClip sound, bool isOpen, string animationName, GameObject doorObject)
    {
        doorIsOpen = isOpen;
        doorTimer = 0.0f;

        AudioSource audioSource = doorObject.GetComponent<AudioSource>();
        if (audioSource != null && sound != null)
        {
            audioSource.PlayOneShot(sound);
        }

        Animation animComponent = doorObject.transform.parent.GetComponent<Animation>();
        if (animComponent != null)
        {
            animComponent.Play(animationName);
        }

        // ZARZ¥DZANIE COLLIDEREM:
        // Wy³¹cz collider, gdy drzwi siê otwieraj¹ (isOpen jest true)
        // W³¹cz collider, gdy drzwi siê zamykaj¹ (isOpen jest false)
        if (doorCollider != null)
        {
            doorCollider.enabled = !isOpen; 
        }
    }

    void Update()
    {
        if (doorIsOpen)
        {
            doorTimer += Time.deltaTime;
            if (doorTimer > doorOpenTime)
            {
                Door(doorShutSound, false, "doorshut", gameObject);
            }
        }
    }
}