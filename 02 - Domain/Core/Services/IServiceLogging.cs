using System;
using System.IO;
using System.Reflection;

namespace IServiceLogging
{
    public class RegistraLog
    {
        private static string caminhoExe = string.Empty;
        private static bool tituloAdicionado = false;

        public static bool Log(string strMensagem, string strNomeArquivo = "ArquivoLog.txt")
        {
            try
            {
                caminhoExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);

                if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();
                }

                using (StreamWriter w = File.AppendText(caminhoArquivo))
                {
                    if (!tituloAdicionado)
                    {
                        w.WriteLine("**************************************************\n            LOG DE EXECUÇÃO DO EAA103            \n**************************************************");
                        tituloAdicionado = true;
                    }

                    AppendLog(strMensagem, w);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void AppendLog(string logMensagem, TextWriter txtWriter)
        {
            try
            {
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToShortDateString()} •    {logMensagem}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
