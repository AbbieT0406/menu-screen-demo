using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{

    [System.Serializable]public class game
    {
        public string gameName;
        public string gamedescription;
        public Sprite gameImage;
    }

    [SerializeField] private game[] gameInfo;
    [SerializeField] private GameObject gameDisplayPannel;
    [SerializeField] private Image gameImagePannel;
    [SerializeField] private TMP_Text gameTitle;
    [SerializeField] private TMP_Text gameDescription;


    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform buttonList;
    [SerializeField] private int numberOfButtons = 12;
    private List<Button> buttons = new List<Button>();



    // Start is called before the first frame update
    void Start()
    {
        populateGamesList();

        if (gameDisplayPannel != null)
        {
            gameDisplayPannel.SetActive(true);
        }
    }

    void populateGamesList()
    {
        
        
        for (int i = 0; i < numberOfButtons; i++)
        {
            GameObject gameButton = Instantiate(buttonPrefab, buttonList);
            int gameIndex = i;
            Button button = gameButton.GetComponent<Button>();
            buttons.Add(button);

            TextMeshProUGUI buttonText = gameButton.GetComponentInChildren<TextMeshProUGUI>(true);
            if (buttonText != null)
            {
                buttonText.text = ($"game {i + 1}");
            }

            button.onClick.AddListener(() => onGameButtonClick(gameIndex));
        }

    }

    void clearPannel()
    {
        if (gameTitle != null) gameTitle.gameObject.SetActive(false);
        if (gameDescription != null) gameDescription.gameObject.SetActive(false);
        if (gameImagePannel != null) gameImagePannel.gameObject.SetActive(false);
    }
    void showGameInfoPannel(int gameIndex)
    {
        if (gameTitle != null)
            gameTitle.text = gameInfo[gameIndex].gameName;

        if (gameDescription != null)
            gameDescription.text = gameInfo[gameIndex].gamedescription;

        if (gameImagePannel != null && gameInfo[gameIndex].gameImage != null)
            gameImagePannel.sprite = gameInfo[gameIndex].gameImage;

        // Show the panel
        gameDisplayPannel.SetActive(true);
    }

    void hideGameInfoPannel()
    {
        if (gameDisplayPannel != null)
        {
            gameDisplayPannel .SetActive(false);
        }
    }

    void onGameButtonClick(int gameIndex)
    {
        showGameInfoPannel(gameIndex);
    }

    void gameSelection()
    {

    }



    void Update()
    {

    }
}



