using UnityEngine;
using UnityEngine.AI;

public class Running : StateMachineBehaviour
{
    // Atrybuty z instrukcji
    private NavMeshAgent _nav;
    private float latestDirectionChangeTime;
    public float directionChangeTime = 5f;
    public float WolfVelocity = 50f;

    // Metoda wywo³ywana przy wejœciu w stan Running
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // 1. Zerowanie parametru nextState
        animator.SetInteger("nextState", 0);

        // 2. Inicjacja agenta i reset œcie¿ki
        _nav = animator.GetComponent<NavMeshAgent>();
        
        if (_nav != null && _nav.isOnNavMesh) // Zabezpieczenie przed b³êdem
        {
            _nav.ResetPath();

            // 3. Wylosowanie kierunku i obliczenie pozycji (wed³ug wzoru z instrukcji)
            Vector3 movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
            Vector3 movementPerSecond = movementDirection * WolfVelocity;

            Vector3 position = new Vector3(
                animator.rootPosition.x + (movementPerSecond.x),
                animator.rootPosition.y,
                animator.rootPosition.z + (movementPerSecond.z)
            );

            // 4. Przekazanie celu do nawigacji
            _nav.SetDestination(position);
        }

        // 5. Inicjacja timera
        latestDirectionChangeTime = Time.time;
    }

    // Metoda wywo³ywana co klatkê
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Obs³uga timera
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;

            if (_nav != null && _nav.isOnNavMesh)
            {
                _nav.ResetPath();
            }

            // Losowanie liczby z przedzia³u <1, 4) czyli 1, 2 lub 3
            animator.SetInteger("nextState", Random.Range(1, 4));
        }
    }
}