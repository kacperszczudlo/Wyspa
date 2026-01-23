using UnityEngine;
using System.Collections;

// Dodaje komponent AudioSource, jeśli nie jest obecny
[RequireComponent (typeof (AudioSource))] 

public class CoconutThrower : MonoBehaviour
{
    // Zmienna statyczna pozwalająca na rzucanie kokosami
    public static bool canThrow = false; 

    // Zmienne publiczne do przypisania w Inspectorze
    public AudioClip throwSound;
    public Rigidbody coconutPrefab; 
    public float throwSpeed = 30.0f; // <--- Upewnij się, że ta linia kończy się średnikiem (;)

    void Update()
    {
        // Sprawdza, czy naciśnięto i PUSZCZONO przycisk "Fire1" ORAZ czy można rzucać
        if (Input.GetButtonUp("Fire1") && canThrow) 
        {
            // Odtwarzanie dźwięku rzutu
            GetComponent<AudioSource>().PlayOneShot(throwSound);

            // Konkretyzacja (tworzenie) nowego orzecha kokosowego
            Rigidbody newCoconut = Instantiate(coconutPrefab, transform.position, transform.rotation) as Rigidbody;

            // Zmiana nazwy instancji
            newCoconut.name = "coconut";

            // Nadanie prędkości nowemu orzechowi kokosowemu
            newCoconut.linearVelocity = transform.forward * throwSpeed;
            
            // Opcjonalne ignorowanie kolizji (zostało zakomentowane)
            // Physics.IgnoreCollision(transform.root.GetComponent<Collider>(),
            // newCoconut.GetComponent<Collider>(), true); 
        }
    }
}