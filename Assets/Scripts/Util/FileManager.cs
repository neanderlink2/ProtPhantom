using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Util
{
    public static class FileManager
    {
        public readonly static string PATH_SAVE_DATA_FOLDER = "";

        public static async Task SalvarJson<T>(T objeto, string nomeDoArquivo)
        {
            string str = "";
            await Task.Run(() => str = JsonUtility.ToJson(objeto));

            var caminho = Path.Combine(PATH_SAVE_DATA_FOLDER, nomeDoArquivo);

            using (var writer = new StreamWriter(caminho, false))
            {
                await writer.WriteAsync(str);
            }
        }

        public static async Task<T> LerJson<T> (string nomeDoArquivo)
        {
            var caminho = Path.Combine(PATH_SAVE_DATA_FOLDER, nomeDoArquivo);
            using (var reader = new StreamReader(caminho))
            {
                var str = await reader.ReadToEndAsync();
                return await Task.Run(() => JsonUtility.FromJson<T>(str));
            }
        }

        public static async Task LerJsonScriptable<T>(string nomeDoArquivo, T objeto) where T : ScriptableObject
        {
            var caminho = Path.Combine(PATH_SAVE_DATA_FOLDER, nomeDoArquivo);
            using (var reader = new StreamReader(caminho))
            {
                var str = await reader.ReadToEndAsync();
                await Task.Run(() => JsonUtility.FromJsonOverwrite(str, objeto));
            }
        }
    }
}
