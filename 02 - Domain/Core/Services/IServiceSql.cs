using System.Text;

public class IServiceSql
{
    public string BuscaQuery()
    {
        StringBuilder iSql = new StringBuilder();

        iSql.AppendLine(" SELECT DESRGRNGCMTV, CODMTVCTCNOTFSCFRN                                       ");
        iSql.AppendLine(" FROM MRT.T0150040                                                             ");
        iSql.AppendLine(" WHERE CODEMP = 1 AND CODFILEMP = 1 AND CODMTVCTCNOTFSCFRN = :CODMTVCTCNOTFSCFRN ");
        iSql.AppendLine(" ORDER BY NUMSEQRGRMTV                                                         ");

        return iSql.ToString();
    }

    public string BuscaValor()
    {
        StringBuilder iSql = new StringBuilder();

        iSql.AppendLine("SELECT  TO_NUMBER(regra.CODMTVCTCNOTFSCFRN)  AS CODMTVCTCNOTFSCFRN ,");
        iSql.AppendLine("    CODGRPCTC ");
        iSql.AppendLine("FROM    MRT.T0140770 regra");
        iSql.AppendLine("    INNER JOIN  MRT.T0150067 ATIVA ON ( ATIVA.CODFILEMP = 01 AND ATIVA.CODMTVCTCNOTFSCFRN = regra.CODMTVCTCNOTFSCFRN AND ATIVA.DATDST IS NULL)");
        iSql.AppendLine("WHERE   TRIM(regra.NOMTABDSN) = 'ROTBET'");
        iSql.AppendLine("    AND regra.CODGRPCTC =  :CODGRPCTC");
        iSql.AppendLine("ORDER BY   TO_NUMBER(regra.CODMTVCTCNOTFSCFRN)");

        return iSql.ToString();
    }

    public string GeraChaveSeq()
    {
        StringBuilder iSql = new StringBuilder();

        iSql.AppendLine("SELECT DESVLRATUATR");
        iSql.AppendLine("FROM   MRT.T0149816");
        iSql.AppendLine("WHERE  CODEMP = 1");
        iSql.AppendLine("   AND CODFILEMP = 1");
        iSql.AppendLine("   AND NOMSISINF = :SigSist");
        iSql.AppendLine("   AND NOMATR = :NomCpo");

        return iSql.ToString();
    }
}

