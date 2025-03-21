using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    public GameObject object1; // Assigned to Button1
    public GameObject object2; // Assigned to Button2
    public GameObject object3; // Assigned to Button3
    public GameObject object4; // Assigned to Button4

    public void ActivateObject1()
    {
        SetActiveObject(object1);
    }

    public void ActivateObject2()
    {
        SetActiveObject(object2);
    }

    public void ActivateObject3()
    {
        SetActiveObject(object3);
    }

    public void ActivateObject4()
    {
        SetActiveObject(object4);
    }

    private void SetActiveObject(GameObject activeObject)
    {
        // Disable all objects first
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
        object4.SetActive(false);

        // Enable only the selected object
        activeObject.SetActive(true);
    }
}
