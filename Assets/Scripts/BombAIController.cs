using UnityEngine;
using UnityEngine.AI;

public class BombAIController : MonoBehaviour {

    public Transform player;
    public NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.position);
	}
}
