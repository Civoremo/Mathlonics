using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnswerGenerator : MonoBehaviour {

	public Text txtBtnNum1;
	public Text txtBtnNum2;
	public Text txtBtnNum3;
	public Text txtBtnNum4;
	public Text txtAnswer;

	int[] temp = new int[3];
	int wrongRange = 42;

	public void AnswerGen()
	{
		//answer = txtAnswer.text;
		WrongAnswerGen(txtAnswer.text);
		AnswerRandomizer (txtAnswer.text);
	}

	private void AnswerRandomizer(string numStr)
	{
		int randBtn = Random.Range (0, 4);

		switch (randBtn) 
		{
		case 0:
			txtBtnNum1.text = numStr;
			txtBtnNum2.text = temp[0].ToString ();
			txtBtnNum3.text = temp[1].ToString ();
			txtBtnNum4.text = temp[2].ToString ();
			break;
		case 1:
			txtBtnNum2.text = numStr;
			txtBtnNum1.text = temp[0].ToString ();
			txtBtnNum3.text = temp[1].ToString ();
			txtBtnNum4.text = temp[2].ToString ();
			break;
		case 2:
			txtBtnNum3.text = numStr;
			txtBtnNum2.text = temp[0].ToString ();
			txtBtnNum1.text = temp[1].ToString ();
			txtBtnNum4.text = temp[2].ToString ();
			break;
		case 3:
			txtBtnNum4.text = numStr;
			txtBtnNum2.text = temp[0].ToString ();
			txtBtnNum3.text = temp[1].ToString ();
			txtBtnNum1.text = temp[2].ToString ();
			break;
		default:
			break;
		}

	}

	private void WrongAnswerGen(string s)
	{
		int ansNum;

		int.TryParse (s, out ansNum);

		for (int i = 0; i < 3; i++) 
		{
			temp [i] = Random.Range (1, wrongRange);
		}

		for (int n = 0; n < 3; n++) 
		{
			if (temp [0] == temp [1]) {
				temp [1] = Random.Range (1, wrongRange);
			}
			if (temp [0] == temp [2]) {
				temp [2] = Random.Range (1, wrongRange);
			}
			if (temp [1] == temp [2]) {
				temp [2] = Random.Range (1, wrongRange);
			}
		}

		temp [0] += ansNum;
		temp [1] += ansNum;
		temp [2] += ansNum;
	}
}
