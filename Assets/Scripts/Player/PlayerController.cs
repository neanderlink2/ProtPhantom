using Assets.Scripts.Itens.Behaviours;
using Assets.Scripts.Movement;
using Assets.Scripts.Util;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Player
{
    [RequireComponent(typeof(MovementBase))]
    public class PlayerController : MonoBehaviour
    {
        public static InventarioController Inventario => GameObject.Find("Util").GetComponent<InventarioController>();

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
            if (!Inventario.isMostrandoInventario)
            {
                CameraManager.CameraPrincipal.GetComponent<Cinemachine.CinemachineBrain>().enabled = true;
                ControlarMovimentacao();
            }else
            {
                CameraManager.CameraPrincipal.GetComponent<Cinemachine.CinemachineBrain>().enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Inventario.isMostrandoInventario)
                {
                    StartCoroutine(DescarregarCena("Inventario"));
                }
                else
                {
                    StartCoroutine(CarregarCena("Inventario"));
                }
            }
        }

        public IEnumerator CarregarCena(string cena)
        {
            var loadScene = SceneManager.LoadSceneAsync(cena, LoadSceneMode.Additive);
            loadScene.completed += (a) =>
            {
                Inventario.PopularInventario();
                Inventario.isMostrandoInventario = true;
            };
            yield return loadScene;
        }

        public IEnumerator DescarregarCena(string cena)
        {
            var loadScene = SceneManager.UnloadSceneAsync(cena);
            loadScene.completed += (a) =>
            {
                Inventario.isMostrandoInventario = false;
            };

            yield return loadScene;
        }

        public void ControlarMovimentacao()
        {
            var direcao = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            m_move.MoverPlayer(direcao);

            if (direcao.z != 0 || direcao.x != 0)
            {
                m_anim.SetFloat("Move", 1);
            }
            else
            {
                m_anim.SetFloat("Move", 0);
            }

            if (Input.GetButtonDown("Jump") && m_isGrounded)
            {
                m_anim.SetTrigger("Pulou");
                m_move.Pular();
            }
        }

        public void FixedUpdate()
        {
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
}
