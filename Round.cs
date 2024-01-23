using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Round : MonoBehaviour
{
    [SerializeField] private GameObject _floor;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private ObjectGeneration _objectGeneration;
    [SerializeField] private TMP_Text _text;

    private void OnTriggerEnter(Collider other)
    {
        _winPanel.SetActive(true);
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            _text.text = $"ID {ball.ID} IS WIN!";
        }
        var t = _objectGeneration.Objects;
        for (int i = 0; i < t.Count; i++)
        {
            t[i].GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        if (ObjectGeneration.CountObject < 0) return;
        var t = _objectGeneration.Objects;
        _floor.SetActive(false);
        _panel.SetActive(false);
    }
}
