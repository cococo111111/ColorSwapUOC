using UnityEngine;

public class GlobalInfo : MonoBehaviour
{
    public static string configFile = "ColorSwapCfg";

    public static string gameFirstTime;
    public static string playFirstTime;
    public static string language;
    public static string soundPlay = "true";
    //public static int sessionsCount;
    public static string maxScore;
    public static string coins;

    //Actual Level
    public static int version;
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
    public static float Speed;
    public static int numberGrids;

    public static int score;
    public static int level;

    //Posició dels goalsResult
    public static Vector3[] resultPositions = new[] { new Vector3(-1.78f, 2.7f, 0f), new Vector3(-0.88f, 2.7f, 0f), new Vector3(0.02f, 2.7f, 0f), new Vector3(0.92f, 2.7f, 0f), new Vector3(1.82f, 2.7f, 0f) };
}
