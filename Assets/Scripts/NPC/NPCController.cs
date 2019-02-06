using Assets.Scripts.Player;
using Assets.Scripts.Util;
using UnityEngine;

namespace Assets.Scripts.NPC
{
    public class NPCController : MonoBehaviour
    {
        private bool m_podeConversar = false;

        public void Update()
        {
            MyCanvas.TxtInteracao.text = m_podeConversar ? "Pressione F para conversar" : "";

            if (m_podeConversar && Input.GetButtonDown("Interacao"))
            {
                if (PlayerController.Inventario.VerificarItemNoInventario("Bola amarela"))
                {
                    MyCanvas.MostrarMensagem("Então você o encontrou...");
                }
                else
                {
                    MyCanvas.MostrarMensagem("Olá, sou você só que verde.");
                }
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_podeConversar = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                m_podeConversar = false;
                MyCanvas.EsconderTexto();
            }
        }
    }
}
