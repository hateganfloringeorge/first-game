using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI ScoreBoardText;
    private int scoreNumber;
    private const string scoreBoardStart = "Score: ";
    public HeroController heroController;

    // Start is called before the first frame update
    void Start()
    {
        scoreNumber = 0;
        ScoreBoardText.text = scoreBoardStart + scoreNumber;
    }

    public void AddScore(int addedScore)
    {
        scoreNumber += addedScore;
        ScoreBoardText.text = scoreBoardStart + scoreNumber;
    }
}
