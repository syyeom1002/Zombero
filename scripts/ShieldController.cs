using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    public float moveSpeed = 0f;
    private GameObject enemyGo=null;
    private Coroutine coroutine;
    private Vector3 startPos;
    [SerializeField] private TestMain testMain;

    private void Start()
    {
        this.startPos = this.transform.position;

        //for(int i = 1; i < enemyGo.Length; i++)
        //{
        //    Transform enemyPos = enemyGo[i].transform;
        //    this.queue.Enqueue(enemyPos);
        //    Debug.Log(enemyGo);
        //}
    }

    public void Move(Vector3 destPos)
    {
        if (this.coroutine != null) StopCoroutine(this.coroutine);
        this.coroutine=StartCoroutine(this.CoMove(destPos));
    }

    IEnumerator CoMove(Vector3 destPos)
    {
        while (true)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        StartCoroutine(this.CoFindAndMove());
    }

    private IEnumerator CoFindAndMove()
    {
        yield return new WaitForSeconds(0.1f);
        this.enemyGo = GameObject.FindGameObjectWithTag("Enemy");
        if (enemyGo != null)
        {
            this.testMain.destPos = this.enemyGo.transform.position;
            //Debug.Log(this.testMain.destPos);//계속 사라진애의 pos가 destpos임
            //Debug.Log(this.enemyGo.transform.position);
            this.Move(this.testMain.destPos);
        }
        else if (enemyGo == null)
        {
            this.Move(this.startPos);
        }
    }
}