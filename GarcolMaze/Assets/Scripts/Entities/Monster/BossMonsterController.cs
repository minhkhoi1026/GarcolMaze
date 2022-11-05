using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMonsterController : MonsterController
{
    private List<GameObject> itemObjects;
    NavMeshAgent agent;
    Vector3 target;

    private int currentItemId;

    Animator animator;
    public GameObject freezeAnimationPrefab;
    GameObject freeze_effect;
    public GameObject fireTraitPrefab;
    public float fireDropCycleTime = 1f;

    public float speed = 1;
    public float distEpsilon = 0.2f;

    private void Start()
    {
        animator = GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = true;
        agent.speed = speed;

        target = transform.position;
        itemObjects = GameManager.instance.boardManager.listCurrentItems;
        currentItemId = -1;

        // start drop fire trait
        StartCoroutine(leaveFireTrait());
    }

    private void Update()
    {
        
        SetTargetPosition();
        SetAgentPosition();
    }

    
    IEnumerator leaveFireTrait()
    {
        while (this)
        {
            Vector2 dropPosition = transform.position;
            // freeze for freezeTime seconds
            yield return new WaitForSeconds(fireDropCycleTime);
            Instantiate(fireTraitPrefab, dropPosition, Quaternion.identity);
        }
        yield return null;
    }

    private void SetTargetPosition()
    {
        // go to all item
        if (Vector2.Distance(target, transform.position) <= distEpsilon || currentItemId == -1)
        {
            currentItemId = (currentItemId + 1) % itemObjects.Count;
            target = itemObjects[currentItemId].transform.position;
            while (!itemObjects[currentItemId])
            {
                currentItemId = (currentItemId + 1) % itemObjects.Count;
            }
        }
    }


    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }

    public override void Freeze(float freezeTime)
    {
        // stop movement
        agent.speed = 0;
        // stop animation
        animator.speed = 0;
        // set isFreezed to true
        isFreezed = true;
        // add particle animation for freeze
        freeze_effect = Instantiate(freezeAnimationPrefab, transform.position + 0.5f*transform.up, Quaternion.identity, transform);
        freeze_effect.transform.localScale *= 2.0f;

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
        }
    }
}
