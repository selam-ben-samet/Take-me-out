using UnityEngine.AI;
using UnityEngine;

public class alien1 : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform target;
    private Animator animator;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    void Start(){
        animator = GetComponent<Animator>();
    }

    void Update(){
        if(target!=null){
            navMeshAgent.SetDestination(target.position);
            //animator.Play("flight");
        }
        // if(target in fov)
        if(Input.GetKeyDown("z")){
        animator.Play("shot");
        Vector3 vector = target.transform.position - bulletSpawnPoint.position;
        GameObject bullet = Instantiate(bulletPrefab,bulletSpawnPoint.position,Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = vector * 5f;
                
        }


    }
}
