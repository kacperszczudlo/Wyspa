using UnityEngine;
using System.Collections;

public class TidyObject : MonoBehaviour
{
    public float removeTime = 3.0f; // Czas (w sekundach), po którym obiekt zostanie usuniêty

    void Start () 
    {
        // Wywo³uje funkcjê Destroy() z opóŸnieniem
        Destroy(gameObject, removeTime);
    }
}