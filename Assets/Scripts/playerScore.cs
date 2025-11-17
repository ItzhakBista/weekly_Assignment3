using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class playerScore : MonoBehaviour
{
    private int number;

    public int GetNumber()
    {
        return this.number;
    }

    public void SetNumber(int newNumber)
    {
        this.number = newNumber;
        GetComponent<TextMeshProUGUI>().text = newNumber.ToString();
    }

    public void AddNumber(int toAdd)
    {
        SetNumber(this.number + toAdd);
    }
    
}
