using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform player1;
    public Camera m_OrthographicCamera;
    float m_ViewPositionX, m_ViewPositionY, m_ViewWidth, m_ViewHeight;
    private Vector3 scaleChange, positionChange;

    // Update is called once per frame
    void Update()
    {


        if (player && player1)
        {
            //3d midpoint (x1+x2 )/2,(y1+y2 )/2,(z1+z2 )/2

            transform.position = ((player.transform.position + player1.transform.position) / 2) + new Vector3(0, 0, -10);

            //2*Mathf.Sqrt   3+5 * Mathf.Sqrt
            float dist = 5 + (Vector3.Distance(player.transform.position, player1.transform.position)) / 2;
            m_OrthographicCamera.orthographicSize = dist ;
        }
        else if (player)
        {
            transform.position = player.transform.position + new Vector3(0, 0, -10);
            m_OrthographicCamera.orthographicSize = 5;
        }
        else if (player1)
        {
            transform.position = player1.transform.position + new Vector3(0, 0, -10);
            m_OrthographicCamera.orthographicSize = 5;
        }
        else;
    }
        
}
