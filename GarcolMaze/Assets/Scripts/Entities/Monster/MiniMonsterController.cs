using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using System.IO;
using Unity.Mathematics;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class MiniMonsterController : MonsterController {
    private GameObject[] players;
    NavMeshAgent agent;
    Vector3 target;

    float direction = 1;

    Animator animator;
    public GameObject freezeAnimationPrefab;
    GameObject freeze_effect;

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
            // ignore dead player
            if (!player)
                continue;

            // ignore player outside chase circle
            if (!isInChaseCircle(player.transform.position))
                continue;      

            float dist = calcDist(player.transform.position);

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

    public override void Freeze(float freezeTime)
    {
        if (isFreezed) return;
        // stop movement
        agent.speed = 0;
        // stop animation
        animator.speed = 0;
        // set isFreezed to true
        isFreezed = true;
        // add particle animation for freeze
        freeze_effect = Instantiate(freezeAnimationPrefab, transform.position, Quaternion.identity, transform);

        StartCoroutine(freezing());
        IEnumerator freezing()
        {
            // freeze for freezeTime seconds
            yield return new WaitForSeconds(freezeTime);
            // revert state
            // destroy freeze effect
            Destroy(freeze_effect);
            // set isFreezed to false
            isFreezed = false;
            // continue animation
            animator.speed = 1;
            // continue move
            agent.speed = speed;
        }
    }

    public override void InteractWhenHitPlayer(PlayerController player)
    {
        if (player == null) return;

        
        if (!isFreezed)
        {
            player.Damage(damagePoint);
        }
        else
        {
            // play ice broke effect
            freeze_effect.GetComponent<Animator>().SetTrigger("IsBroke");
            // continue animation
            animator.speed = 1;
            // play dead animation, on exit it will destroy our monster
            SoundManager.PlaySound("hitMonster");
            animator.SetTrigger("IsHitted");
        }
    }
}
