using UnityEngine;
using UnityEngine.AI;

public class Falling : StateMachineBehaviour
{
    // Funkcja wywo³ywana w momencie wejœcia w stan upadku
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Pobieramy agenta nawigacji
        NavMeshAgent agent = animator.GetComponent<NavMeshAgent>();

        // POPRAWKA: Sprawdzamy nie tylko czy agent istnieje, 
        // ale te¿ czy jest w³¹czony i czy stoi na siatce NavMesh.
        // Jeœli wilk "nie ¿yje" (agent wy³¹czony), nie próbujemy go zatrzymywaæ.
        if (agent != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            agent.ResetPath();
        }
    }
}