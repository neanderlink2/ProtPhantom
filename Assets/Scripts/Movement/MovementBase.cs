using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovementBase : MonoBehaviour, IMovimentavel
{
    private Rigidbody m_rigid;
    [SerializeField]
    private float m_vel = 5f, m_forcaPulo = 10f, m_velocidadeRotacao = 10f;

    public float Velocidade
    {
        get { return m_vel; }
        set { m_vel = value; }
    }

    public float ForcaPulo { get { return ForcaPulo; } set { ForcaPulo = value; } }

    public void Start ()
    {
        m_rigid = GetComponent<Rigidbody>();
    }
  
    private void Rotacionar(Vector3 direcao)
    {
        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            var dirCam = Quaternion.LookRotation(Camera.main.transform.TransformDirection(direcao));
            var rot = Quaternion.Lerp(transform.rotation, dirCam, m_velocidadeRotacao * Time.deltaTime);

            rot.x = transform.rotation.x;
            rot.z = transform.rotation.z;
            transform.rotation = rot;
        }
    }

    public void Mover(Vector3 direcao)
    {
        var newVelocity = Camera.main.transform.TransformDirection(direcao).normalized * m_vel;        
        newVelocity.y = m_rigid.velocity.y;
        
        m_rigid.velocity = newVelocity;

        Rotacionar(direcao);
    }

    public void MoverPlayer(Vector3 direcao)
    {
        var newVelocity = Camera.main.transform.TransformDirection(direcao).normalized * m_vel;

        if (direcao.z != 0 && newVelocity.z < (m_vel*0.9f))
        {
            newVelocity = transform.forward * m_vel;
        }

        newVelocity.y = m_rigid.velocity.y;

        m_rigid.velocity = newVelocity;

        Rotacionar(direcao);
    }

    public void Pular()
    {
        m_rigid.AddForce(transform.up * m_forcaPulo, ForceMode.Impulse);
    }
}

