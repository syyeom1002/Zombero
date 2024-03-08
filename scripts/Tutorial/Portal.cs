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
            Debug.Log("���Խ��ϴ�");
            //������ collider Ȱ��ȭ ��, ������ ȣ��Ǵ°� ���°Ű���
            this.col.enabled = false;
            this.onReachPortal();
        }
    }
}
