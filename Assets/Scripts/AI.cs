using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AI : Creature
{
    private NavMeshAgent agent;
    public Transform wayPointPrefab;
    public List<Transform> wayPoints;

    protected override void Start()
    {
        base.Start();
        if (wayPoints == null)
        {
            wayPoints = new List<Transform>();
        }
        agent = GetComponent<NavMeshAgent>();
        wayPoints.Add(Instantiate(wayPointPrefab, this.transform.position, new Quaternion()));
    }


    public ushort currentPoint = 0;
    void Update()
    {
        if (!isAgro)
        {
            Walk();
        }
        else
        {
            ForwardToTarget();
            Attack();
        }
    }

    private void Walk()
    {
        if (!agent.hasPath)
        {
            if (currentPoint + 1 >= wayPoints.Count)
            {
                currentPoint = 0;
            }
            else
            {
                currentPoint++;
            }
            agent.destination = wayPoints[currentPoint].position;
        }
    }

    private void ForwardToTarget()
    {
        if (Actor.Instanse)
        {
            if (CurrentAgroTimer > 0)
            {
                agent.destination = Actor.Instanse.transform.position;
                CurrentAgroTimer -= Time.deltaTime;
            }
            else
            {
                isAgro = false;
                agent.destination = wayPoints[currentPoint].position;
            }
        }
    }

    public List<BotWeapon> Arsenal;
    
    
    private void Attack()
    {
        foreach (var gun in Arsenal)
        {
            if (!gun)
            {
                Debug.Log("Holy shit i m lost my gun");
                Arsenal.Remove(gun);
                break;
            }
            else
            {
                var ActorDirection = Vector3.Normalize(Actor.Instanse.transform.position - gun.transform.position);
                gun.transform.forward = Vector3.Lerp(gun.transform.forward, ActorDirection, 0.1f);
                gun.Shoot();
            }
        }
    }

    public bool isAgro;
    public float DefaultAgroTimer;
    public float CurrentAgroTimer;
    
    private void OnTriggerStay(Collider other)
    {
        var Actor = other.gameObject.GetComponent<Actor>();
        if (Actor)
        {
            BeAgro();
        }
    }

    private void BeAgro()
    {
        isAgro = true;
        CurrentAgroTimer = DefaultAgroTimer;
    }

    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        BeAgro();
    }

    public override object RespawnData 
    {
        get 
        {
            List<Transform> points = new List<Transform>();
            foreach (var point in wayPoints)
            {
                points.Add(point);
            }
            return points;
        }

        set 
        {
            wayPoints = (List<Transform>)value;
        }
    }

}
