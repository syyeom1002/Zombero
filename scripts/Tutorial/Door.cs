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
    //문쪽 포탈 오브젝트
    [SerializeField]
    private GameObject fxGo;
    private BoxCollider col;
    // Start is called before the first frame update
    void Start()
    {
        //이거 없어도 잘 돌아감
        this.col = this.GetComponent<BoxCollider>();
    }

    public void Open()
    {
        //일단 바로열기 (문열기)
        //Debug.Log("문열기!!door");
        //this.leftDoor.localRotation = Quaternion.Euler(new Vector3(0, -1 * this.openAngle, 0));
        //this.rightDoor.localRotation = Quaternion.Euler(new Vector3(0, 1 * this.openAngle, 0));
        //좋습니다 계속 이동하세요 텍스트 변경
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
        Debug.Log("문 다 열림");
        //문이 다 열리면 문포탈 활성화
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
