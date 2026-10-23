using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class MouseControl : MonoBehaviour
{
    private Camera _cam;
    private List<MechUnit> _selected = new ();
    

    private void Awake()
    {
       _cam = Camera.main;
    }

    private void AddSelectedUnit(MechUnit unit)
    {
        if (_selected.Contains(unit))
        {
            return;
        }
        _selected.Add(unit);
        unit.SetSelected(true);
    }

    private void RemoveSelectedUnit(MechUnit unit)
    {
        if (_selected.Contains(unit))
        {
            _selected.Remove(unit);
            unit.SetSelected(false);
        }
    }

    private void ClearSelected()
    {
        foreach (var unit in _selected)
        {
            unit.SetSelected(false);
        }
        _selected.Clear();
    }
    // Update is called once per frame
    void Update()
    {
        bool shifted = Keyboard.current.shiftKey.isPressed;
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
           var screenPos = Mouse.current.position.ReadValue();
           Ray lRay = _cam.ScreenPointToRay(screenPos);
           if (Physics.Raycast(lRay, out RaycastHit hit) && hit.collider.TryGetComponent(out MechUnit unit))
           {
                   if (shifted && !_selected.Contains(unit))
                   {
                       AddSelectedUnit(unit);
                   }
                   else if (shifted && _selected.Contains(unit))
                   {
                       RemoveSelectedUnit(unit);
                   }
                   else
                   {
                       ClearSelected();
                       AddSelectedUnit(unit);
                   }
           }
           else if(!shifted)
           {
               ClearSelected();
           }
        }

        if (Mouse.current.rightButton.wasPressedThisFrame && _selected.Count > 0)
        {
            var screenPos = Mouse.current.position.ReadValue();
            Ray lRay = _cam.ScreenPointToRay(screenPos);
            if (Physics.Raycast(lRay, out RaycastHit hit))
            {
                Vector3 targetPos = hit.point;
                foreach (var unit in _selected)
                {
                    unit.MoveToTarget(targetPos);
                }
            }
        }
        

    }
}
