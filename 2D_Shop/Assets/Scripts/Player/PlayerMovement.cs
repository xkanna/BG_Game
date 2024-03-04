using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private Vector3 targetPosition;
    private NavMeshAgent agent;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            SetTargetPosition();
        }

        MoveToTarget();
    }

    private void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f; 

        var direction = (targetPosition - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            player.PlayerAnimator.SetBool("Moving", true);

            if (direction.x < 0)
            {
                player.SpriteRenderer.flipX = false;
            }
            else
            {
                player.SpriteRenderer.flipX = true;
            }
        }
    }

    private void MoveToTarget()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            agent.SetDestination(targetPosition);
        }
        else
        {
            player.PlayerAnimator.SetBool("Moving", false);
        }
    }
}
