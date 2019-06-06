using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoBehaviour
{
    public static string configFile = "CombixCfg_v103alpha";


    public static string version;
    public static string gameFirstTime;
    public static string language;
    public static string soundPlay = "true";
    public static int sessionsCount;
    public static string maxScore = "0";
    public static string coins= "0";
    public static List<int> cards = new List<int>();
    public static List<int> backPack = new List<int>();

    //Actual Level
    public static int levelNum;
    public static string GoalType1;
    public static int GoalNum1;
    public static string GoalType2;
    public static int GoalNum2;
    public static string GoalType3;
    public static int GoalNum3;
    public static string GoalType4;
    public static int GoalNum4;
    public static string GoalType5;
    public static int GoalNum5;
    public static float speed;
    public static int numberGrids;

    public static int score;

    //Posició dels goalsResult
    public static Vector3[] resultPositions = new[] { new Vector3(-1.78f, 2.7f, 0f), new Vector3(-0.88f, 2.7f, 0f), new Vector3(0.02f, 2.7f, 0f), new Vector3(0.92f, 2.7f, 0f), new Vector3(1.82f, 2.7f, 0f) };

    //Posicio de les cartes segons el nombre
    public static Vector3[] Cards5 = new[] { new Vector3(0.25f, -1.5f, 0f), new Vector3(1.15f, -1.5f, 0f), new Vector3(2.05f, -1.5f, 0f), new Vector3(2.95f, -1.5f, 0f), new Vector3(3.85f, -1.5f, 0f) };
    public static Vector3[] Cards4 = new[] { new Vector3(0.7f, -1.5f, 0f), new Vector3(1.6f, -1.5f, 0f), new Vector3(2.5f, -1.5f, 0f), new Vector3(3.4f, -1.5f, 0f) };
    public static Vector3[] Cards3 = new[] { new Vector3(1.15f, -1.5f, 0f), new Vector3(2.05f, -1.5f, 0f), new Vector3(2.95f, -1.5f, 0f)};
    public static Vector3[] Cards2 = new[] { new Vector3(1.6f, -1.5f, 0f), new Vector3(2.5f, -1.5f, 0f) };
    public static Vector3[] Cards1 = new[] { new Vector3(2.05f, -1.5f, 0f) };


}
