using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController _instance;
    public Color purple;
    public SkinnedMeshRenderer headRender;
    public Mesh[] headMeshArray;
    private int headMeshIndex = 0;
    [Header("Hand")]
    public SkinnedMeshRenderer handRender;
    public Mesh[] handMeshArray;
    private int handMeshIndex = 0;

    [Header("ChangeColor")]
    public SkinnedMeshRenderer[] render;
    [HideInInspector]
    public Color[] colorArray;
    private int colorIndex = -1;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        colorArray = new Color[] { Color.blue, Color.cyan, Color.green, purple, Color.red };
        DontDestroyOnLoad(this.gameObject);
    }
    public void OnHeadMesh()//头部换装
    {
        headMeshIndex++;
        headMeshIndex %= headMeshArray.Length;
        headRender.sharedMesh = headMeshArray[headMeshIndex];
    }
    public void OnHandMesh()//手部换装
    {

        handMeshIndex++;
        handMeshIndex %= handMeshArray.Length;
        handRender.sharedMesh = handMeshArray[handMeshIndex];
    }
    #region 换身体颜色

    public void OnChangeColorBlue()
    {
        colorIndex = 0;
        OnChangeColor(Color.blue);

    }
    public void OnChangeColorCyan()
    {
        colorIndex = 1;
        OnChangeColor(Color.cyan);
    }
    public void OnChangeColorGreen()
    {

        colorIndex = 2;
        OnChangeColor(Color.green);
    }
    public void OnChangeColorPurple()
    {

        colorIndex = 3;
        OnChangeColor(purple);
    }
    public void OnChangeColorRed()
    {

        colorIndex = 4;
        OnChangeColor(Color.red);
    }
    public void OnChangeColor(Color c)
    {
        foreach(SkinnedMeshRenderer temp in render)
        {
            temp.material.color = c;
        }
    }
    #endregion
    void Save()//保存换装信息
    {
        PlayerPrefs.SetInt("HeadMeshIndex", headMeshIndex);
        PlayerPrefs.SetInt("HandMeshIndex", handMeshIndex);
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
    }
    public void OnPlay()
    {
        Save();
        Application.LoadLevel(1);

    }
}
