using System.Collections;
using System.Collections.Generic;
using EasyMobile;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public Text score;
    public Text bestScore;
    public Text coins;
    public Text totalCoins;
    int coinsGet;
    int coinsTotal;


    // Start is called before the first frame update
    void Start()
    {
        //Colocamos la puntuacion
        score.text = GlobalInfo.score.ToString();

        //Colocamos la max puntuacion, mirando primero si la que acabamos de realizar es la maxima
        if (GlobalInfo.score > int.Parse(GlobalInfo.maxScore))
        {
            GlobalInfo.maxScore = GlobalInfo.score.ToString();
            bestScore.text = GlobalInfo.maxScore;
            GameServices.ReportScore(long.Parse(GlobalInfo.maxScore), EM_GameServicesConstants.Leaderboard_THE_BEST_COMBIX);
        }
        else
        {
            bestScore.text = GlobalInfo.maxScore;
        }

        //Colocamos los coins ganados en la partida, son la puntuacion dividida entre 4
        coinsGet = GlobalInfo.score / 4;
        coins.text = coinsGet.ToString();

        //Colocamos el total de coins que tenemos disponibles
        coinsTotal = int.Parse(GlobalInfo.coins) + coinsGet;
        GlobalInfo.coins = coinsTotal.ToString();
        totalCoins.text = GlobalInfo.coins;
        LoadConfig.Instance.SaveDataGame();
    }

    public void GoToMainMenu()
    {
        GameServices.ShowLeaderboardUI();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
