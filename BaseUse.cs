using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseUse : MonoBehaviour
{
    #region �ı�����ť�ռ����

    public Texture tex;
    public Rect rect;

    public Rect rect1;

    public GUIContent content;

    public GUIStyle style;

    public Rect btnRect;
    public GUIContent btnContent;
    public GUIStyle btnStyle;
    #endregion

    #region ���������������

    private int toolbarIndex = 0;
    private string[] toolbarInfos = new string[] { "ǿ��", "����", "�û�" };

    private int selGridIndex = 0;
    #endregion


    #region �������

    public Rect groupPos;
    public Rect scPos;
    public Rect showPos;
    #endregion

    #region �����б����

    private Vector2 nowPos;

    private string[] strs = new string[] { "123", "234", "222", "111" };
    #endregion

    #region ���ڱ���

    private Rect dragWinPos = new Rect(400, 400, 200, 150);
    #endregion

    #region Ƥ������
    public GUIStyle styleskin;

    public GUISkin skin;
    #endregion

    private void OnGUI()
    {
        #region ֪ʶ��һ GUI �ؼ����ƵĹ�ͬ��
        //1.���Ƕ���GUI���������ṩ�ľ�̬���� ֱ�ӵ��ü���
        //2.���ǵĲ�������ͬС��
        //  λ�ò�����Rect����  x yλ�� w h�ߴ�
        //  ��ʾ�ı���string����
        //  ͼƬ��Ϣ��Texture����
        //  �ۺ���Ϣ��GUIContent����
        //  �Զ�����ʽ��GUIStyle����
        //3.ÿһ�ֿؼ����ж������أ����Ǹ����������������
        //  �ر��Ĳ������� �� λ����Ϣ����ʾ��Ϣ
        #endregion

        #region ֪ʶ��� �ı��ؼ�
        //����ʹ��
        GUI.Label(new Rect(0, 0, 100, 20), "����ʨ��ӭ��", style);
        GUI.Label(rect, tex);
        //�ۺ�ʹ��
        GUI.Label(rect1, content);
        //���Ի�ȡ��ǰ�����߼���ѡ�е�GUI�ؼ� ��Ӧ�� tooltip��Ϣ
        Debug.Log(GUI.tooltip);
        //�Զ�����ʽ
        #endregion

        #region ֪ʶ���� ��ť�ؼ�
        //����ʹ��
        //�ۺ�ʹ��
        //�Զ�����ʽ
        //�ڰ�ť��Χ�� ���������̧����� ����һ�ε�� �Ż᷵��true
        if (GUI.Button(btnRect, btnContent, btnStyle))
        {
            //�������ǰ�ť������߼�
            Debug.Log("��ť�����");
        }

        //ֻҪ�ڳ�����ť��Χ�� ������� �ͻ�һֱ����true
        if (GUI.RepeatButton(btnRect, btnContent))
        {
            Debug.Log("������ť�����");
        }
        #endregion

        #region ֪ʶ��һ ������
        toolbarIndex = GUI.Toolbar(new Rect(0, 0, 200, 30), toolbarIndex, toolbarInfos);
        //���������԰������Ǹ��ݲ�ͬ�ķ������� ������ͬ���߼�
        switch (toolbarIndex)
        {
            case 0:
                Debug.Log("111111111");
                break;
            case 1:
                Debug.Log("22222222222");
                break;
            case 2:
                Debug.Log("33333333333");
                break;
        }
        #endregion

        #region ֪ʶ��� ѡ������
        //���toolbar����һ������ xCount ���� ˮƽ���������ʾ�İ�ť����
        selGridIndex = GUI.SelectionGrid(new Rect(0, 50, 200, 60), selGridIndex, toolbarInfos, 1);
        #endregion


        #region ֪ʶ��һ ����
        // �����������ƿؼ�λ�� 
        // �������Ϊ �����ŵĿؼ�����һ�������� 
        // ����ͨ�����Ʒ��������ư����ؼ���λ��
        GUI.BeginGroup(groupPos);

        GUI.Button(new Rect(0, 0, 100, 50), "���԰�ť");
        GUI.Label(new Rect(0, 60, 100, 20), "Label��Ϣ");

        GUI.EndGroup();

        #endregion


        #region ֪ʶ��� �����б�
        nowPos = GUI.BeginScrollView(scPos, nowPos, showPos);

        GUI.Toolbar(new Rect(0, 0, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 60, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 120, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 180, 300, 50), 0, strs);

        GUI.EndScrollView();
        #endregion

        #region ֪ʶ��һ ����
        //��һ������ id �Ǵ��ڵ�ΨһID ��Ҫ�ͱ�Ĵ����ظ�
        //ί�в��� ������ ���ƴ����õĺ��� ���뼴��
        GUI.Window(1, new Rect(100, 100, 200, 150), DrawWindow, "���Դ���");
        //id����������˵ ��һ����Ҫ���� �������ֲ�ͬ���� ��������һ��������ȥ���������ڵ��߼�
        //ͨ��idȥ��������
        GUI.Window(2, new Rect(100, 350, 200, 150), DrawWindow, "���Դ���2");
        #endregion

        #region ֪ʶ��� ģ̬����
        //ģ̬���� �����ø������ؼ���������
        //��������ô��������ϲ� ������ť�����������
        //ֻ�ܵ���ô����Ͽؼ�

        //GUI.ModalWindow(3, new Rect(300, 100, 200, 150), DrawWindow, "ģ̬����");
        #endregion

        #region ֪ʶ���� �϶�����
        //λ�ø�ֵֻ��ǰ��
        dragWinPos = GUI.Window(4, dragWinPos, DrawWindow, "�϶�����");
        #endregion

        #region ֪ʶ��һ ȫ����ɫ
        //ȫ�ֵ���ɫ��ɫ Ӱ�챳�����ı���ɫ
        //GUI.color = Color.red;

        //�ı���ɫ��ɫ ��� ȫ����ɫ���
        //GUI.contentColor = Color.yellow;
        //GUI.Button(new Rect(0, 0, 100, 30), "���԰�ť");

        ////����Ԫ����ɫ��ɫ ��� ȫ����ɫ���
        //GUI.backgroundColor = Color.red;
        //GUI.Label(new Rect(0, 50, 100, 30), "���԰�ť");
        //GUI.color = Color.white;
        //GUI.Button(new Rect(0, 100, 100, 30), "���԰�ť", style);

        #endregion

        #region ֪ʶ��� ����Ƥ����ʽ
        GUI.skin = skin;
        //��Ȼ������Ƥ�� ���ǻ���ʱ ���ʹ��GUIStyle���� Ƥ����û��
        GUI.Button(new Rect(0, 0, 100, 30), "���԰�ť");

        GUI.skin = null;
        GUI.Button(new Rect(0, 50, 100, 30), "���԰�ť2");

        //�����԰����������׵����� �Զ�����ʽ 
        //��Ե����ؼ�����StyleҪ����һЩ
        #endregion


        #region ֪ʶ��һ GUILayout �Զ�����
        //��Ҫ���ڽ��б༭������ �������������ϷUI��̫����
        GUI.BeginGroup(new Rect(100, 100, 200, 300));
        GUILayout.BeginVertical();

        GUILayout.Button("123", GUILayout.Width(200));
        GUILayout.Button("245666656565");
        GUILayout.Button("235", GUILayout.ExpandWidth(false));

        GUILayout.EndVertical();
        GUI.EndGroup();
        #endregion

        #region ֪ʶ��� GUILayoutOption ����ѡ��
        //�ؼ��Ĺ̶����
        GUILayout.Width(300);
        GUILayout.Height(200);
        //����ؼ�����С���
        GUILayout.MinWidth(50);
        GUILayout.MinHeight(50);
        //����ؼ��������
        GUILayout.MaxWidth(100);
        GUILayout.MaxHeight(100);
        //������ֹˮƽ��չ
        GUILayout.ExpandWidth(true);//����
        GUILayout.ExpandHeight(false);//��ֹ
        GUILayout.ExpandHeight(true);//����
        GUILayout.ExpandHeight(false);//��ֹ
        #endregion
    }

    private void DrawWindow(int id)
    {
        switch (id)
        {
            case 1:
                GUI.Button(new Rect(0, 30, 30, 20), "1");
                break;
            case 2:
                GUI.Button(new Rect(0, 30, 30, 20), "2");
                break;
            case 3:
                GUI.Button(new Rect(0, 30, 30, 20), "3");
                break;
            case 4:
                //��API д�ڴ��ں����е��� �����ô��ڱ��϶�
                //����Rect���������� ���� 
                //�Ǿ�����������һ����λ�� ���Ա��϶�
                //Ĭ�ϲ��� �����޲����� Ĭ�ϴ��ڵ�����λ�ö��ܱ��϶�
                GUI.DragWindow(new Rect(0, 0, 1000, 20));
                break;
        }

    }
}
