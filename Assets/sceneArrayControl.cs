using UnityEngine;
using System.Collections;

public class sceneArrayControl : MonoBehaviour {


	public string determineScene(int sceneNumber)
	{
		switch (sceneNumber)
		{
		case 0:
			return "1.Introduction";
			break;
		case 1:
			return "testroom";
			break;
		case 2:
			return "Level1.2";
			break;
		case 3:
			return "4.Haemophilia";
			break;
		case 4:
			return "5.Treatment";
			break;
		case 5:
			return "6.BleedingInHaemophilia";
			break;
		case 6:
			return "7.SportAndHaemophilia";
		case 7:
			return "0.Tutorial";
			break;
		case 8:
			return "8.Conclusion";
			break;
		case 9:
			return "9.HaemophiliaV2";
			break;
		case 10:
			return "10.TreatmentV2";
			break;
		default:
			return "nil";
			print ("No scene selected");
			break;
		}
	}


}
