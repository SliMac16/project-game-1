using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject player;
    public GameObject healthBar;
    public GameObject scoreText2;
    private AudioManager audioManager;
    private Health playerH;

    
    
    public bool isGameActive;
    private int score;
    

    private float spawnRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        playerH = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        bool restart = Input.GetKeyDown(KeyCode.R);
        if (restart && !isGameActive)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            player.SetActive(true);
            healthBar.SetActive(true);
            scoreText2.SetActive(true);
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart");
    }
    public void GameOver()
    {
        if (playerH.playerHealth < 0)
        {
            isGameActive = false;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            audioManager.Stop("Theme");
            player.SetActive(false);
            healthBar.SetActive(false);
            
        }
        
       
        else
       
            isGameActive = true;
        
    }
    public void StartGame()
    {
        isGameActive = true;
        audioManager.Play("Theme");
        score = 0;
        
        StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
        

    }

}
