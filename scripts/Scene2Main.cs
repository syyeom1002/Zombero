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
    //fade out �Ҷ� alpha���� 0�̾��ٰ� ���� ������� �̹���
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
            //���� �� �Ĵٺ� �ڵ� �߰�
            this.player.Idle();//�Ʒ����� dir=vector3.zero �� idle �����ϴ°� ��µ� �� ����ٰ� �� ������?
        };
        //this.door.onReachDoor = () =>
        //{
        //    //this.FadeOut();
        //};

    }
    // Update is called once per frame
    void Update()
    {
        //����
        var h = this.joystick1.Horizontal;
        //����
        var v = this.joystick1.Vertical;
        var dir = new Vector3(h, 0, v);
        if (dir != Vector3.zero)
            this.player.Move(dir);
        else
            this.player.Idle();
    }
}
