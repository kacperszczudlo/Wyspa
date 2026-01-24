using UnityEngine;
using System.Collections;

public class Hit : MonoBehaviour
{
    private Animator _animator;
    private UnityEngine.AI.NavMeshAgent _agent;
    public float destroyTime = 10.0f;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void OnCollisionEnter(Collision theObject)
    {
        if (theObject.gameObject.name == "coconut")
        {
            if (_animator != null) _animator.SetTrigger("hit");
            if (_agent != null) _agent.enabled = false;
            
            Destroy(GetComponent<Rigidbody>());
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(gameObject, destroyTime);
        }
    }
    
    // USUNÊLIŒMY METODÊ OnTriggerEnter - teraz wilk nie zabija "ca³ym cia³em"
}