using System.Collections.Generic;

namespace ATS.Cadastro.Infra.CrossCutting.Identity.Modelo
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<string> Providers { get; set; }
    }
}
