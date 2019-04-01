using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Sprite[] colors = new Sprite[12];
    public GameObject colorBloc;
    public GameObject parentColorBlocs;
    public Sprite cellEmpty;
    public Sprite blankCell;
    public AudioClip newGoalsSound;
    public Text score;
    public Text level;

    bool levelGenerated = false;
    //Fem una llista per posar els Grids sense color
    List<GameObject> gridColors = new List<GameObject>();
    //Fem una llista per posar els colors primaris
    List<Sprite> primaryColors = new List<Sprite>();
    List<int> numberPrimaryColors = new List<int>();
    //Fem una llista per posar els colors secundaris
    List<Sprite> secondaryColors = new List<Sprite>();
    List<int> numberSecondaryColors = new List<int>();
    //Fem una llista per posar els colors terciaris
    List<Sprite> tertiaryColors = new List<Sprite>();
    List<int> numberTertiaryColors = new List<int>();

    private int count = 0;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GlobalInfo.score = 0;

        InvokeRepeating("GenerateColorsGoal", 1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        ShowPoints();
        if (gridColors.Count == 0)
        {

        }
        if (GlobalInfo.numberGrids == 0 && levelGenerated)
        {
            Debug.Log("LEVEL COMPLETED");
            GlobalInfo.levelNum++;
            levelGenerated = false;
            return;
        }
    }

    public void GetColors()
    {
        for (int i = 1; i < 26; i++)
        {
            gridColors.Add(GameObject.Find("Cell" + i));
        }
    }

    private void ShowPoints()
    {
        //score.text = GlobalInfo.score.ToString("#,#");
    }

    private void ShowLevel()
    {
        //level.text = GlobalInfo.level.ToString();
        if (GlobalInfo.level > 1)
        {
            GlobalInfo.score = GlobalInfo.score + 1000;
        }
        PlaySound();
        ShowPoints();
    }

    void PlaySound()
    {
        if (GlobalInfo.soundPlay == true)
        {
            StartCoroutine(SoundEffects(newGoalsSound));            
        }        
    }

    IEnumerator SoundEffects(AudioClip clip)
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().PlayOneShot(clip,0.7f);
    }

    void GenerateColorsGoal()
    {
        
        primaryColors.Clear();
        primaryColors.Add(colors[0]);
        primaryColors.Add(colors[1]);
        primaryColors.Add(colors[2]);

        numberPrimaryColors.Clear();
        numberPrimaryColors.Add(0);
        numberPrimaryColors.Add(1);
        numberPrimaryColors.Add(2);

        secondaryColors.Clear();
        secondaryColors.Add(colors[3]);
        secondaryColors.Add(colors[4]);
        secondaryColors.Add(colors[5]);

        numberSecondaryColors.Clear();
        numberSecondaryColors.Add(3);
        numberSecondaryColors.Add(4);
        numberSecondaryColors.Add(5);

        tertiaryColors.Clear();
        tertiaryColors.Add(colors[6]);
        tertiaryColors.Add(colors[7]);
        tertiaryColors.Add(colors[8]);
        tertiaryColors.Add(colors[9]);
        tertiaryColors.Add(colors[10]);
        tertiaryColors.Add(colors[11]);

        numberTertiaryColors.Clear();
        numberTertiaryColors.Add(6);
        numberTertiaryColors.Add(7);
        numberTertiaryColors.Add(8);
        numberTertiaryColors.Add(9);
        numberTertiaryColors.Add(10);
        numberTertiaryColors.Add(11);

        if (gridColors.Count != 0)
        {
            if (!levelGenerated)
            {
                GlobalInfo.level++;                
                ShowLevel();
                //Llegim el fitxer de nivells
                if (GlobalInfo.levelNum < 1)
                {
                    Levels.LoadLevel(1);
                }
                else
                {
                    GameObject[] goals;
                    goals = GameObject.FindGameObjectsWithTag("Goal");
                    foreach (GameObject goal in goals)
                    {
                        Destroy(goal);
                    }
                    Levels.LoadLevel(GlobalInfo.levelNum);
                }

                //Comencem a generar els nivells segons el nombre de grids
                if (GlobalInfo.numberGrids == 2)
                {
                    if (GlobalInfo.GoalType1 == "PRI")
                    {
                        PRIColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType1 == "SEC")
                    {
                        SECColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType2 == "PRI")
                    {
                        PRIColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType2 == "SEC")
                    {
                        SECColors(1, GlobalInfo.GoalNum2);
                    }
                    //Omplin les 3 caselles buides
                    for (int i = 2; i < 5; i++)
                    {
                        BlankGrid(i);
                    }
                }
                if (GlobalInfo.numberGrids == 3)
                {
                    if (GlobalInfo.GoalType1 == "PRI")
                    {
                        PRIColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType1 == "SEC")
                    {
                        SECColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType2 == "PRI")
                    {
                        PRIColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType2 == "SEC")
                    {
                        SECColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType3 == "PRI")
                    {
                        PRIColors(2, GlobalInfo.GoalNum3);
                    }

                    if (GlobalInfo.GoalType3 == "SEC")
                    {
                        SECColors(2, GlobalInfo.GoalNum3);
                    }
                    //Omplin les 3 caselles buides
                    for (int i = 3; i < 5; i++)
                    {
                        BlankGrid(i);
                    }
                }
                if (GlobalInfo.numberGrids == 4)
                {
                    if (GlobalInfo.GoalType1 == "PRI")
                    {
                        PRIColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType1 == "SEC")
                    {
                        SECColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType2 == "PRI")
                    {
                        PRIColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType2 == "SEC")
                    {
                        SECColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType3 == "PRI")
                    {
                        PRIColors(2, GlobalInfo.GoalNum3);
                    }

                    if (GlobalInfo.GoalType3 == "SEC")
                    {
                        SECColors(2, GlobalInfo.GoalNum3);
                    }
                    if (GlobalInfo.GoalType4 == "PRI")
                    {
                        PRIColors(3, GlobalInfo.GoalNum4);
                    }
                    if (GlobalInfo.GoalType4 == "SEC")
                    {
                        PRIColors(3, GlobalInfo.GoalNum4);
                    }
                    for (int i = 4; i < 5; i++)
                    {
                        BlankGrid(i);
                    }
                }
                if (GlobalInfo.numberGrids == 5)
                {
                    if (GlobalInfo.GoalType1 == "PRI")
                    {
                        PRIColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType1 == "SEC")
                    {
                        SECColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType1 == "TER")
                    {
                        TERColors(0, GlobalInfo.GoalNum1);
                    }
                    if (GlobalInfo.GoalType2 == "PRI")
                    {
                        PRIColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType2 == "SEC")
                    {
                        SECColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType2 == "TER")
                    {
                        TERColors(1, GlobalInfo.GoalNum2);
                    }
                    if (GlobalInfo.GoalType3 == "PRI")
                    {
                        PRIColors(2, GlobalInfo.GoalNum3);
                    }
                    if (GlobalInfo.GoalType3 == "SEC")
                    {
                        SECColors(2, GlobalInfo.GoalNum3);
                    }
                    if (GlobalInfo.GoalType3 == "TER")
                    {
                        TERColors(2, GlobalInfo.GoalNum3);
                    }
                    if (GlobalInfo.GoalType4 == "PRI")
                    {
                        PRIColors(3, GlobalInfo.GoalNum4);
                    }
                    if (GlobalInfo.GoalType4 == "SEC")
                    {
                        SECColors(3, GlobalInfo.GoalNum4);
                    }
                    if (GlobalInfo.GoalType4 == "TER")
                    {
                        TERColors(3, GlobalInfo.GoalNum4);
                    }
                    if (GlobalInfo.GoalType5 == "PRI")
                    {
                        PRIColors(4, GlobalInfo.GoalNum5);
                    }
                    if (GlobalInfo.GoalType5 == "SEC")
                    {
                        SECColors(4, GlobalInfo.GoalNum5);
                    }
                    if (GlobalInfo.GoalType5 == "TER")
                    {
                        TERColors(4, GlobalInfo.GoalNum5);
                    }
                }
                levelGenerated = true;
            }
            GenerateLevel();
        }
    }

    void GenerateLevel()
    {
        count++;
        if (count % 2 == 0)
        {
            //GameObject.Find("UIController").GetComponent<PlayEffects>().NewColorSound1();
        } else
        {
            //GameObject.Find("UIController").GetComponent<PlayEffects>().NewColorSound2();
        }        
        
        //Fem una llista per posar els colors del array
        List<Sprite> getPrimaryColors = new List<Sprite>();
        for (int i = 0; i < 3; i++)
        {
            getPrimaryColors.Add(colors[i]);
        }

        int colored = Random.Range(0, gridColors.Count);
        int coloring = Random.Range(0, getPrimaryColors.Count);
        gridColors[colored].GetComponentInChildren<Cell>().isColored = true;
        gridColors[colored].GetComponentInChildren<SpriteRenderer>().sprite = getPrimaryColors[coloring];
        gridColors[colored].GetComponentInChildren<Cell>().color = coloring;
        RemoveGridColored();
    }

    void RemoveGridColored()
    {
        for (int i = 0; i < gridColors.Count; i++)
        {
            if (gridColors[i].GetComponentInChildren<Cell>().isColored)
            {
                gridColors.Remove(gridColors[i]);
            }
        }
        AddGridNoColored();
    }

    void AddGridNoColored()
    {
        for (int i = 1; i < 26; i++)
        {
            if (!GameObject.Find("Cell" + i).GetComponentInChildren<Cell>().isColored)
            {
                if (!gridColors.Contains(GameObject.Find("Cell" + i)))
                {
                    gridColors.Add(GameObject.Find("Cell" + i));
                }
            }
        }
    }

    void PRIColors(int position, int goalNum)
    {
        //Generem un numero aleatori entre els colors primaris per asignar-lo
        int color = Random.Range(0, primaryColors.Count);
        colorBloc.GetComponent<Transform>().localScale = new Vector2(0.27f, 0.27f);
        colorBloc.GetComponent<SpriteRenderer>().sprite = primaryColors[color];
        //instantiate the game object, at position pos, with rotation set to identity
        GameObject cO = Instantiate(colorBloc, GlobalInfo.resultPositions[position], Quaternion.identity) as GameObject;
        //Asignem al script de la casella, el color i la quantitat
        cO.GetComponent<ColorGoal>().color = numberPrimaryColors[color];
        cO.GetComponent<ColorGoal>().quantity = goalNum;
        //coloquem GridResult com a pare
        cO.transform.parent = parentColorBlocs.transform;
        //Treiem el color de la llista perque no es repeteixi en el nivell actual
        primaryColors.Remove(primaryColors[color]);
        numberPrimaryColors.Remove(numberPrimaryColors[color]);
    }

    void SECColors(int position, int goalNum)
    {
        //Generem un numero aleatori entre els colors secundaris per asignar-lo
        int color = Random.Range(0, secondaryColors.Count);
        colorBloc.GetComponent<Transform>().localScale = new Vector2(0.27f, 0.27f);
        colorBloc.GetComponent<SpriteRenderer>().sprite = secondaryColors[color];
        //instantiate the game object, at position pos, with rotation set to identity
        GameObject cO = Instantiate(colorBloc, GlobalInfo.resultPositions[position], Quaternion.identity) as GameObject;
        //Asignem al script de la casella, el color i la quantitat
        cO.GetComponent<ColorGoal>().color = numberSecondaryColors[color];
        cO.GetComponent<ColorGoal>().quantity = goalNum;
        //coloquem GridResult com a pare
        cO.transform.parent = parentColorBlocs.transform;
        //Treiem el color de la llista perque no es repeteixi en el nivell actual
        secondaryColors.Remove(secondaryColors[color]);
        numberSecondaryColors.Remove(numberSecondaryColors[color]);
    }

    void TERColors(int position, int goalNum)
    {
        //Generem un numero aleatori entre els colors terciaris per asignar-lo
        int color = Random.Range(0, tertiaryColors.Count);
        colorBloc.GetComponent<Transform>().localScale = new Vector2(0.27f, 0.27f);
        colorBloc.GetComponent<SpriteRenderer>().sprite = tertiaryColors[color];
        //instantiate the game object, at position pos, with rotation set to identity
        GameObject cO = Instantiate(colorBloc, GlobalInfo.resultPositions[position], Quaternion.identity) as GameObject;
        //Asignem al script de la casella, el color i la quantitat
        cO.GetComponent<ColorGoal>().color = numberTertiaryColors[color];
        cO.GetComponent<ColorGoal>().quantity = goalNum;
        //coloquem GridResult com a pare
        cO.transform.parent = parentColorBlocs.transform;
        //Treiem el color de la llista perque no es repeteixi en el nivell actual
        tertiaryColors.Remove(tertiaryColors[color]);
        numberTertiaryColors.Remove(numberTertiaryColors[color]);
    }

    void BlankGrid(int position)
    {
        //Generem un numero aleatori entre els colors secundaris per asignar-lo
        //int color = Random.Range(0, secondaryColors.Count);
        colorBloc.GetComponent<Transform>().localScale = new Vector2(0.53f, 0.53f);
        colorBloc.GetComponent<SpriteRenderer>().sprite = blankCell;

        //instantiate the game object, at position pos, with rotation set to identity
        Vector3 newPosition = new Vector3(GlobalInfo.resultPositions[position].x, GlobalInfo.resultPositions[position].y - 0.01f, GlobalInfo.resultPositions[position].z);
        GameObject cO = Instantiate(colorBloc, newPosition, Quaternion.identity) as GameObject;

        //Asignem al script de la casella, el color i la quantitat
        cO.GetComponent<ColorGoal>().color = 10;
        cO.GetComponent<ColorGoal>().quantity = 1;
        //coloquem GridResult com a pare
        cO.transform.parent = parentColorBlocs.transform;
    }

    public void ResetGrid(string name)
    {
        GameObject.Find(name).GetComponentInChildren<SpriteRenderer>().sprite = cellEmpty;
        GameObject.Find(name).GetComponentInChildren<Cell>().color = 20;
        GameObject.Find(name).GetComponentInChildren<Cell>().isColored = false;
    }

    public void ChangeColor(string nameGrid, Sprite newSprite, int newColorNumber)
    {
        GameObject.Find(nameGrid).GetComponentInChildren<SpriteRenderer>().sprite = newSprite;
        GameObject.Find(nameGrid).GetComponentInChildren<Cell>().newColor = false;
        GameObject.Find(nameGrid).GetComponentInChildren<Cell>().originalSprite = null;
        GameObject.Find(nameGrid).GetComponentInChildren<Cell>().color = newColorNumber;
    }
}
