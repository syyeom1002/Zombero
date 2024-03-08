using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Material[] mat = new Material[2];

    public enum eState
    {
        IDLE = 0,
        TRACE,
        ClOSE_ATTACK,    //근거리 공격 
        LONG_ATTACK,  //원거리 공격
        DIE,
    }
    public eState state;
    [SerializeField]
    private float closeAttackRange = 4.0f;
    [SerializeField]
    private float traceRange = 30.0f;
    [SerializeField]
    private float longAttackRange = 10.0f;

    private readonly int hashState = Animator.StringToHash("State");

    private float monsterHp = 160.0f;
    public bool isDie;
    private Animator anim;
    private Transform playerTrans;
    private Transform bossTrans;
    private NavMeshAgent agent;
    public float time = 0;
    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private GameObject SphereBomb;

    private GameObject bodyMesh;
    private GameObject shieldMesh;
    private GameObject axeMesh;

    private float currHp;
    private Image hpBar;
    // Start is called before the first frame update
    void Start()
    {
        this.agent = this.GetComponent<NavMeshAgent>();
        this.bossTrans = this.GetComponent<Transform>();
        this.playerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.anim = this.GetComponent<Animator>();

        //agent.destination = this.playerTrans.position;
        this.StartCoroutine(CheckMonsterState());
        this.StartCoroutine(MonsterAction());
        this.StartCoroutine(this.CoCheckTimeToLongAttack());

        this.bodyMesh = GameObject.Find("BlackKnightMesh");
        this.shieldMesh = GameObject.Find("ShieldMesh");
        this.axeMesh = GameObject.Find("AxeMesh");

        this.currHp = this.monsterHp;
        hpBar = GameObject.FindGameObjectWithTag("HP_BAR")?.GetComponent<Image>();

    }

    private IEnumerator CoCheckTimeToLongAttack()
    {
        while (true)
        {
            this.time += Time.deltaTime;
            if (time >= 3.2f)
            {
                this.ResetTime();
            }
            yield return null;
        }
    }
    private void ResetTime()
    {
        this.time = 0;
    }
    private IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            if (this.state == eState.DIE) yield break;

            float distance = Vector3.Distance(this.playerTrans.position, this.bossTrans.position);

            if (distance <= closeAttackRange)
            {
                state = eState.ClOSE_ATTACK;
            }
            else if (distance <= longAttackRange&&this.time>=3.0f)
            {
                state = eState.LONG_ATTACK;
            }
            else if (distance <= traceRange)
            {
                state = eState.TRACE;
            }
            else
            {
                state = eState.IDLE;
            }
        }
    }

    private IEnumerator MonsterAction()
    {
        while (this.isDie == false)
        {
            switch (this.state)
            {
                case eState.IDLE:
                    this.Idle();
                    break;
                case eState.ClOSE_ATTACK:
                    this.CloseAttack();
                    break;
                case eState.TRACE:
                    this.Trace();
                    break;
                case eState.LONG_ATTACK:
                    this.LongAttack();
                    break;
                case eState.DIE:
                    this.Die();
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void Idle()
    {
        this.agent.isStopped = true;
        this.anim.SetInteger(hashState,0);
    }
    private void CloseAttack()
    {
        this.anim.SetInteger(hashState, 2);
    }
    private void Trace()
    {
        this.agent.SetDestination(this.playerTrans.position);
        this.agent.isStopped = false;
        this.anim.SetInteger(hashState, 1);
    }
    private void LongAttack()
    {
        StartCoroutine(CoLongAttack());
    }
    private IEnumerator CoLongAttack()
    {//투사체 던지기
        this.anim.SetInteger(hashState, 3);
        yield return new WaitForSeconds(0.2f);
        Instantiate(this.SphereBomb, firePos.position, firePos.rotation);
        Debug.Log("전");
        yield return new WaitForSeconds(3.0f);
        Debug.Log("후");
    }
    private void Die()
    {
        this.isDie = true;
        this.agent.isStopped = true;
        this.anim.SetTrigger("Die");
        GetComponent<CapsuleCollider>().enabled = false;
        Destroy(this.gameObject, 1.5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (currHp>0.0f&& collision.collider.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            this.currHp -= 10.0f;
            DisPlayHealth();
            Debug.LogFormat("monsterhp:{0}", this.currHp);
            if (this.currHp <= 0)
            {
                this.state = eState.DIE;
            }
        }
        this.StartCoroutine(CoChangeMaterial());
    }

    private void DisPlayHealth()
    {
        hpBar.fillAmount = currHp / monsterHp;
    }

    private IEnumerator CoChangeMaterial()
    {

        this.bodyMesh.GetComponent<SkinnedMeshRenderer>().material = mat[0];
        this.shieldMesh.GetComponent<MeshRenderer>().material = mat[0];
        this.axeMesh.GetComponent<MeshRenderer>().material = mat[0];
        yield return new WaitForSeconds(0.1f);
        this.bodyMesh.GetComponent<SkinnedMeshRenderer>().material = mat[1];
        this.shieldMesh.GetComponent<MeshRenderer>().material = mat[1];
        this.axeMesh.GetComponent<MeshRenderer>().material = mat[1];
        yield return null;
    }
    private void OnDrawGizmos()
    {
        if (state == eState.TRACE)
        {
            Gizmos.color = Color.blue;
            GizmosExtensions.DrawWireArc(this.transform.position, this.transform.forward, 360, this.traceRange);
        }
        else if (state == eState.ClOSE_ATTACK)
        {
            Gizmos.color = Color.red;
            GizmosExtensions.DrawWireArc(this.transform.position, this.transform.forward, 360, this.closeAttackRange);
        }
        else if (state == eState.LONG_ATTACK)
        {
            Gizmos.color = Color.yellow;
            GizmosExtensions.DrawWireArc(this.transform.position, this.transform.forward, 360, this.longAttackRange);
        }
    }
}