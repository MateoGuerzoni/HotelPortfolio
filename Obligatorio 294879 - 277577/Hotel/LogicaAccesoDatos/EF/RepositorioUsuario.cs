using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.InterfacesRepositorio;


namespace LogicaAccesoDatos.EF
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private HotelContext _context;
        public RepositorioUsuario(HotelContext context)
        {
            _context = context;
        }

        public void precargarUsuarios()
        {
            try
            {
                Usuario user = new Usuario();
                user.Email = "mateo@hotmail.com";
                user.Password = "Mateo123";
                user.Validar();
                if (!ExisteUsuario(user.Email))
                {
                    _context.Usuarios.Add(user);
                    _context.SaveChanges();
                }
                Usuario user2 = new Usuario();
                user2.Email = "messi@hotmail.com";
                user2.Password = "Messi10";
                user2.Validar();
                if (!ExisteUsuario(user2.Email))
                {
                    _context.Usuarios.Add(user2);
                    _context.SaveChanges();
                }
                Usuario user3 = new Usuario();
                user3.Email = "diego@gmail.com";
                user3.Password = "Diego123";
                user3.Validar();
                if (!ExisteUsuario(user3.Email))
                {
                    _context.Usuarios.Add(user3);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuario ya existe");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void Add(Usuario obj)
        {
            try
            {
                obj.Validar();
                _context.Usuarios.Add(obj);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }



        public bool Delete(int id)
        {
            Usuario user = Get(id);
            try
            {
                _context.Usuarios.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Usuario Get(int id)
        {
            if (id == 0)
            {
                throw new Exception("No se recibio el id");
            }
            var tema = _context.Usuarios
                .FirstOrDefault(tema => tema.Id == id);
            if (tema == null)
            {
                throw new Exception("No se encontro el id");
            }
            return tema;
        }

        public Usuario GetUsuarioByMail(string email)
        {

            try
            {
                if (email == null || email == " ")
                {
                    throw new Exception("Ingrese un mail valido");
                }
                else
                {
                    var user = _context.Usuarios
                    .FirstOrDefault(user => user.Email == email);

                    return user;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"Error en GetUsuarioByMail {e.Message}");
            }
        }

        public bool ExisteUsuario(string email)
        {
            if (GetUsuarioByMail(email) != null)
            {
                return true;
            }
            return false;
        }

        public bool ChequearContraseniaPorUsuario(string email, string pass)
        {
            try
            {
                Usuario user = GetUsuarioByMail(email);
                if (user == null)
                {
                    throw new Exception("No se encontró el usuario");
                }
                else
                {
                    if (user.Password != pass)
                    {
                        throw new Exception("Contraseña incorrecta");
                    }
                }
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public IEnumerable<Usuario> GetUsuariosByName(string mail)
        {
            IEnumerable<Usuario> usuarios =
             _context.Usuarios.
             Where(usuario => usuario.Email.Contains(mail)).
             ToList();
            return usuarios;
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
