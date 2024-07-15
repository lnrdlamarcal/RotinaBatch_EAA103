using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Dynamic;
using IServiceLogging;


public class IRepositoryQuery : ConexaoBD
{
    public int ExecutaPrograma(int args)
    {
        string sql = new IServiceSql().BuscaValor();
        databaseCommand = db.GetSqlStringCommand(sql);
        var codigo = 0;

        try
        {
            this.db.AddInParameter(databaseCommand, ":CODGRPCTC", DbType.Int32, args);
            var reader = db.ExecuteReader(databaseCommand);
            var count = 0;

            while (reader.Read())
            {
                codigo = reader.GetInt32(0);
                RegistraLog.Log($"Iniciando a execução da Query: {codigo}");
                var query = BuscaQuery(codigo);
                ExecutaQuery(query);
                count++;
            }

            if (count == 0)
            {
                RegistraLog.Log("Não foi encontrado queries para serem executadas.");
                return 0;
            }
            return 0;
        }
        catch (Exception ex)
        {
            RegistraLog.Log("Falha crícita na execução.");
            return 0;
        }
    }

    public string BuscaQuery(int codigo)
    {
        string sql = new IServiceSql().BuscaQuery();
        databaseCommand = db.GetSqlStringCommand(sql);

        try
        {
            this.db.AddInParameter(databaseCommand, ":CODMTVCTCNOTFSCFRN", DbType.Int32, codigo);

            StringBuilder query = new StringBuilder();
            var reader = db.ExecuteReader(databaseCommand);


            while (reader.Read())
            {
                var stringQuery = reader.GetString(0);
                query.AppendLine(stringQuery);
            }
            
            return query.ToString();
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    public bool ExecutaQuery(string query)
    {
        databaseCommand = db.GetSqlStringCommand(query);

        try
        {
            var executa = db.ExecuteNonQuery(databaseCommand);
            RegistraLog.Log("A execução obteve sucesso");

            return true;

            /*Método para caso implemente a consulta e o response

            if (!query.Contains("'UPDATE'") || !query.Contains("'INSERT'") || !query.Contains("'DELETE"))
            {
                
                var reader = db.ExecuteReader(databaseCommand);

                while (reader.Read())
                {
                   
                    dynamic dto = new ExpandoObject();

                    
                    for (int i = 10; i < reader.FieldCount; i++)
                    {
                        string nomeColuna = reader.GetName(i);
                        object valorColuna = reader[i];

                        ((IDictionary<string, object>)dto).Add(nomeColuna, valorColuna);
                    }
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(dto);
                    return true;
                }
            }
            else
            {
                var reader = db.ExecuteNonQuery(databaseCommand) > 0;
                if (reader)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
            return false;*/
        }
        catch (Exception ex)
        {
            RegistraLog.Log("A execução falhou");
            return false;
        }
    }

    public int GeraChaveSeq(string sigSist, string nomCpo)
    {
        string sql = new IServiceSql().GeraChaveSeq();
        databaseCommand = db.GetSqlStringCommand(sql);

        try
        {
            this.db.AddInParameter(databaseCommand, ":SigSist", DbType.String, sigSist);
            this.db.AddInParameter(databaseCommand, ":NomCpo", DbType.String, nomCpo);

            var reader = this.db.ExecuteReader(databaseCommand);
            
            while (reader.Read())
            {
                return reader.GetInt32(0) + 1;
            }

            return 0;
        }
        catch(Exception ex)
        {
            return 0;
        }
    }
}
