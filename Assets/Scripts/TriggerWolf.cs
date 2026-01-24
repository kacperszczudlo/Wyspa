using UnityEngine;
using System.Collections;

public class TriggerWolf : MonoBehaviour
{
    private Animator _animator;
    private GameObject _player;

    void Start()
    {
        // ZnajdŸ gracza po tagu
        _player = GameObject.FindGameObjectWithTag("Player");
        // Pobierz animatora z wilka
        _animator = GetComponent<Animator>();
    }

    // Gdy gracz wejdzie w strefê (zbli¿y siê)
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("isNearPlayer", true);
        }
    }

    // Gdy gracz wyjdzie ze strefy (oddali siê)
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player)
        {
            _animator.SetBool("isNearPlayer", false);
        }
    }
}