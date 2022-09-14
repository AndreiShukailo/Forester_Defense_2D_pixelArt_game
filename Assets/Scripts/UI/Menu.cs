using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private List<Button> _disabledButtons;

    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private GameObject _victoryScreen;

    [SerializeField] private PlayerData _playerData;

    private Dictionary<Button, bool> _currentInteractableState = new Dictionary<Button, bool>();

    public void Start()
    {
        foreach (var item in _disabledButtons)
        {
            _currentInteractableState.Add(item, item.interactable);
        }
    }

    public void OpenPanel(GameObject panel)
    {
        foreach (var button in _disabledButtons)
        {
            SetDisableButton(button);
        }

        _playerInput.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenDeathScreen()
    {
        foreach (var button in _disabledButtons)
        {
            SetDisableButton(button);
        }

        _playerInput.SetActive(false);
        _deathScreen.SetActive(true);
    }

    public void OpenVictoryScreen()
    {
        foreach (var button in _disabledButtons)
        {
            SetDisableButton(button);
        }

        _playerInput.SetActive(false);
        _victoryScreen.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        SetActivButton();

        _playerInput.SetActive(true);
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    private void SetDisableButton(Button button)
    {
        button.interactable = false;
    }

    private void SetActivButton()
    {
        foreach (var item in _currentInteractableState)
        {
            item.Key.interactable = item.Value;
        }
    }

    public void RestartGame()
    {
        _playerData.ResetStats();
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
