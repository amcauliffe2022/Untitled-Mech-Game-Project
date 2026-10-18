using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControl : MonoBehaviour
{
    private Camera _cam;
    private MechUnit _selected;
    

    private void Awake()
    {
       _cam = Camera.main;
    }

    private void SetSelectedUnit(MechUnit unit)
    {
        if (_selected !=null)
        {
               if(_selected.TryGetComponent(out SelectionIndicator selectionIndicator))
               {
                   selectionIndicator.SetActive(false);
               }
        }
          _selected=unit;
        if(_selected!=null)
        {
            if (_selected.TryGetComponent(out SelectionIndicator selectionIndicator))
            {
                selectionIndicator.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
           var screenPos = Mouse.current.position.ReadValue();
           Ray lRay = _cam.ScreenPointToRay(screenPos);
           if (Physics.Raycast(lRay, out RaycastHit hit))
           {
               if(hit.collider.TryGetComponent(out MechUnit unit))
               {
                   SetSelectedUnit(unit);
               }
               else
               {
                   SetSelectedUnit(null);
               }
           }
        }

        if (Mouse.current.rightButton.wasPressedThisFrame && _selected != null)
        {
            var screenPos = Mouse.current.position.ReadValue();
            Ray lRay = _cam.ScreenPointToRay(screenPos);
            if (Physics.Raycast(lRay, out RaycastHit hit))
            {
                Vector3 targetPos = hit.point;
                _selected.MoveToTarget(targetPos);
                
            }
        }
        

    }
}
