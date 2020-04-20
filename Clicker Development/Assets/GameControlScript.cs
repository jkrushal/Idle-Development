using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour {

	// Store panel objects
	public Button ribbonButton, ballButton, milkButton;
	public GameObject ribbonSoldText, ballSoldText, milkSoldText;
	public Text ribbonPriceText, ballPriceText, milkPriceText;

	// Game panel objects
	public GameObject hairRibbon, ballOfYarn, milk;
	public Text strokeText;
	public int strokesAmount;

	// Common variables
	private bool isRibbonSold, isBallSold, isMilkSold;
	public int ribbonPrice = 10, ballPrice = 20, milkPrice = 30;

	// Use this for initialization
	void Start () {
		// disable all achievements at the beginning
		hairRibbon.gameObject.SetActive (false);
		ballOfYarn.gameObject.SetActive (false);
		milk.gameObject.SetActive (false);

		// disable buttons in the store
		ribbonButton.interactable = false;
		ballButton.interactable = false;
		milkButton.interactable = false;

		// set text that goods are not sold yet
		ribbonSoldText.gameObject.SetActive (false);
		ballSoldText.gameObject.SetActive (false);
		milkSoldText.gameObject.SetActive (false);

		// set prices for goods
		ribbonPriceText.text = ribbonPrice.ToString() + " Strokes";
		ballPriceText.text = ballPrice.ToString() + " Strokes";
		milkPriceText.text = milkPrice.ToString() + " Strokes";
	}
	
	// Update is called once per frame
	void Update () {
		
		// display gained number of strokes
		strokeText.text = strokesAmount + " Strokes";

		// check if you have enough strokes to buy particular good
		// and it is not sold yet
		DoYouHaveEnoughStrokesToBuySmth();
					
	}

	// Increase strokes amount by 1 when kitten is clicked
	public void IncreaseStrokesAmount()
	{
		strokesAmount += 1;
	}

	// sell ribbon
	public void SellRibbon()
	{
		// put hair ribbon on kitten
		hairRibbon.gameObject.SetActive (true);
		// desrease strokes ammount by price of ribbon
		strokesAmount -= ribbonPrice;
		// set that ribbon is sold
		isRibbonSold = true;
		// display that ribbon is sold
		ribbonSoldText.gameObject.SetActive (true);
		// no need to show ribbons price any longer
		ribbonPriceText.gameObject.SetActive (false);
	}

	// sell ball
	public void SellBall()
	{
		// give a kitten a ball
		ballOfYarn.gameObject.SetActive (true);
		// desrease strokes ammount by price of ball
		strokesAmount -= ballPrice;
		// set that ball is sold
		isBallSold = true;
		// display that ball is sold
		ballSoldText.gameObject.SetActive (true);
		// no need to show balls price any longer
		ballPriceText.gameObject.SetActive (false);
	}

	// sell milk
	public void SellMilk()
	{
		// give a kitten a bowl of milk
		milk.gameObject.SetActive (true);
		// desrease strokes ammount by price of milk
		strokesAmount -= milkPrice;
		// set that milk is sold
		isMilkSold = true;
		// display that milk is sold
		milkSoldText.gameObject.SetActive (true);
		// no need to show milks price any longer
		milkPriceText.gameObject.SetActive (false);
	}

	// check if you have enough strokes to buy particular good
	// and it is not sold yet
	void DoYouHaveEnoughStrokesToBuySmth()
	{
		
		// disable buy ribbon button if strokes is not enough
		if (strokesAmount < ribbonPrice)
			ribbonButton.interactable = false;

		// disable buy ball button if strokes is not enough
		if (strokesAmount < ballPrice)
			ballButton.interactable = false;

		// disable buy milk button if strokes is not enough
		if (strokesAmount < milkPrice)
			milkButton.interactable = false;

		// if you have enough strokes and current good is not sold
		// then you can buy it
		if (!isRibbonSold && strokesAmount >= ribbonPrice)
		{
			ribbonButton.interactable = true;
		}

		if (!isBallSold && strokesAmount >= ballPrice)
		{
			ballButton.interactable = true;
		}

		if (!isMilkSold && strokesAmount >= milkPrice)
		{
			milkButton.interactable = true;
		}
	}

}
