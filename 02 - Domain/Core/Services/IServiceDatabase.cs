using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data.Common;

/// <summary>
/// Classe de conexão com o banco de dados.
/// </summary>
public class ConexaoBD : Martins.Layers.DAL, IDisposable
{
    #region ATRIBUTOS E PROPRIEDADES

    /// <summary>
    /// Instância da base de dados.
    /// </summary>
    public Database db;

    /// <summary>
    /// Comando executado.
    /// </summary>
    public DbCommand databaseCommand;


    /// <summary>
    /// Instância da base de dados.
    /// </summary>
    public Database dbWms;

    /// <summary>
    /// Comando executado.
    /// </summary>
    public DbCommand databaseCommandWms;

    #endregion

    #region CONSTRUTORES

    /// <summary>
    /// Busca a configuração padrão da Web Config.
    /// </summary>
    public ConexaoBD(Enumeradores.BANCODEDADOS e = Enumeradores.BANCODEDADOS.MRT001)
    {
        if (e == Enumeradores.BANCODEDADOS.MRT001)
        {
            this.db = new DatabaseProviderFactory(new SystemConfigurationSource()).CreateDefault();
        }
        else if (e == Enumeradores.BANCODEDADOS.MRTAAD)
        {
            this.dbWms = new DatabaseProviderFactory(new SystemConfigurationSource()).Create("MRTAAD");
        }
    }

    #endregion

    #region MÉTODOS

    /// <summary>
    /// Força o descarte dos objetos e encerramento de conexões.
    /// </summary>
    public void Dispose()
    {
        if (this.databaseCommand != null && this.databaseCommand.Connection != null)
        {
            this.databaseCommand.Connection.Close();
            this.databaseCommand.Connection.Dispose();
        }

        if (this.databaseCommand != null)
        {
            this.databaseCommand.Dispose();
        }

        if (this.databaseCommandWms != null && this.databaseCommandWms.Connection != null)
        {
            this.databaseCommandWms.Connection.Close();
            this.databaseCommandWms.Connection.Dispose();
        }

        if (this.databaseCommandWms != null)
        {
            this.databaseCommandWms.Dispose();
        }
    }

    public void Open()
    {
        this.databaseCommand.Connection.Open();
        this.databaseCommand.Connection.BeginTransaction();
    }

    #endregion
}