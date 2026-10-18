using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
    [SerializeField] private GameObject _selectedRing;
    public void SetActive(bool on)
    {
        _selectedRing.SetActive(on);
    }
}
