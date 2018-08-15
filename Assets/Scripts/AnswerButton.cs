using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour {
    public Text answerText;
    private AnswerData answerData;
    private GameController gameController;
	private void Start()
	{
        gameController = FindObjectOfType<GameController>();
	}
	public void SetUp (AnswerData data) {
        answerData = data;
        answerText.text = answerData.answerText;
	}
	
    public void HandClikc(){
        gameController.AnswerButClick(answerData.isCorrect);
    }
}
