using IServiceLogging;
using System;
using System.Globalization;

namespace EAA103 
{
    public class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = new CultureInfo("pt-BR");

            var repositories = new IRepositoryQuery();

            try
            {
                if (args == null || args.Length == 0)
                {
                    var message = $"Nenhum argumento encontrado para o processamento.";
                    RegistraLog.Log(message);
                    throw new ArgumentException(message);
                }

                var CODOPE = -1;

                if (!int.TryParse(args[0], out CODOPE))
                {
                    var message = $"Falha ao converter argumento recebido. O argumento informado deve ser um número inteiro válido. Argumento recebido {args[0]}.";
                    RegistraLog.Log(message);
                    throw new Exception(message);
                }

                if (CODOPE > 0)
                {
                    var message = "";

                    message = $"O CODOPE utilizado é: {CODOPE}.";
                    RegistraLog.Log(message);

                    var codigo = repositories.ExecutaPrograma(CODOPE);

                }

            }
            catch (Exception ex)
            {
                var message = "Falha crítica na aplicação.";
                RegistraLog.Log(message);
            }

        }
    }
}
