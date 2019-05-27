using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyMobile;
using I2.Loc;

public class Rating : MonoBehaviour
{
    public static Rating Instance;
    public string YOUR_LOCALIZED_TITLE;
    public string YOUR_LOCALIZED_MESSAGE;
    public string YOUR_LOCALIZED_LOW_RATING_MESSAGE;
    public string YOUR_LOCALIZED_HIGH_RATING_MESSAGE;
    public string YOUR_LOCALIZED_POSTPONE_BUTTON_LABEL;
    public string YOUR_LOCALIZED_REFUSE_BUTTON_LABEL;
    public string YOUR_LOCALIZED_RATE_BUTTON_LABEL;
    public string YOUR_LOCALIZED_CANCEL_BUTTON_LABEL;
    public string YOUR_LOCALIZED_FEEDBACK_BUTTON_LABEL;
    public GameObject texto1;
    public GameObject texto2;
    public GameObject texto3;
    public GameObject texto4;
    public GameObject texto5;
    public GameObject texto6;
    public GameObject texto7;
    public GameObject texto8;
    public GameObject texto9;

    private void Awake()
    {
        Instance = this; 
        //texto1.GetComponent<Text>().text= YOUR_LOCALIZED_TITLE;
        //texto2.GetComponent<Text>().text = YOUR_LOCALIZED_MESSAGE;
        //texto3.GetComponent<Text>().text = YOUR_LOCALIZED_LOW_RATING_MESSAGE;
        //texto4.GetComponent<Text>().text = YOUR_LOCALIZED_HIGH_RATING_MESSAGE;
        //texto5.GetComponent<Text>().text = YOUR_LOCALIZED_POSTPONE_BUTTON_LABEL;
        //texto6.GetComponent<Text>().text = YOUR_LOCALIZED_REFUSE_BUTTON_LABEL;
        //texto7.GetComponent<Text>().text = YOUR_LOCALIZED_RATE_BUTTON_LABEL;
        //texto8.GetComponent<Text>().text = YOUR_LOCALIZED_CANCEL_BUTTON_LABEL;
        //texto9.GetComponent<Text>().text = YOUR_LOCALIZED_FEEDBACK_BUTTON_LABEL;
    }

    public void RatingApp()
    {

        // Create a RatingDialogContent object to hold the translated content of the dialog
        var localized = new RatingDialogContent(
                    texto1.GetComponent<Text>().text + RatingDialogContent.PRODUCT_NAME_PLACEHOLDER,
                    texto2.GetComponent<Text>().text + RatingDialogContent.PRODUCT_NAME_PLACEHOLDER + "?",
                    texto3.GetComponent<Text>().text,
                    texto4.GetComponent<Text>().text,
                    texto5.GetComponent<Text>().text,
                    texto6.GetComponent<Text>().text,
                    texto7.GetComponent<Text>().text,
                    texto8.GetComponent<Text>().text,
                    texto9.GetComponent<Text>().text
                );

        // Show the rating popup with the localized texts
        StoreReview.RequestRating(localized);
    }
}
