using UnityEngine.AI;
using UnityEngine;

public class alien1 : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform target;

    void Update(){
        if(target!=null){
            navMeshAgent.SetDestination(target.position);
        }
    }
}
