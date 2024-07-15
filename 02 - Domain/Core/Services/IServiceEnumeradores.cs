/// <summary>
/// Enumeradores
/// </summary>
public class Enumeradores
{
    /// <summary>
    /// Banco de dados
    /// </summary>
    public enum BANCODEDADOS
    {
        /// <summary>
        /// Banco de dados corporativo MRT001
        /// </summary>
        MRT001 = 0,
        /// <summary>
        /// Banco de dados WMS
        /// </summary>
        MRTAAD = 1
    }

    /// <summary>
    /// Eventos da API de Tracking
    /// </summary>
    public enum EVENTOSTRACKING
    {
        /// <summary>
        /// Documento fiscal recebido eletronicamente
        /// </summary>
        NFE_INTERNALIZADA = 401,
        /// <summary>
        /// Conferencia fisica realizada
        /// </summary>
        CONFERENCIA_FISICA_REALIZADA = 402
    }
}