namespace EAA103._03___Infrastructure.DTO
{
    public class QueryIRecollectionDTO
    {
        public string DESRGRNGCMTV { get; set; }
        public int CODFILEMP { get; set; }
        public int CODMTVCTCNOTFSCFRN { get; set; }
        public int NUMSEQRGRMTV { get; set; }

        #region CONSTRUCTOR
        public QueryIRecollectionDTO(string dESRGRNGCMTV, int cODFILEMP, int cODMTVCTCNOTFSCFRN, int nUMSEQRGRMTV)
        {
            DESRGRNGCMTV = dESRGRNGCMTV;
            CODFILEMP = cODFILEMP;
            CODMTVCTCNOTFSCFRN = cODMTVCTCNOTFSCFRN;
            NUMSEQRGRMTV = nUMSEQRGRMTV;
        }
        #endregion
    }
}
