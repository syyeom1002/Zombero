using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using static BossController;

public class Player : MonoBehaviour
{
    public Material[] mat = new Material[3];

    [SerializeField]
    private float moveSpeed = 4f;
    [SerializeField]
    private Animator anim;
    private Rigidbody rBody;
    [SerializeField]
    private GameObject bossPrefab;
    public System.Action onReachPortal;
    //�Ѿ˹߻� 
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePos;
    [SerializeField]
    private GameObject fireFx;
    private IEnumerator shootRoutine;

    private GameObject bodyMesh;
    private GameObject headMesh;

    private float playerHp = 100.0f;
    private float currHp;
    private Image hpBar;
    [SerializeField]
    private Transform hpBarPos;
    
    private void Start()
    {
        shootRoutine = CoFire();
        this.rBody = this.GetComponent<Rigidbody>();
        this.Idle();

        this.bodyMesh = GameObject.Find("Body20");
        this.headMesh = GameObject.Find("Head20");

        this.currHp = this.playerHp;
        hpBar = GameObject.FindGameObjectWithTag("HP_BAR2")?.GetComponent<Image>();

    }
    // Start is called before the first frame update
    public void Move(Vector3 dir)
    {
        this.rBody.isKinematic = false;
        this.anim.SetInteger("State", 1);
        //���콺 �巡�� ���� ���ϱ�
        var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.up);
        //���콺 ������ŭ ȸ����Ű�� �� ��������(forward)�̵��ϱ�
        this.transform.rotation = q;
        this.transform.Translate(Vector3.forward * this.moveSpeed * Time.deltaTime);
        this.StopFire();

        this.hpBarPos.position = new Vector3(this.transform.position.x, this.transform.position.y + 2.4f, this.transform.position.z);
    }

    public void Idle()
    {
        Debug.Log("idle");
        this.anim.SetInteger("State", 0);
        //this.rBody.isKinematic = true;
    }

    // �� ��� �ڼ�
    public void Attack()
    {
        if (this.bossPrefab != null)
        {
            this.anim.SetInteger("State", 2);
            this.transform.LookAt(this.bossPrefab.transform.position);
            this.Fire();
        }
        //���̽�ƽ�� OnUp�϶� Attack�� ȣ���ϴϱ� �翬�� ������ �ٷ� ���ߴ°� �ƴ϶� ���̽�ƽ�� �ѹ� �� �������� �����.
        else if(this.bossPrefab==null)
        {
           this.anim.SetInteger("State", 0);
           this.StopFire();
        }
    }

    //------------------------------------------------------�Ѿ� �߻�--------------------------------------------------------
    public void Fire()
    {
        //Debug.Log("�Ѿ˹߻�");
        this.StartCoroutine(shootRoutine);
    }
    public void StopFire()
    {
        //Debug.Log("�Ѿ� �߻� ����");
        this.StopCoroutine(shootRoutine);
    }
    private IEnumerator CoFire()
    {
        while (true)
        {
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            this.ShowFireEffect();
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void ShowFireEffect()
    {
        GameObject fireGo = Instantiate(fireFx, firePos.position, firePos.rotation);
        Destroy(fireGo, 0.5f);
    }
    //------------------------hp��-------------------------------------
    private void OnCollisionEnter(Collision collision)
    {

        if (currHp > 0.0f && collision.collider.CompareTag("Bomb"))
        {
            this.currHp -= 10.0f;
            DisPlayHealth();
        }
        this.StartCoroutine(CoChangeMaterial());
    }


    private void DisPlayHealth()
    {
        hpBar.fillAmount = currHp / playerHp;
        hpBar.transform.position = this.hpBarPos.position;
    }

    //�� �ٲٱ� �ε�����
    private IEnumerator CoChangeMaterial()
    {
        this.bodyMesh.GetComponent<SkinnedMeshRenderer>().material = mat[0];
        this.headMesh.GetComponent<SkinnedMeshRenderer>().material = mat[0];
        yield return new WaitForSeconds(0.1f);
        this.bodyMesh.GetComponent<SkinnedMeshRenderer>().material = mat[1];
        this.headMesh.GetComponent<SkinnedMeshRenderer>().material = mat[2];
     
    }
}

