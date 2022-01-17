namespace Investimento.API.Models
{
    public class ClienteCorretora
    {
        public ClienteCorretora() { }
        public ClienteCorretora(int clienteId, int corretoraId) 
        {
            this.ClienteId = clienteId;
            this.CorretoraId = corretoraId;   
        }
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public int CorretoraId { get; set; }

        public Corretora Corretora { get; set; }
    }
}