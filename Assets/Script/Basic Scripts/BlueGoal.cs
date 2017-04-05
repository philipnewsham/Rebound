using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BlueGoal : MonoBehaviour
{
	public int blueScore;
    public Text score;
	void OnTriggerEnter2D(Collider2D target)
    {
		if (target.gameObject.tag == "Ball")
			blueScore += 1;

        score.text = string.Format("0{0}", blueScore);
	}
}