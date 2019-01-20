using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBase))]
public class PlayerController : MonoBehaviour
{
    private MovementBase m_move;

    // Start is called before the first frame update
    void Start()
    {
        m_move = GetComponent<MovementBase>();
    }

    public void Update()
    {
        var direcao = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));        
        m_move.Mover(direcao);

        if (Input.GetKeyDown(KeyCode.F))
        {
            m_move.Pular();
        }

    }
}
