using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseUse : MonoBehaviour
{
    #region 文本，按钮空间变量

    public Texture tex;
    public Rect rect;

    public Rect rect1;

    public GUIContent content;

    public GUIStyle style;

    public Rect btnRect;
    public GUIContent btnContent;
    public GUIStyle btnStyle;
    #endregion

    #region 工具栏，网格变量

    private int toolbarIndex = 0;
    private string[] toolbarInfos = new string[] { "强化", "进阶", "幻化" };

    private int selGridIndex = 0;
    #endregion


    #region 分组变量

    public Rect groupPos;
    public Rect scPos;
    public Rect showPos;
    #endregion

    #region 滚动列表变量

    private Vector2 nowPos;

    private string[] strs = new string[] { "123", "234", "222", "111" };
    #endregion

    #region 窗口变量

    private Rect dragWinPos = new Rect(400, 400, 200, 150);
    #endregion

    #region 皮肤变量
    public GUIStyle styleskin;

    public GUISkin skin;
    #endregion

    private void OnGUI()
    {
        #region 知识点一 GUI 控件绘制的共同点
        //1.他们都是GUI公共类中提供的静态函数 直接调用即可
        //2.他们的参数都大同小异
        //  位置参数：Rect参数  x y位置 w h尺寸
        //  显示文本：string参数
        //  图片信息：Texture参数
        //  综合信息：GUIContent参数
        //  自定义样式：GUIStyle参数
        //3.每一种控件都有多种重载，都是各个参数的排列组合
        //  必备的参数内容 是 位置信息和显示信息
        #endregion

        #region 知识点二 文本控件
        //基本使用
        GUI.Label(new Rect(0, 0, 100, 20), "唐老狮欢迎你", style);
        GUI.Label(rect, tex);
        //综合使用
        GUI.Label(rect1, content);
        //可以获取当前鼠标或者键盘选中的GUI控件 对应的 tooltip信息
        Debug.Log(GUI.tooltip);
        //自定义样式
        #endregion

        #region 知识点三 按钮控件
        //基本使用
        //综合使用
        //自定义样式
        //在按钮范围内 按下鼠标再抬起鼠标 才算一次点击 才会返回true
        if (GUI.Button(btnRect, btnContent, btnStyle))
        {
            //处理我们按钮点击的逻辑
            Debug.Log("按钮被点击");
        }

        //只要在长按按钮范围内 按下鼠标 就会一直返回true
        if (GUI.RepeatButton(btnRect, btnContent))
        {
            Debug.Log("长按按钮被点击");
        }
        #endregion

        #region 知识点一 工具栏
        toolbarIndex = GUI.Toolbar(new Rect(0, 0, 200, 30), toolbarIndex, toolbarInfos);
        //工具栏可以帮助我们根据不同的返回索引 来处理不同的逻辑
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

        #region 知识点二 选择网格
        //相对toolbar多了一个参数 xCount 代表 水平方向最多显示的按钮数量
        selGridIndex = GUI.SelectionGrid(new Rect(0, 50, 200, 60), selGridIndex, toolbarInfos, 1);
        #endregion


        #region 知识点一 分组
        // 用于批量控制控件位置 
        // 可以理解为 包裹着的控件加了一个父对象 
        // 可以通过控制分组来控制包裹控件的位置
        GUI.BeginGroup(groupPos);

        GUI.Button(new Rect(0, 0, 100, 50), "测试按钮");
        GUI.Label(new Rect(0, 60, 100, 20), "Label信息");

        GUI.EndGroup();

        #endregion


        #region 知识点二 滚动列表
        nowPos = GUI.BeginScrollView(scPos, nowPos, showPos);

        GUI.Toolbar(new Rect(0, 0, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 60, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 120, 300, 50), 0, strs);
        GUI.Toolbar(new Rect(0, 180, 300, 50), 0, strs);

        GUI.EndScrollView();
        #endregion

        #region 知识点一 窗口
        //第一个参数 id 是窗口的唯一ID 不要和别的窗口重复
        //委托参数 是用于 绘制窗口用的函数 传入即可
        GUI.Window(1, new Rect(100, 100, 200, 150), DrawWindow, "测试窗口");
        //id对于我们来说 有一个重要作用 除了区分不同窗口 还可以在一个函数中去处理多个窗口的逻辑
        //通过id去区分他们
        GUI.Window(2, new Rect(100, 350, 200, 150), DrawWindow, "测试窗口2");
        #endregion

        #region 知识点二 模态窗口
        //模态窗口 可以让该其它控件不在有用
        //你可以理解该窗口在最上层 其它按钮都点击不到了
        //只能点击该窗口上控件

        //GUI.ModalWindow(3, new Rect(300, 100, 200, 150), DrawWindow, "模态窗口");
        #endregion

        #region 知识点三 拖动窗口
        //位置赋值只是前提
        dragWinPos = GUI.Window(4, dragWinPos, DrawWindow, "拖动窗口");
        #endregion

        #region 知识点一 全局颜色
        //全局的着色颜色 影响背景和文本颜色
        //GUI.color = Color.red;

        //文本着色颜色 会和 全局颜色相乘
        //GUI.contentColor = Color.yellow;
        //GUI.Button(new Rect(0, 0, 100, 30), "测试按钮");

        ////背景元素着色颜色 会和 全局颜色相乘
        //GUI.backgroundColor = Color.red;
        //GUI.Label(new Rect(0, 50, 100, 30), "测试按钮");
        //GUI.color = Color.white;
        //GUI.Button(new Rect(0, 100, 100, 30), "测试按钮", style);

        #endregion

        #region 知识点二 整体皮肤样式
        GUI.skin = skin;
        //虽然设置了皮肤 但是绘制时 如果使用GUIStyle参数 皮肤就没有
        GUI.Button(new Rect(0, 0, 100, 30), "测试按钮");

        GUI.skin = null;
        GUI.Button(new Rect(0, 50, 100, 30), "测试按钮2");

        //它可以帮助我们整套的设置 自定义样式 
        //相对单个控件设置Style要方便一些
        #endregion


        #region 知识点一 GUILayout 自动布局
        //主要用于进行编辑器开发 如果用它来做游戏UI不太合适
        GUI.BeginGroup(new Rect(100, 100, 200, 300));
        GUILayout.BeginVertical();

        GUILayout.Button("123", GUILayout.Width(200));
        GUILayout.Button("245666656565");
        GUILayout.Button("235", GUILayout.ExpandWidth(false));

        GUILayout.EndVertical();
        GUI.EndGroup();
        #endregion

        #region 知识点二 GUILayoutOption 布局选项
        //控件的固定宽高
        GUILayout.Width(300);
        GUILayout.Height(200);
        //允许控件的最小宽高
        GUILayout.MinWidth(50);
        GUILayout.MinHeight(50);
        //允许控件的最大宽高
        GUILayout.MaxWidth(100);
        GUILayout.MaxHeight(100);
        //允许或禁止水平拓展
        GUILayout.ExpandWidth(true);//允许
        GUILayout.ExpandHeight(false);//禁止
        GUILayout.ExpandHeight(true);//允许
        GUILayout.ExpandHeight(false);//禁止
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
                //该API 写在窗口函数中调用 可以让窗口被拖动
                //传入Rect参数的重载 作用 
                //是决定窗口中哪一部分位置 可以被拖动
                //默认不填 就是无参重载 默认窗口的所有位置都能被拖动
                GUI.DragWindow(new Rect(0, 0, 1000, 20));
                break;
        }

    }
}
