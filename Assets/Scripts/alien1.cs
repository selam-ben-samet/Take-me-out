using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class alien1 : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform target;
    [SerializeField] private float detectionRadius = 1.0f; 
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private GameObject youDied;

    void Start(){
        
    }

    void Update(){
        if(target!=null){
            navMeshAgent.SetDestination(target.position);
        
        }
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(0);
            SceneManager.sceneLoaded += OnSceneLoaded;
            youDied.SetActive(false);
        }
        DetectPlayer();

    }
    void DetectPlayer()
    {
        
        if (target != null)
        {
           
            float squaredDistance = (target.transform.position - transform.position).sqrMagnitude;
            float squaredDetectionRadius = detectionRadius * detectionRadius;

            
            if (squaredDistance <= squaredDetectionRadius)
            {
                Time.timeScale = 0;
                youDied.SetActive(true);
                
               
            }
        }
    }
     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       Time.timeScale=1;
    }
}
