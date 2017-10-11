using ATS.Core.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ATS.Core.Domain.ValueObjects
{
    public class Telefone
    {
        public const int TelefoneMaxLength = 15;
        public const int TelefoneMinLength = 14;

        public string Numero { get; private set; }

        //Construtor do EntityFramework
        protected Telefone()
        {
        }

        public Telefone(string numero)
        {
            Numero = numero;
        }

        public static bool IsValid(string numero)
        {
            var regexTelefone = new Regex(@"^\([1-9]{2}\) (?:[2-8][0-9]|9[1-9])[0-9]{2,3}\-[0-9]{4}$");
            return regexTelefone.IsMatch(numero);
        }
        
    }
}
