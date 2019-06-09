using UnityEngine;
using System.IO;
using System;

public class LoadConfig : MonoBehaviour {

    public static LoadConfig Instance;
    private string configFileName;
    private string fileName;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this.gameObject);
        Instance = this;
        configFileName = GlobalInfo.configFile;
        fileName = Path.Combine(Application.persistentDataPath, "data");
        fileName = Path.Combine(fileName, configFileName + ".txt");
        if (!File.Exists(fileName))
        {
            PlayerInfo saveData = new PlayerInfo();
            for (int i = 0; i < 5; i++)
            {
                saveData.cards.Add(0);
                saveData.backPack.Add(0);
            }
            //Save data from PlayerInfo to a file named players
            DataSaver.saveData(saveData, configFileName);
            GlobalInfo.gameFirstTime = "true";
            GlobalInfo.soundPlay = "true";
            GlobalInfo.maxScore = 0.ToString();
            GlobalInfo.coins = 0.ToString();
            GlobalInfo.sessionsCount = 0;
            GlobalInfo.cards = saveData.cards;
            GlobalInfo.backPack = saveData.backPack;
            Debug.Log(GlobalInfo.cards);
        } 
        else
        {
            PlayerInfo loadedData = DataSaver.loadData<PlayerInfo>(configFileName);
            if (loadedData == null)
            {
                return;
            }
            GlobalInfo.version = Application.version;
            GlobalInfo.maxScore = Decryptor.Decrypt(loadedData.maxScore);
            GlobalInfo.coins = Decryptor.Decrypt(loadedData.coins);
            GlobalInfo.soundPlay = Decryptor.Decrypt(loadedData.soundPlay);
            GlobalInfo.cards = loadedData.cards;
            GlobalInfo.backPack = loadedData.backPack;
            GlobalInfo.sessionsCount = int.Parse(Decryptor.Decrypt(loadedData.sessionsCount));
            GlobalInfo.gameFirstTime = Decryptor.Decrypt(loadedData.gameFirstTime);
        }
    }

    public void SaveDataGame()
    {
        PlayerInfo saveData = new PlayerInfo();
        saveData.version = Decryptor.Encrypt(Application.version);
        saveData.maxScore = Decryptor.Encrypt(GlobalInfo.maxScore);
        saveData.coins = Decryptor.Encrypt(GlobalInfo.coins);
        saveData.soundPlay = Decryptor.Encrypt(GlobalInfo.soundPlay);
        saveData.cards = GlobalInfo.cards;
        saveData.backPack = GlobalInfo.backPack;
        saveData.sessionsCount = Decryptor.Encrypt(GlobalInfo.sessionsCount.ToString());
        saveData.gameFirstTime = Decryptor.Encrypt(GlobalInfo.gameFirstTime);
        //Save data from PlayerInfo to a file named players
        DataSaver.saveData(saveData, configFileName);
}
}
