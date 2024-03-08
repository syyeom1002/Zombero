using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform leftDoor;
    [SerializeField]
    private Transform rightDoor;
    public System.Action onOpen;
    public System.Action onReachDoor;
    [SerializeField]
    private float openAngle = 100f;
    private float openDamping = 1f;
    //���� ��Ż ������Ʈ
    [SerializeField]
    private GameObject fxGo;
    private BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        //�̰� ��� �� ���ư�
        this.col = this.GetComponent<BoxCollider>();
    }

    public void Open()
    {
        //�ϴ� �ٷο��� (������)
        //Debug.Log("������!!door");
        //this.leftDoor.localRotation = Quaternion.Euler(new Vector3(0, -1 * this.openAngle, 0));
        //this.rightDoor.localRotation = Quaternion.Euler(new Vector3(0, 1 * this.openAngle, 0));
        //�����ϴ� ��� �̵��ϼ��� �ؽ�Ʈ ����
        this.onOpen();
        this.StartCoroutine(this.CoOpen());

    }
    private IEnumerator CoOpen()
    {
        var left= Quaternion.Euler(new Vector3(0, -1 * this.openAngle, 0));
        var right= Quaternion.Euler(new Vector3(0, 1 * this.openAngle, 0));
        while (true)
        {
            this.leftDoor.localRotation = Quaternion.Slerp(this.leftDoor.localRotation, left, Time.deltaTime * this.openDamping);
            this.rightDoor.localRotation = Quaternion.Slerp(this.rightDoor.localRotation, right, Time.deltaTime * this.openDamping);

            if (this.leftDoor.localRotation == left)
            {
                break;
            }
            yield return null;
        }
        Debug.Log("�� �� ����");
        //���� �� ������ ����Ż Ȱ��ȭ
        this.fxGo.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.onReachDoor();
        }
    }
}
