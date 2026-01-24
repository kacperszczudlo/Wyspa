using UnityEngine;
using UnityEngine.AI; // Wa¿ne: to musi byæ dodane

public class Following : StateMachineBehaviour
{
    private UnityEngine.AI.NavMeshAgent _nav;
    private Transform _player;

    // Funkcja wywo³ywana przy wejœciu w stan (rozpoczêcie biegu)
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Pobieramy gracza
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            _player = playerObj.transform;
        }

        // Pobieramy Agenta z wilka
        _nav = animator.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Funkcja wywo³ywana co klatkê
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // SPRAWDZAMY CZY WSZYSTKO JEST OK, ¯EBY UNIKN¥Æ B£ÊDU:
        // 1. Czy mamy nawigacjê (_nav != null)
        // 2. Czy mamy cel (_player != null)
        // 3. Czy Agent jest aktywny i stoi na siatce (isActiveAndEnabled && isOnNavMesh)
        if (_nav != null && _player != null && _nav.isActiveAndEnabled && _nav.isOnNavMesh)
        {
            _nav.SetDestination(_player.position);
        }
    }
}