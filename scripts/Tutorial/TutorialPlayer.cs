using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPlayer : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Animator anim;
    // Start is called before the first frame update
    public void Move(Vector3 dir)
    {
        this.anim.SetInteger("State", 1);
        //���콺 �巡�� ���� ���ϱ�
        var angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.up);
        //���콺 ������ŭ ȸ����Ű�� �� ��������(forward)�̵��ϱ�
        this.transform.rotation = q;
        this.transform.Translate(Vector3.forward * this.moveSpeed * Time.deltaTime);
    }

    public void Idle()
    {
        this.anim.SetInteger("State", 0);
    }
}
