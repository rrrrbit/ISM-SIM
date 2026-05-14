using UnityEngine;

public class MGR_levelUI : MonoBehaviour
{
    Visual_Node selectedNode;
    public Camera uiCam;
    public Canvas canvas;
    public UI_nodeViewer nodeViewer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FocusNodeViewer(Visual_Node node)
    {
        nodeViewer.nodeIndex = node.id;
    }

    public void UnfocusNodeViewer()
    {

    }

    public void FocusIdeaViewer(Visual_Node node)
    {

    }
}
