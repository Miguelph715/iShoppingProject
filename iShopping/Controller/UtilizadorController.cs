using iShopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iShopping.Controller
{
    public class UtilizadorController
    {
        // 1. Guardar o Id do Utilizador (Exigência do Enunciado)
        // Usamos 'static' para que o valor se mantenha durante toda a execução da aplicação,
        // independentemente do formulário onde estejas.
        public static int? UtilizadorLogadoId { get; private set; }

        public static string NomeUtilizadorLogado { get; private set; }

        // 2. Método para Registar um Utilizador
        // Retorna 'true' se sucesso, ou 'false' se falhar (e preenche a mensagem de erro)
        public bool RegistarUtilizador(string username, string password, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            // Instancia a ligação à base de dados
            using (var db = new iShoppingContext())
            {
                // Verifica se já existe alguém com este Username na base de dados
                bool utilizadorExiste = db.Utilizadores.Any(u => u.Username == username);

                if (utilizadorExiste)
                {
                    mensagemErro = "Já existe um utilizador com esse Username. Por favor, escolha outro.";
                    return false;
                }

                // Se não existir, cria o novo utilizador
                var novoUtilizador = new Utilizador
                {
                    Username = username,
                    Password = password // (Numa app real a password deveria ser encriptada)
                };

                // Adiciona e guarda as alterações na Base de Dados
                db.Utilizadores.Add(novoUtilizador);
                db.SaveChanges();

                return true;
            }
        }

        // 3. Método para Efetuar o Login
        public bool EfetuarLogin(string username, string password)
        {
            using (var db = new iShoppingContext())
            {
                // Procura na base de dados um utilizador que tenha este exato username e password
                var utilizador = db.Utilizadores
                                   .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (utilizador != null)
                {
                    // Sucesso! Guardamos o Id do utilizador na variável estática
                    UtilizadorLogadoId = utilizador.Id;
                    NomeUtilizadorLogado = utilizador.Username;
                    return true;
                }

                // Se o 'utilizador' for null, significa que as credenciais estão erradas
                return false;
            }
        }

        // Método extra para fazeres Logout mais tarde
        public void FazerLogout()
        {
            UtilizadorLogadoId = null;
            NomeUtilizadorLogado = null;
        }
    }
}
