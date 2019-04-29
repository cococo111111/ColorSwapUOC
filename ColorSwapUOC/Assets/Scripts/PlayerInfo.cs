using System.Collections.Generic;
using System;

[Serializable]
public class PlayerInfo
{
    public string version = Decryptor.Encrypt("1");
    public string gameDateFirstTime;
    public string playDateFirstTime;    
    //public int sessionsCount = 0;
    public string language = Decryptor.Encrypt("en");
    public string maxScore = Decryptor.Encrypt("0");
    public string coins = Decryptor.Encrypt("0");
    public string soundPlay = Decryptor.Encrypt("true");
    public List<string> cards = new List<string>();
}




