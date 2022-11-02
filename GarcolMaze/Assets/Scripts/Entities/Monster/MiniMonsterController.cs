using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using System.IO;
using Unity.Mathematics;

public class MiniMonsterController : MonsterController {
    private GameObject[] players;
    NavMeshAgent agent;
    Vector3 target;

    float direction = 1;

    Animator animator;

    public float speed = 1;
    public float chaseRadius = 3;
    public Vector3 startPosition;

    private void Start()
    {
        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = true;
        agent.speed = speed;

        startPosition = transform.position;
        target = startPosition;
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
        SetEnemyAnimator();
    }

    private void SetEnemyAnimator()
    {
        // change direction so the monster will facing player
        direction = target.x - transform.position.x;
        direction = Math.Min(1, Math.Max(direction, -1));
        animator.SetFloat("Move Direction", direction);
    }

    private void SetTargetPosition()
    {
        // default target is start position
        // target = startPosition;

        float minDist = float.MaxValue;

        // choose nearest player
        foreach (GameObject player in players)
        {
            // ignore player outside chase circle
            if (!isInChaseCircle(player.transform.position))
                continue;      

            float dist = calcDist(player.transform.position);
            Debug.Log(dist);

            if (dist < minDist)
            {
                minDist = dist;
                target = player.transform.position;
            }
        }
    }

    private bool isInChaseCircle(Vector3 position)
    {
        return Vector2.Distance(startPosition, position) <= chaseRadius;
    }

    // calculate distance from monster to player,
    // if cannot find path then return max_path + 1
    private float calcDist(Vector3 position)
    {
        NavMeshPath path = new NavMeshPath();

        if (agent.CalculatePath(position, path))
        {
            float distance = Vector2.Distance(transform.position, path.corners[0]);

            for (int j = 1; j < path.corners.Length; j++)
            {
                distance += Vector2.Distance(path.corners[j - 1], path.corners[j]);
            }

            return distance;
        }
        return float.MaxValue;
    }


    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    public override void Freeze()
    {
        agent.speed = 0;
        // TODO: add particle animation for freeze
    }
}
