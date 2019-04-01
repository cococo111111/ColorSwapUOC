using UnityEngine;
using System.IO;
using System;

public class LoadConfig : MonoBehaviour {

    private string configFileName;
    private string fileName;

	// Use this for initialization
	void Awake ()
    {
        configFileName = GlobalInfo.configFile;
        fileName = Path.Combine(Application.persistentDataPath, "data");
        fileName = Path.Combine(fileName, configFileName + ".txt");
        if (!File.Exists(fileName))
        {
            PlayerInfo saveData = new PlayerInfo();
            saveData.gameDateFirstTime = DateTime.Now.ToBinary().ToString();
            saveData.playDateFirstTime = "";

            //Save data from PlayerInfo to a file named players
            DataSaver.saveData(saveData, configFileName);
            GlobalInfo.gameFirstTime = true;
            GlobalInfo.playFirstTime = true;
            GlobalInfo.language = saveData.language;
            GlobalInfo.soundPlay = true;
            GlobalInfo.sessionsCount = 0;
            GlobalInfo.maxScore = 0;
            GlobalInfo.coins = 0;
        } else
        {
            PlayerInfo loadedData = DataSaver.loadData<PlayerInfo>(configFileName);
            if (loadedData == null)
            {
                return;
            }

            for (int i = 0; i < loadedData.cards.Count; i++)
            {
                Debug.Log("Cards: " + loadedData.cards[i]);
            }
            
            GlobalInfo.gameFirstTime = false;
            if (loadedData.playDateFirstTime != "")
            {
                GlobalInfo.playFirstTime = false;
            } else
            {
                GlobalInfo.playFirstTime = true;
            }
            GlobalInfo.language = loadedData.language;
            GlobalInfo.soundPlay = loadedData.soundPlay;
            GlobalInfo.sessionsCount = loadedData.sessionsCount;
            GlobalInfo.maxScore = loadedData.maxScore;
            GlobalInfo.coins = loadedData.coins;
        }
    }
}
