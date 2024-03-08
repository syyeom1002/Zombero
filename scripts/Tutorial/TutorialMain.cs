using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMain : MonoBehaviour
{
    [SerializeField]
    private CJoystick1 joystick1;
    [SerializeField]
    private TutorialPlayer player;
    [SerializeField]
    private Door door;
    [SerializeField]
    private Portal portal;
    [SerializeField]
    private GameObject npcGo;
    [SerializeField]
    private Text txtMessage;
    [SerializeField]
    private Image imgDim;
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
            this.player.Idle();//�Ʒ����� dir=vector3.zero �� idle �����ϴ°� ��µ� �� ����ٰ� �� ������?
        };
        this.npcGo.SetActive(true);//npc �Ⱥ��̴ٰ� ���̱� �����ΰŰ����ѵ����
        this.door.onOpen = () =>
        {
            this.txtMessage.text = "�����ϴ�. ���� ���� ��� �̵��ϼ���.";
        };
        this.door.onReachDoor = () =>
        {
           this.FadeOut();
        };
        this.portal.onReachPortal = () =>
        {
            Debug.Log("open door");
            this.door.Open();
        };
    }
    public void FadeOut()
    {
        this.imgDim.gameObject.SetActive(true);
        this.StartCoroutine(this.CoFadeOut());
    }
    private IEnumerator CoFadeOut()
    {
        var color = this.imgDim.color;

        while (true)
        {
            color.a += 0.01f;
            this.imgDim.color = color;
            if (color.a >= 1)
            {
                break;
            }
            yield return null;
        }
        SceneManager.LoadScene("Boss");
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
