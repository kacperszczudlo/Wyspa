using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class CoconutThrower : MonoBehaviour
{
    public static bool canThrow = true;
    public AudioClip throwSound;
    public Rigidbody coconutPrefab;
    public float throwSpeed = 30.0f;

    void Update()
    {
        if (Input.GetButtonUp("Fire1") && canThrow)
        {
            if (coconutPrefab != null)
            {
                // 1. Znajdź Główną Kamerę w scenie (Twoje "oczy")
                Transform cameraTransform = Camera.main.transform;

                if (cameraTransform == null)
                {
                    Debug.LogError("Nie znaleziono kamery oznaczonej tagiem 'MainCamera'!");
                    return;
                }

                // 2. Dźwięk
                AudioSource audio = GetComponent<AudioSource>();
                if(audio != null && throwSound != null) 
                    audio.PlayOneShot(throwSound);

                // 3. POZYCJA STARTOWA:
                // Bierzemy pozycję kamery i dodajemy 1.5 metra w przód (transform.forward)
                // Dzięki temu kokos pojawi się przed twarzą, a nie w stopach.
                Vector3 spawnPos = cameraTransform.position + (cameraTransform.forward * 1.5f);
                
                // 4. Stworzenie obiektu
                Rigidbody newCoconut = Instantiate(coconutPrefab, spawnPos, cameraTransform.rotation) as Rigidbody;
                newCoconut.name = "coconut";

                // 5. Fizyka (dla Unity 2022 i nowszych)
                // Ważne: Rzucamy w kierunku, w który patrzy kamera (cameraTransform.forward)
                newCoconut.linearVelocity = cameraTransform.forward * throwSpeed;

                // 6. Ignorowanie kolizji z graczem (żeby nie odbił się od nas)
                Collider playerCollider = transform.root.GetComponent<Collider>();
                if (playerCollider != null)
                {
                    Physics.IgnoreCollision(newCoconut.GetComponent<Collider>(), playerCollider, true);
                }
            }
        }
    }
}