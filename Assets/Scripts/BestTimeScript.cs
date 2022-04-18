using UnityEngine;
using TMPro;

public class BestTimeScript : MonoBehaviour
{
    private float _bestTime;

    public TMP_Text timeText;

    void Start()
    {
        _bestTime = PlayerPrefs.GetFloat("BestTime");

        if (_bestTime != 0)
        {
            timeText.text = _bestTime.ToString("0.00");
        }
        else
        {
            timeText.text = "Вы еще не играли";
        }
    }

}
