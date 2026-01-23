using UnityEngine;
using System.Collections;

public class PowerCell : MonoBehaviour
{
    public float rotationSpeed = 100.0f; // Prêdkoœæ obracania ogniwa energetycznego

    void Update()
    {
        // Obracanie obiektu powerCell wokó³ osi Y
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }

    void OnTriggerEnter(Collider col)
    {
        // Wykrywanie kolizji z graczem
        if (col.gameObject.tag == "Player")
        {
            // Wysy³anie wiadomoœci do skryptu Inventory gracza o podniesieniu ogniwa
            col.gameObject.SendMessage("CellPickup");
            // Usuwanie ogniwa energetycznego ze sceny
            Destroy(gameObject);
        }
    }
}