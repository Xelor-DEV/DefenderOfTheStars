using UnityEngine;
using UnityEngine.UI;
public class UIManagerController : MonoBehaviour
{
    public static UIManagerController Instance { get; private set; }
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject creditsMenu;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void ActiveControlsMenu()
    {
        AudioManagerController.Instance.PlaySfx(0);
        controlsMenu.SetActive(true);
        controlsMenu.GetComponent<Image>().raycastTarget = true;
    }
    public void DisableControlsMenu()
    {
        AudioManagerController.Instance.PlaySfx(0);
        controlsMenu.SetActive(false);
        controlsMenu.GetComponent<Image>().raycastTarget = false;
    }
    public void ActiveOptionsMenu()
    {
        AudioManagerController.Instance.PlaySfx(0);
        optionsMenu.SetActive(true);
        optionsMenu.GetComponent<Image>().raycastTarget = true;
    }
    public void DisableOptionsMenu()
    {
        AudioManagerController.Instance.PlaySfx(0);
        optionsMenu.SetActive(false);
        optionsMenu.GetComponent<Image>().raycastTarget = false;
    }
    public void ActiveCreditsMenu()
    {
        AudioManagerController.Instance.PlaySfx(0);
        creditsMenu.SetActive(true);
        creditsMenu.GetComponent<Image>().raycastTarget = true;
    }
    public void DisableCreditsMenu()
    {
        AudioManagerController.Instance.PlaySfx(0);
        creditsMenu.SetActive(false);
        creditsMenu.GetComponent<Image>().raycastTarget = false;
    }
}
