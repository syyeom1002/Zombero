using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMain : MonoBehaviour
{
    [SerializeField]
    private CJoystick1 joystick1;
    [SerializeField]
    private Player player;
    [SerializeField]
    private BossController bossController;
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
            this.player.Attack();//�Ʒ����� dir=vector3.zero �� idle �����ϴ°� ��µ� �� ����ٰ� �� ������?
        };
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
        {
            this.player.Move(dir);
        }
        //else if(dir==Vector3.zero&&isDown==false)
        //this.player.Attack();

    }
}
