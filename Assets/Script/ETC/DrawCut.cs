using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class DrawCut : MonoBehaviour
{
   // public Transform boxVis;
    Vector3 pointA;
    Vector3 pointB;

    [SerializeField] private LineRenderer cutRender;
    private bool animateCut;
    public GameObject HeightRef;

    Camera cam;

    void Start() {
        cam = FindObjectOfType<Camera>();
        cutRender = GetComponent<LineRenderer>();
        cutRender.startWidth = .05f;
        cutRender.endWidth = .05f;
    }

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = HeightRef.transform.position.z;

        if (Input.GetMouseButtonDown(0))
        {
            pointA = cam.ScreenToWorldPoint(mouse);
        }

        if (Input.GetMouseButton(0))
        {
            animateCut = false;
            cutRender.SetPosition(0,pointA);
            cutRender.SetPosition(1,cam.ScreenToWorldPoint(mouse));
            cutRender.startColor = Color.gray;
            cutRender.endColor = Color.gray;
        }

        if (Input.GetMouseButtonUp(0)) {
            pointB = cam.ScreenToWorldPoint(mouse);
            CreateSlicePlane();
            cutRender.positionCount = 2;
            cutRender.SetPosition(0,pointA);
            cutRender.SetPosition(1,pointB);
            animateCut = true;
        }

        if (animateCut)
        {
            cutRender.SetPosition(0,Vector3.Lerp(pointA,pointB,1f));
        }
    }

    void CreateSlicePlane() 
    {
        Vector3 pointInPlane = (pointA + pointB) / 2;
        
        Vector3 cutPlaneNormal = Vector3.Cross((pointA-pointB),(pointA-cam.transform.position)).normalized;
        Quaternion orientation = Quaternion.FromToRotation(Vector3.up, cutPlaneNormal);
        //boxVis.rotation = orientation;
       // boxVis.localScale = new Vector3(10, 0.25f, 10);
       // boxVis.position = pointInPlane;

        
        var all = Physics.OverlapBox(pointInPlane, new Vector3(100, 0.01f, 100), orientation);
        
        //Ray ray = new Ray(pointA, (pointB - pointA).normalized);
        //var all = Physics.RaycastAll(ray);
        {
            foreach (var hit in all)
            {
                MeshFilter filter = hit.gameObject.GetComponentInChildren<MeshFilter>();

                if(filter != null)
                    if(hit.tag == "Cutable")
                        Cutter.Cut(hit.gameObject, pointInPlane, cutPlaneNormal);
            }
        }
        
    }
}
