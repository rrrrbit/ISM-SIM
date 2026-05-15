using UnityEngine;

public class MGR_levelUI : MonoBehaviour
{
    Visual_Node selectedNode;
    public Camera uiCam;
    public Canvas canvas;
    public UI_nodeViewer nodeViewer;
    public UI_bg bg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnfocusNodeViewer();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FocusNodeViewer(Visual_Node node)
    {
        nodeViewer.nodeIndex = node.id;
        nodeViewer.gameObject.SetActive(true);
    }

    public void UnfocusNodeViewer()
    {
        nodeViewer.nodeIndex = -1;
        nodeViewer.gameObject.SetActive(false);
    }

    public void FocusIdeaViewer(Visual_Node node)
    {

    }
}
