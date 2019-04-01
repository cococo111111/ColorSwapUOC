using System.Collections.Generic;
using System;

[Serializable]
public class PlayerInfo
{
    public int version = 1;
    public string gameDateFirstTime;
    public string playDateFirstTime;    
    public int sessionsCount = 0;
    public string language = "en";
    public int maxScore = 0;
    public int coins = 0;
    public bool soundPlay = true;
    public List<int> cards = new List<int>();
}



