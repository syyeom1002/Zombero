using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CJoystick1 : FloatingJoystick
{
    public System.Action onDown;
    public System.Action onUp;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        //�����ϸ� ���̽�ƽ ��Ȱ��ȭ �Ǵ°� Ȱ��ȭ�ϱ�
        this.background.gameObject.SetActive(true);
    }
    //��ư(���̽�ƽ) ������
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        this.onDown();
    }

    // ��ư���� ����
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        this.background.gameObject.SetActive(true);
        //���̽�ƽ ������ġ anchore��ġ�� ���(0,-722)/���̽�ƽ �����ٰ� ���� ���ڸ��� ���ư���
        this.background.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -722f);
        this.onUp();
    }
}
