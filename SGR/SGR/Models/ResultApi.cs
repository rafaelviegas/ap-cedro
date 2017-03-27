using System.Collections.Generic;

namespace SGR.Models
{
    public class ResultApi<T>
    {
        public ResultApi()
        {
            Sucesso = true;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public IEnumerable<T> Dados { get; set; }

        public int Total { get; set; }
    }

}