using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBankApp.Model
{
    public class Cliente
    {
        public string NomeTitular { get; set; }
        public string CpfTitular { get; private set; }
        public string UsrTitular { get; private set; }
        public string PwdTitular { get; private set; }
        private Regex _regex = new Regex(@"([0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", RegexOptions.IgnoreCase);
        public bool CpfValidado { get; private set; }

        // CONSTRUTORES
        public Cliente(string NomeTitular, string CpfTitular)
        {
            this.NomeTitular = NomeTitular;

            this.CpfValidado = _regex.IsMatch(CpfTitular);
            if (CpfValidado)
            {
                this.CpfTitular = CpfTitular;                
            }   
        }        

        //CRIAR SENHA DE ACESSO
        public void CriarSenha(string usrTitular, string pwdTitular)
        {
            this.UsrTitular = usrTitular;
            this.PwdTitular = pwdTitular;
        }

    }
}
