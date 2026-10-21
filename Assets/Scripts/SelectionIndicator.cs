using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _selectedRing;
    public void SetVisible(bool on)
    {
        _selectedRing.SetActive(on);
    }
}
