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
        //시작하면 조이스틱 비활성화 되는거 활성화하기
        this.background.gameObject.SetActive(true);
    }
    //버튼(조이스틱) 누를때
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        this.onDown();
    }

    // 버튼에서 뗄때
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        this.background.gameObject.SetActive(true);
        //조이스틱 생성위치 anchore위치로 잡기(0,-722)/조이스틱 누르다가 떼면 제자리로 돌아가기
        this.background.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -722f);
        this.onUp();
    }
}
