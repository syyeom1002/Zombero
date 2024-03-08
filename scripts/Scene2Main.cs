using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Scene2Main : MonoBehaviour
{
    [SerializeField]
    private CJoystick1 joystick1;
    [SerializeField]
    private Player player;
    //[SerializeField]
    //private Door door;
    //fade out 할때 alpha값이 0이었다가 점점 까매지는 이미지
    //[SerializeField]
    //private Image imgDim;
    private bool isDown;
    // Start is called before the first frame update
    void Start()
    {
        this.joystick1.onDown = () =>
        {
            this.isDown = true;
        };

        this.joystick1.onUp = () =>
        {
            this.isDown = false;
            //떼면 적 쳐다봄 코드 추가
            this.player.Idle();//아래에서 dir=vector3.zero 면 idle 실행하는거 썼는데 왜 여기다가 또 썼을까?
        };
        //this.door.onReachDoor = () =>
        //{
        //    //this.FadeOut();
        //};

    }
    // Update is called once per frame
    void Update()
    {
        //수평
        var h = this.joystick1.Horizontal;
        //수직
        var v = this.joystick1.Vertical;
        var dir = new Vector3(h, 0, v);
        if (dir != Vector3.zero)
            this.player.Move(dir);
        else
            this.player.Idle();
    }
}
