using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EuroUI : MonoBehaviour
{
    public TextMeshProUGUI euroText;

    void Update()
    {
        euroText.text = "YEN: " + PlayerStats.euro;
    }
}
