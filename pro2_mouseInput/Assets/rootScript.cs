using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.EventSystems.EventTrigger))]
public class rootScript : MonoBehaviour {

	// Use this for initialization
	public GameObject g_BG;
	public GameObject g_BGShow;
	// public EasyTween[] theTween;
	int beenClicked=0;

	// imgScript myImgScript = new imgScript();
	string[] fileName = {
		"almond-1201795_640", "bee-on-cherry-blossoms-1403010_640", "checkered-butterfly-1472687_640", "cosmea-1396842_640",
		"dandelion-1346727_640", "drip-1972411_640", "flower-139237_640", "flower-624974_640",
		"mushrooms-2212899_640", "tomatoes-1561565_640", "n (1)", "n (2)",
		"n (3)", "n (4)", "n (5)", "n (6)",
		"n (7)", "n (8)", "n (9)", "n (10)"
	};

	public Image imageChange;
	public Text showContent;
	void Start(){
		g_BG.SetActive(false);
		g_BGShow.SetActive(false);
		// imageChange.sprite = Resources.Load<Sprite>(fileName[0]);
	}
	void Update(){

	}

	public void enter(){

		// g_BGShow.SetActive(true);
		print("who: " + beenClicked);
		mainScript.b_Clicked = true;
		
		string tmp = fileName[beenClicked-1];
		imageChange.sprite = Resources.Load<Sprite>(tmp);
		
	} 

	public void closeBG(){
		g_BG.SetActive(false);
		g_BGShow.SetActive(false);
		mainScript.b_Clicked = false;
		// showImage.SetActive(false);
	}

	public void callBtn1(){
		beenClicked=1;
		showContent.text = "Title: 櫻花 \n almond-1201795_640";
	}
	public void callBtn2(){
		beenClicked=2;
	}
	public void callBtn3(){
		beenClicked=3;
	}
	public void callBtn4(){
		beenClicked=4;
	}
	public void callBtn5(){
		beenClicked=5;
	}
	public void callBtn6(){
		beenClicked=6;
	}
	public void callBtn7(){
		beenClicked=7;
	}
	public void callBtn8(){
		beenClicked=8;
	}
	public void callBtn9(){
		beenClicked=9;
	}
	public void callBtn10(){
		beenClicked=10;
	}
	public void callBtn11(){
		beenClicked=11;
	}
	public void callBtn12(){
		beenClicked=12;
	}
	public void callBtn13(){
		beenClicked=13;
	}
	public void callBtn14(){
		beenClicked=14;
	}
	public void callBtn15(){
		beenClicked=15;
	}
	public void callBtn16(){
		beenClicked=16;
	}
	public void callBtn17(){
		beenClicked=17;
	}
	public void callBtn18(){
		beenClicked=18;
	}
	public void callBtn19(){
		beenClicked=19;
	}
	public void callBtn20(){
		beenClicked=20;
	}


    // public IEnumerator animBtn1()
    // {
	// 	print("show");
    //     theTween[0].OpenCloseObjectAnimation();
    //     yield return new WaitForSecondsRealtime(0.5f);
    // }
}
