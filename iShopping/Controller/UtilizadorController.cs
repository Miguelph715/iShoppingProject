using iShopping.Model;
using System.Collections.Generic;
using System.Linq;

namespace iShopping.Controller
{
    public class UtilizadorController
    {
        public static int? UtilizadorLogadoId { get; private set; }

        public static string NomeUtilizadorLogado { get; private set; }

        public List<Utilizador> ObterTodos()
        {
            using (var db = new iShoppingContext())
            {
                return db.Utilizadores
                    .OrderBy(u => u.Username)
                    .ToList();
            }
        }

        public Utilizador ObterPorId(int id)
        {
            using (var db = new iShoppingContext())
            {
                return db.Utilizadores
                    .FirstOrDefault(u => u.Id == id);
            }
        }

        public bool RegistarUtilizador(string username, string password, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            username = username.Trim();
            password = password.Trim();

            using (var db = new iShoppingContext())
            {
                bool utilizadorExiste = db.Utilizadores.Any(u => u.Username == username);

                if (utilizadorExiste)
                {
                    mensagemErro = "Já existe um utilizador com esse username.";
                    return false;
                }

                Utilizador novoUtilizador = new Utilizador
                {
                    Username = username,
                    Password = password
                };

                db.Utilizadores.Add(novoUtilizador);
                db.SaveChanges();

                return true;
            }
        }

        public bool AtualizarUtilizador(int id, string username, string password, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            username = username.Trim();
            password = password.Trim();

            using (var db = new iShoppingContext())
            {
                Utilizador utilizador = db.Utilizadores.FirstOrDefault(u => u.Id == id);

                if (utilizador == null)
                {
                    mensagemErro = "Utilizador não encontrado.";
                    return false;
                }

                bool usernameJaExisteNoutroUtilizador = db.Utilizadores.Any(u =>
                    u.Id != id &&
                    u.Username == username
                );

                if (usernameJaExisteNoutroUtilizador)
                {
                    mensagemErro = "Já existe outro utilizador com esse username.";
                    return false;
                }

                utilizador.Username = username;
                utilizador.Password = password;

                db.SaveChanges();

                return true;
            }
        }

        public bool EliminarUtilizador(int id, out string mensagemErro)
        {
            mensagemErro = string.Empty;

            using (var db = new iShoppingContext())
            {
                Utilizador utilizador = db.Utilizadores.FirstOrDefault(u => u.Id == id);

                if (utilizador == null)
                {
                    mensagemErro = "Utilizador não encontrado.";
                    return false;
                }

                if (UtilizadorLogadoId.HasValue && UtilizadorLogadoId.Value == id)
                {
                    mensagemErro = "Não pode eliminar o utilizador que está atualmente autenticado.";
                    return false;
                }

                db.Utilizadores.Remove(utilizador);
                db.SaveChanges();

                return true;
            }
        }

        public bool EfetuarLogin(string username, string password)
        {
            username = username.Trim();
            password = password.Trim();

            using (var db = new iShoppingContext())
            {
                Utilizador utilizador = db.Utilizadores
                    .FirstOrDefault(u => u.Username == username && u.Password == password);

                if (utilizador != null)
                {
                    UtilizadorLogadoId = utilizador.Id;
                    NomeUtilizadorLogado = utilizador.Username;
                    return true;
                }

                return false;
            }
        }

        public void FazerLogout()
        {
            UtilizadorLogadoId = null;
            NomeUtilizadorLogado = null;
        }
    }
}