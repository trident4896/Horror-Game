using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent Nav;
    private Transform TargetLocation;
    private float DistanceToTarget;
    private int TargetNumber = 0;

    private Animator Anim;
    private bool HasStopped = false;

    [SerializeField]
    float StopDistance = 2.0f;
    [SerializeField]
    float WaitTime = 2.0f;

    [SerializeField]
    Transform[] Target;

    private bool CanPatrol = false;

    [SerializeField]
    GameObject MySaveScript;
    private SaveScript PassSaveScript;

    // Start is called before the first frame update
    void Start()
    {
        Nav = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();

        MySaveScript = GameObject.Find("FPSController");

        PassSaveScript = MySaveScript.GetComponent<SaveScript>();

        StartCoroutine(StartElements());

    }

    // Update is called once per frame
    void Update()
    {
        if (CanPatrol == true)
        {
            if (TargetLocation == null)
            {
                TargetNumber = Random.Range(0, Target.Length);
                TargetLocation = Target[TargetNumber];
            }

            DistanceToTarget = Vector3.Distance(TargetLocation.position, transform.position);

            if (DistanceToTarget > StopDistance)
            {
                Nav.SetDestination(TargetLocation.position);
                Anim.SetInteger("State", 0);
                Nav.isStopped = false;
                Nav.speed = 1.6f;
            }

            if (DistanceToTarget < StopDistance)
            {
                Nav.isStopped = true;
                Anim.SetInteger("State", 1);
                StartCoroutine(LookAround());
            }
        }

    }

    IEnumerator LookAround()
    {
        yield return new WaitForSeconds(WaitTime);

        if (HasStopped == false)
        {
            HasStopped = true;
            TargetNumber = Random.Range(0, Target.Length);
            TargetLocation = Target[TargetNumber];

            yield return new WaitForSeconds(WaitTime);
            HasStopped = false;
        }
    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);

        Nav.avoidancePriority = Random.Range(5, 65);

        for (int i = 0; i < PassSaveScript.Patrol_Targets.Length; i++)
        {

            Target[i] = PassSaveScript.Patrol_Targets[i];

        }

        CanPatrol = true;
    }
}
