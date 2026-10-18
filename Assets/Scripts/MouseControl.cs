using UnityEngine;
using UnityEngine.InputSystem;

public class MouseControl : MonoBehaviour
{
    private Camera _cam;
    private MechUnit _selected;
    private bool selectedUnit;

    private void Awake()
    {
       _cam = Camera.main;
       selectedUnit = false;
    }

    private void setSelectedUnit(MechUnit unit)
    {
        if (_selected !=null)
        {
               _selected.SetSelectedUnit(false);
        }
        _selected = unit;
        if(_selected!=null)
        {
            _selected.SetSelectedUnit(true);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
                   _selected = unit;
                   setSelectedUnit(unit);
               }
               else
               {
                   setSelectedUnit(null);
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
