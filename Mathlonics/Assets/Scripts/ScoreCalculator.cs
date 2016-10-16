using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour {

	public RandomNumGenerator randGenScript;
	public SavePlayerProgress SPPScript = new SavePlayerProgress();

	public float scoreCorrect = 20;
	public float scoreWrong = -5;
	public float scoreTimeMulti = 25;
	public float scoreProgMulti = 1000;

	public Text txtCorrect;
	public Text txtWrong;

	public float remainTime;
	public float progAmtFilled;
	public float xpAmount;

	public Text overCorrect;
	public Text overWrong;
	public Text overProgress;
	public Text overXP;
	public Text overTime;

	public Text wonCorrect;
	public Text wonWrong;
	public Text wonProgress;
	public Text wonXP;
	public Text wonTime;

	float tempNum;
	bool run = true;

	public void ScoreFinal()
	{
		if (run)
		{
			float.TryParse (txtCorrect.text, out tempNum);
			scoreCorrect *= tempNum;

			float.TryParse (txtWrong.text, out tempNum);
			scoreWrong *= tempNum;

			remainTime = randGenScript.time;
			remainTime *= scoreTimeMulti;

			progAmtFilled = randGenScript.progBar.fillAmount;
			progAmtFilled *= scoreProgMulti;

			xpAmount = (scoreCorrect + scoreWrong + remainTime + progAmtFilled);

			SPPScript.SavePlayerSession (xpAmount);
		}
		run = false;
	}

	public void OverFinal()
	{
		ScoreFinal ();

		overCorrect.text = scoreCorrect.ToString ();
		overWrong.text = scoreWrong.ToString ();
		overProgress.text = progAmtFilled.ToString ();
		overTime.text = "0";
		overXP.text = xpAmount.ToString ();
	}

	public void WonFinal()
	{
		ScoreFinal ();

		wonCorrect.text = scoreCorrect.ToString ();
		wonWrong.text = scoreWrong.ToString ();
		wonProgress.text = progAmtFilled.ToString ();
		wonTime.text = remainTime.ToString ();
		wonXP.text = xpAmount.ToString ();
	}
}
