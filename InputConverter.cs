using UnityEngine;
using TMPro;
using System;

public class InputConverter : MonoBehaviour
{
    [SerializeField] private TMP_Text _wrongMessage;
    [SerializeField] private TMP_InputField _inputField;

    public static Action<int> OnConverted;

    private void OnEnable()
    {
        _inputField.onValueChanged.AddListener(Convert);
        _inputField.onEndEdit.AddListener(Convert);
    }

    private void OnDisable()
    {
        _inputField.onValueChanged?.RemoveListener(Convert);
        _inputField.onEndEdit?.RemoveListener(Convert);
    }

    public void Convert(string input)
    {
        if (int.TryParse(input, out var result))
        {   
            if (result < 0)
            {
                _wrongMessage.text = $"The number can not be negative";
                return;
            }
            _wrongMessage.text = $"{result} was created";
            if (result >= 100)
            {
                _wrongMessage.text = $"When large numbers are introduced, low frame rates may be observed";
            }
            OnConverted.Invoke(result);
        } else
        {
            if (string.IsNullOrEmpty(input))
            {
                OnConverted.Invoke(result);
            } else
            {

                _wrongMessage.text = $"Non-valid input, try another";
            }
        }
    }
}
