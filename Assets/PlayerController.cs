using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    NavMeshAgent agent;
    public PlayerAnimatorController playerAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!agent.hasPath)
        {
            playerAnimatorController.IdleAnim();
        }
    }

    // Update is called once per frame
    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
        playerAnimatorController.WalkAnim();

    }

    public void Attack()
    {
        playerAnimatorController.AttackAnim();
    }

    public void resetMovement()
    {
        agent.ResetPath();
    }
}
