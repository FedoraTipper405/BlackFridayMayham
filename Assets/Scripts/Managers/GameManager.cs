using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float PayCheckAmount;
    public float CustomerAmount;
    [SerializeField] private TextMeshProUGUI _payCheckText;
    [SerializeField] private TextMeshProUGUI _numberOfCustomersText;

    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;

        _payCheckText.text = ": " + PayCheckAmount.ToString();
        _numberOfCustomersText.text = ": " + CustomerAmount.ToString();
    }

    public void ReducePaycheck(float payAmount)
    {
        PayCheckAmount -= payAmount;
        _payCheckText.text = ": " + PayCheckAmount.ToString();
    }

    public void ReduceCustomerCount(float cusAmount)
    {
        CustomerAmount -= cusAmount;
        _numberOfCustomersText.text = ": " + CustomerAmount.ToString();
    }

    private void FixedUpdate()
    {
        if(CustomerAmount == 0)
        {
            SceneManager.LoadScene("WinScreen");
        }

        if (PayCheckAmount == 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }
}
