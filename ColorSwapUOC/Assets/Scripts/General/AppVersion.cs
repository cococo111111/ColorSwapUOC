using EasyMobile;
using UnityEngine;
using UnityEngine.UI;

public class AppVersion : MonoBehaviour {

    public Text TextVersion; 

	// Use this for initialization
	void Start ()
    {
        //GameServices.ManagedInit();
        TextVersion.text = "Version: " + Application.version;
    }
}
