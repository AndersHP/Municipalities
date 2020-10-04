using Core.Domain;

namespace Core.Usecases
{
    public interface IMunicipalityFileHandler
    {
        Municipality ImportMunicipality();
        void ExportMunicipality();
    }
}