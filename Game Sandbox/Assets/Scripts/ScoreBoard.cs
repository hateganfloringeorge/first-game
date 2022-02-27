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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Diamond")
        {
            Debug.Log("Hit diamond");
            scoreNumber += 10;
            ScoreBoardText.text = scoreBoardStart + scoreNumber;
            heroController.extraJumpsValue += 1;
            Destroy(collision.gameObject);
        }
    }
}
