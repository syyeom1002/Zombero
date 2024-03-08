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
    //총알발사 
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
        //마우스 드래그 각도 구하기
        var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.up);
        //마우스 각도만큼 회전시키고 그 방향으로(forward)이동하기
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

    // 총 쏘는 자세
    public void Attack()
    {
        if (this.bossPrefab != null)
        {
            this.anim.SetInteger("State", 2);
            this.transform.LookAt(this.bossPrefab.transform.position);
            this.Fire();
        }
        //조이스틱이 OnUp일때 Attack을 호출하니까 당연히 죽으면 바로 멈추는게 아니라 조이스틱을 한번 더 움직여야 멈춘다.
        else if(this.bossPrefab==null)
        {
           this.anim.SetInteger("State", 0);
           this.StopFire();
        }
    }

    //------------------------------------------------------총알 발사--------------------------------------------------------
    public void Fire()
    {
        //Debug.Log("총알발사");
        this.StartCoroutine(shootRoutine);
    }
    public void StopFire()
    {
        //Debug.Log("총알 발사 중지");
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
    //------------------------hp바-------------------------------------
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

    //색 바꾸기 부딪히면
    private IEnumerator CoChangeMaterial()
    {
        this.bodyMesh.GetComponent<SkinnedMeshRenderer>().material = mat[0];
        this.headMesh.GetComponent<SkinnedMeshRenderer>().material = mat[0];
        yield return new WaitForSeconds(0.1f);
        this.bodyMesh.GetComponent<SkinnedMeshRenderer>().material = mat[1];
        this.headMesh.GetComponent<SkinnedMeshRenderer>().material = mat[2];
     
    }
}

