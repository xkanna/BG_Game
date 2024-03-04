using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
            animator.SetBool("Moving", true);
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);

            // Flip the character sprite if moving left
            if (direction.x < 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
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
            animator.SetBool("Moving", false);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
    }
}
