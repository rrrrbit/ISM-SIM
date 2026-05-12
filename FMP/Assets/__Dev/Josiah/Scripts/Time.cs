using UnityEngine;

public class Time : MonoBehaviour
{
    public AnimationCurve bulletTimeScale;
    bool m_IsusingBulletTime;
    float m_UnscaledElapsedTime;
    public void StartBulletTime()
    {
        m_UnscaledElapsedTime = 0f; ;
        m_IsusingBulletTime = true;
    }
    

    void Update()
    {
        if (m_IsusingBulletTime)
        {
            print("Time is valid");
            while (true)
            {

            }


        }
    }   
}
