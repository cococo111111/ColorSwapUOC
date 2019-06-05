using System.Collections.Generic;
using System;

[Serializable]
public class PlayerInfo
{
    public string version = Decryptor.Encrypt("1");
    public string gameFirstTime = Decryptor.Encrypt("true");   
    public string maxScore = Decryptor.Encrypt("0");
    public string coins = Decryptor.Encrypt("0");
    public string soundPlay = Decryptor.Encrypt("true");
    public string sessionsCount = Decryptor.Encrypt("0");
    public List<int> cards = new List<int>(); 
    public List<int> backPack = new List<int>();
}




