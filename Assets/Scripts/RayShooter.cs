using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    // Start is called before the first frame update

    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    Debug.Log("Target Hit!");
                    target.reactToHit();
                }
                else
                {
                    StartCoroutine(sphereIndicator(hit.point));
                }

            }
                
        }
    }

    private IEnumerator sphereIndicator(Vector3 pos)
    {
        GameObject bulletHoles = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bulletHoles.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(bulletHoles);
    }
}
