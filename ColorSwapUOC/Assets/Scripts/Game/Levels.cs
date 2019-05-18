using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

[Serializable]
public class LevelInfo
{
    public int version;
    public int levelNum;
    public string GoalType1;
    public int GoalNum1;
    public string GoalType2;
    public int GoalNum2;
    public string GoalType3;
    public int GoalNum3;
    public string GoalType4;
    public int GoalNum4;
    public string GoalType5;
    public int GoalNum5;
    public float Speed;
    public int Grids;
}

public class Levels : MonoBehaviour
{

    public static void LoadLevel(int levelNum)
    {
        //load info from levels folder       
        TextAsset jsonTextFile = Resources.Load<TextAsset>("Levels/Colors" + levelNum.ToString());
        object resultValue = JsonUtility.FromJson<LevelInfo>(Encoding.ASCII.GetString(jsonTextFile.bytes));
        LevelInfo loadlevel = (LevelInfo)Convert.ChangeType(resultValue, typeof(LevelInfo));

        GlobalInfo.version = loadlevel.version; 
        GlobalInfo.levelNum = loadlevel.levelNum;
        GlobalInfo.GoalType1 = loadlevel.GoalType1;
        GlobalInfo.GoalNum1 = loadlevel.GoalNum1;
        GlobalInfo.GoalType2 = loadlevel.GoalType2;
        GlobalInfo.GoalNum2 = loadlevel.GoalNum2;
        GlobalInfo.GoalType3 = loadlevel.GoalType3;
        GlobalInfo.GoalNum3 = loadlevel.GoalNum3;
        GlobalInfo.GoalType4 = loadlevel.GoalType4;
        GlobalInfo.GoalNum4 = loadlevel.GoalNum4;
        GlobalInfo.GoalType5 = loadlevel.GoalType5;
        GlobalInfo.GoalNum5 = loadlevel.GoalNum5;
        GlobalInfo.speed = loadlevel.Speed;
        GlobalInfo.numberGrids = loadlevel.Grids;

        //ShowLevelInfo();
    }
}
