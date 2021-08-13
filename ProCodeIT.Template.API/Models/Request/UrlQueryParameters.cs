using ProCodeIT.Template.DAL.Infra.Extension.Ordination;

namespace ProCodeIT.Template.API.Models.Request
{
    public class UrlQueryParameters
    {
        public int Limit { get; set; } = 10;

        public int Page { get; set; } = 1;

        public OrdinationEnum Ordination { get; set; } = OrdinationEnum.BEST_SELLERS;
    }
}
