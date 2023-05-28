using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    public int score;
    private int boardSize = Menu.gameSize; // Добавлено новое поле для хранения размера поля

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        SetScore(0);
        hiscoreText.text = LoadHiscore(boardSize).ToString();

        gameOver.alpha = 0f;
        gameOver.interactable = false;

        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = to;
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    public void SetScore(int score)
    {
        this.score = score;

        scoreText.text = score.ToString();

        SaveHiscore(boardSize);
    }

    public void SaveHiscore(int boardSize) // Добавлен аргумент для указания размера поля
    {
        int hiscore = LoadHiscore(boardSize);

        if (score > hiscore)
        {
            PlayerPrefs.SetInt(GetHiscoreKey(boardSize), score);
        }
    }

    private int LoadHiscore(int boardSize) // Добавлен аргумент для указания размера поля
    {
        return PlayerPrefs.GetInt(GetHiscoreKey(boardSize), 0);
    }

    private string GetHiscoreKey(int boardSize) // Новый метод для создания ключа наивысшего балла
    {
        return "hiscore_" + boardSize.ToString();
    }
}
