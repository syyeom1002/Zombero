using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public System.Action onReachPortal;
    private BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        this.col = this.GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("들어왔습니다");
            //들어오면 collider 활성화 끔, 여러번 호출되는거 막는거같음
            this.col.enabled = false;
            this.onReachPortal();
        }
    }
}
