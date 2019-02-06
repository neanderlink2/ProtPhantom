using Assets.Scripts.Player;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Util
{
    public static class MyCanvas
    {
        public static Text TxtInteracao => GameObject.Find("Canvas")
            .GetComponentsInChildren<Text>()
            .FirstOrDefault(x => x.name.Equals("TxtInteracao"));

        public static RectTransform CaixaMensagem => GameObject.Find("Canvas")
            .transform.Find("CaixaDeMensagem")
            .GetComponent<RectTransform>();

        public static void MostrarMensagem(string mensagem)
        {
            var caixa = CaixaMensagem;
            caixa.GetComponentInChildren<Text>()
                .text = mensagem;

            caixa.gameObject.SetActive(true);
        }

        public static RectTransform PainelInventarioItens => GameObject.Find("Canvas_Inventario")
            .transform.Find("PainelItems")
            .GetComponent<RectTransform>();

        public static RectTransform PainelItens => GameObject.Find("Canvas_Inventario")
            .transform.Find("Principal")
            .Find("PainelItems")
            .Find("Viewport")
            .Find("Content")
            .GetComponent<RectTransform>();

        public static void EsconderTexto()
        {
            CaixaMensagem.gameObject.SetActive(false);
        }
    }
}
