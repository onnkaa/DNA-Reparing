using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool winColor = false;

    public Transform parent;

    GameObject molecule;
    Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        

    }
    

    private Rigidbody rigidBody;
    private Vector3 clickStartPos;
    private Vector3 clickSwipeStartPos;
    

    // Update is called once per frame
    void Update()
    {
        if (!winColor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickStartPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                var delta = new Vector3(0f, clickStartPos.x - Input.mousePosition.x, 0f);

                if (molecule != null)
                    delta *= 0.3f;
                rigidBody.AddTorque(delta);
            }

            if (Input.GetMouseButtonDown(0))
            {
                PickMolecule();
            }



            if (molecule != null && Input.GetMouseButton(0))
            {
                var mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f);
                var mousePosition = Camera.main.ScreenToWorldPoint(mousePos);
                molecule.transform.position = mousePosition;
            }

            if (molecule != null && Input.GetMouseButtonUp(0))
            {
                var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(mousePosition, out RaycastHit hitObject))
                {
                    if (hitObject.collider.tag == "molecule")
                    {
                        molecule.transform.SetParent(parent);
                        molecule.transform.localPosition = hitObject.collider.transform.localPosition;
                        hitObject.collider.transform.localPosition = originalPosition;
                    }
                }
                else
                {
                    molecule.transform.SetParent(parent);
                    molecule.transform.localPosition = originalPosition;
                }
                molecule.gameObject.GetComponent<SphereCollider>().isTrigger = false;
                molecule = null;
            }
        }
        
    }

    public void PickMolecule()
    {
        var mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

        ////Debug.DrawLine(mousePosition.origin, mousePosition.origin + (mousePosition.direction * 100f), Color.red, 2f);

        if (Physics.Raycast(mousePosition, out RaycastHit hitObject))
        {
            //Debug.Log("pick" + hitObject.collider.gameObject.name);
            if (hitObject.collider.tag == "molecule")
            {
                molecule = hitObject.collider.gameObject;
                hitObject.collider.isTrigger = true;
                originalPosition = hitObject.collider.transform.localPosition;
                hitObject.transform.SetParent(null);
            }
            
        }
    }
   
}
