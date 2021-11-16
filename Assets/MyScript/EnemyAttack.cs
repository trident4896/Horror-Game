using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent Nav;
    private NavMeshHit NavHit;
    private bool Blocked = false;
    private bool RunToPlayer = false;
    private float DistanceToPlayer;
    private bool IsChecking = true;
    private int FailedChecks = 0;

    [SerializeField]
    Transform Player;
    [SerializeField]
    GameObject Enemy;
    [SerializeField]
    float MaxRange = 35.0f;
    [SerializeField]
    Animator Anim;
    [SerializeField]
    int MaxChecks = 3;
    [SerializeField]
    float ChaseSpeed = 8.5f;
    [SerializeField]
    float WalkSpeed = 1.6f;
    [SerializeField]
    float AttackDistance = 2.3f;
    [SerializeField]
    float AttackRotateSpeed = 2.0f;
    [SerializeField]
    float CheckTime = 3.0f;

    [SerializeField]
    GameObject MyEnemy;
    private EnemyDamage EnemyDeathScript;
    [SerializeField]
    float StopSongTime = 3.0f;

    [SerializeField]
    GameObject ChaseMusic;

    [SerializeField]
    GameObject HurtUI;

    [SerializeField] bool bHaveKnife;
    [SerializeField] bool bHaveBat;
    [SerializeField] bool bHaveAxe;

    [SerializeField]
    GameObject MySaveScript;
    private SaveScript PassSaveScript;

    private bool CanRun = false;

    // Start is called before the first frame update
    void Start()
    {
        MySaveScript = GameObject.Find("FPSController");

        PassSaveScript = MySaveScript.GetComponent<SaveScript>();

        Nav = GetComponentInParent<NavMeshAgent>();

        StartCoroutine(StartElements());

        EnemyDeathScript = MyEnemy.GetComponent<EnemyDamage>();

    }

    // Update is called once per frame
    void Update()
    {
        if (CanRun == true)
        {
            DistanceToPlayer = Vector3.Distance(Player.position, Enemy.transform.position);
            Blocked = NavMesh.Raycast(transform.position, Player.position, out NavHit, NavMesh.AllAreas);
            Debug.DrawLine(transform.position, Player.position, Blocked ? Color.red : Color.green);

            if (DistanceToPlayer < MaxRange)
            {
                if (IsChecking == true)
                {
                    IsChecking = false;

                    if (Blocked == false)
                    {
                        RunToPlayer = true;
                        FailedChecks = 0;
                    }

                    if (Blocked == true)
                    {
                        RunToPlayer = false;
                        Anim.SetInteger("State", 1);
                        FailedChecks++;
                    }

                    StartCoroutine(TimedCheck());
                }
            }
            else if (DistanceToPlayer > MaxRange)
            {
                RunToPlayer = false;
                Anim.SetInteger("State", 1);
                FailedChecks++;

                StartCoroutine(TimedCheck());
            }


            if (RunToPlayer == true)
            {
                Enemy.GetComponent<EnemyMove>().enabled = false;

                if (EnemyDeathScript.isDead == false)
                {
                    ChaseMusic.gameObject.SetActive(true);
                }

                if (DistanceToPlayer > AttackDistance)
                {
                    Nav.isStopped = false;
                    Anim.SetInteger("State", 2);
                    Nav.acceleration = 24;
                    Nav.SetDestination(Player.position);
                    Nav.speed = ChaseSpeed;
                    HurtUI.gameObject.SetActive(false);
                }

                if (DistanceToPlayer < AttackDistance - 0.5f)
                {
                    Nav.isStopped = true;
                    if (bHaveAxe == true)
                    {
                        Anim.SetInteger("State", 3);
                    }

                    if (bHaveBat == true)
                    {
                        Anim.SetInteger("State", 4);
                    }

                    if (bHaveKnife == true)
                    {
                        Anim.SetInteger("State", 5);
                    }

                    Nav.acceleration = 180;
                    HurtUI.gameObject.SetActive(true);

                    Vector3 Pos = (Player.position - Enemy.transform.position).normalized;
                    Quaternion PosRotation = Quaternion.LookRotation(new Vector3(Pos.x, 0, Pos.z));
                    Enemy.transform.rotation = Quaternion.Slerp(Enemy.transform.rotation, PosRotation, Time.deltaTime * AttackRotateSpeed);
                }

            }
            else if (RunToPlayer == false)
            {
                Nav.isStopped = true;
            }

            if (EnemyDeathScript.isDead == true)
            {
                StartCoroutine(StopChaseMusic());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            RunToPlayer = true;
        }
    }

    IEnumerator TimedCheck()
    {
        yield return new WaitForSeconds(CheckTime);

        IsChecking = true;

        if (FailedChecks > MaxChecks)
        {
            Enemy.GetComponent<EnemyMove>().enabled = true;
            Nav.isStopped = false;
            Nav.speed = WalkSpeed;
            FailedChecks = 0;
            StartCoroutine(StopChaseMusic());
        }
    }

    IEnumerator StopChaseMusic()
    {
        yield return new WaitForSeconds(StopSongTime);

        ChaseMusic.gameObject.SetActive(false);
    }

    IEnumerator StartElements()
    {
        yield return new WaitForSeconds(0.1f);

        Player = PassSaveScript.PlayerPrefab;
        ChaseMusic = PassSaveScript.Chase;
        HurtUI = PassSaveScript.Hurt;

        ChaseMusic.gameObject.SetActive(false);

        CanRun = true;
    }
}
