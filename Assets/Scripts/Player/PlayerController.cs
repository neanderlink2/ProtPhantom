using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementBase))]
public class PlayerController : MonoBehaviour
{
    private MovementBase m_move;
    private Animator m_anim;

    private bool m_isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_move = GetComponent<MovementBase>();
    }

    public void Update()
    {
        var direcao = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        m_move.MoverPlayer(direcao);

        if (direcao.z != 0 || direcao.x != 0)
        {
            m_anim.SetFloat("Move", 1);
        }else
        {
            m_anim.SetFloat("Move", 0);
        }

        if (Input.GetKeyDown(KeyCode.F) && m_isGrounded)
        {
            m_anim.SetTrigger("Pulou");
            m_move.Pular();
        }
    }

    public void FixedUpdate()
    {
        print(m_isGrounded);
        m_anim.SetBool("NoChao", m_isGrounded);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            m_isGrounded = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            m_isGrounded = false;
        }
    }
}
