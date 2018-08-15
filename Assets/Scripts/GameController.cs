using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text questionText;
    public SimpleObjectPool answerButGoPool;
    public Transform answerButParent;
    public Text timeDisplay, scoreDisplay;
    public GameObject roundOverPanel, questionPanel;
    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;

    private bool isRoundActive;
    private float timeRemaing;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButGos = new List<GameObject>();
	void Start () {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaing = currentRoundData.timeLimitInScends;
        UpdataTimeRemaingDis();
        ShowQuestion();
        playerScore = 0;
        questionIndex = 0;
        isRoundActive = true;
	}
	
	// Update is called once per frame
	private void ShowQuestion () {
        RemoveAnswerQuestion();
        QuestionData questionData = questionPool[questionIndex];
        questionText.text = questionData.questionText;
        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButGo = answerButGoPool.GetObject();
            answerButGo.transform.SetParent(answerButParent);
            answerButGos.Add(answerButGo);
            AnswerButton answerBut = answerButGo.GetComponent<AnswerButton>();
            answerBut.SetUp(questionData.answers[i]);
        }
    }

    private void RemoveAnswerQuestion(){
        while (answerButGos.Count>0)
        {
            answerButGoPool.ReturnObject(answerButGos[0]);
            answerButGos.RemoveAt(0);
        }
    }
    public void AnswerButClick(bool isCorrect){
        if (isCorrect)
        {
            playerScore += currentRoundData.pointAddedFoCorrectAnswer;
            scoreDisplay.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length>questionIndex+1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            EndRound();
        }
    }
    public void EndRound(){
        isRoundActive = false;
        questionPanel.SetActive(false);
        roundOverPanel.SetActive(true);
    }
    public void ReturenToMenu(){
        SceneManager.LoadScene("MenuScreen");
    }
    public void UpdataTimeRemaingDis(){
        timeDisplay.text = "Time:  " + Mathf.Round(timeRemaing).ToString();
    }

	private void Update()
	{
        if (isRoundActive)
        {
            timeRemaing -= Time.deltaTime;
            UpdataTimeRemaingDis();
            if (timeRemaing <=0)
            {
                EndRound();
            }
        }
	}
}
