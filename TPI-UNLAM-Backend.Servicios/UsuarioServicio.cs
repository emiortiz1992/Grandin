using TPI_UNLAM_Backend.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text.RegularExpressions;

using TIP_UNLAM_Backend.Data.Dto;
using TIP_UNLAM_Backend.Data.EF;
using TIP_UNLAM_Backend.Data.Repositorios.Interfaces;
using TPI_UNLAM_Backend.Servicios.Interfaces;
using TPI_UNLAM_Backend.Exceptions;


namespace TPI_UNLAM_Backend.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private IUsuarioRepositorio _userRepo;
        private IUsuarioXUsuarioRepositorio _userXUsuarioRepo;

        private IAppSharedFunction _appSharedFunction;

        public UsuarioServicio(IUsuarioRepositorio userRepo, IAppSharedFunction appSharedFunction, IUsuarioXUsuarioRepositorio userXUsuarioRepo)
        {
            _userRepo = userRepo;
            _appSharedFunction = appSharedFunction;
            _userXUsuarioRepo = userXUsuarioRepo;
        }

        public string AgregarUsuario(UsuarioDto usuario)
        {
            
                Usuario userNuevo = new Usuario();

                if (getUsuarioByEmail(usuario.usuario.Mail) != null)
                    throw new BadRequestException("Ya existe el usuario");

                if (ContrasenaSegura(usuario.usuario.Contrasena) == false)
                    throw new BadRequestException("Verificar que la clave tenga un minimo de 8 caracteres, al menos tenga un caracter, un numero y un caracter especial");

                if (ValidateEmail(usuario.usuario.Mail) == false)
                    throw new BadRequestException("El mail no es valido");

                userNuevo.Mail = usuario.usuario.Mail;
                userNuevo.Contrasena = usuario.usuario.Contrasena;
                userNuevo.FechaAlta = DateTime.Now;
                userNuevo.FechaNacimiento = usuario.usuario.FechaNacimiento;
                userNuevo.Activo = false;
                userNuevo.Nombre = usuario.usuario.Nombre;
                userNuevo.Apellido = usuario.usuario.Apellido;
                userNuevo.Dni = usuario.usuario.Dni;
                userNuevo.Telefono = usuario.usuario.Telefono;
                userNuevo.GeneroId = usuario.usuario.GeneroId;
                if (String.IsNullOrEmpty(usuario.usuario.Matricula))
                {
                    userNuevo.TipoUsuarioId = 1;
                    usuario.usuario.TipoUsuarioId = 1;
                    userNuevo.NombreTutor = usuario.usuario.NombreTutor;

                    //usuario.usuario.TipoUsuarioId = userNuevo.TipoUsuarioId;
                }
                else
                {
                    userNuevo.TipoUsuarioId = 2;
                    usuario.usuario.TipoUsuarioId = 2;
                }

                _userRepo.AgregarUsuario(userNuevo);
                _userRepo.SaveChanges();

                agregarRelacion(usuario);
                

                return "El usuario se registro correctamente"; ;
            
           
        }

      

        public void modificarUsuario(Usuario usuario)
        {
            Usuario usuarioModificado = getUsuarioById(usuario.Id);

            usuarioModificado.Nombre = usuario.Nombre;
            usuarioModificado.Apellido = usuario.Apellido;
            usuarioModificado.Contrasena = usuario.Contrasena;
            usuarioModificado.Mail = usuario.Mail;

            _userRepo.SaveChanges();
        }

        public void agregarRelacion(UsuarioDto usuario)
        {
            if (usuario.usuario.TipoUsuarioId == 1)
            {
                Usuario usuarioPro = getUsuarioById(usuario.usuarioProfesionalId);
                Usuario paciente = _userRepo.getUsuarioByEmail(usuario.usuario.Mail);

                if (usuarioPro == null)
                    throw new BadRequestException("El usuario del Profesional no se encuentra en nuestra lista");

                UsuarioXusuario userxuser = new UsuarioXusuario();
                userxuser.Pendiente = true;
                userxuser.UsuarioPacienteId = paciente.Id;
                userxuser.UsuarioProfesionalId = usuarioPro.Id;
                userxuser.FechaInicioRelacion = null;
                userxuser.FechaFinalizacionRelacion = null;
                userxuser.Activo = false;
                _userXUsuarioRepo.agregarRelacion(userxuser);
                _userXUsuarioRepo.SaveChanges();

            }
        }

        public UsuarioDto Login(LoginDto loginDto)
        {
            try
            {
                if (loginDto.email == null || loginDto.contrasena == null)
                    throw new BadRequestException("Los datos ingresados incorrectos");

                Usuario usuario = new Usuario();
                UsuarioDto usuarioDto = new UsuarioDto();

                usuario = _userRepo.getUsuarioByEmail(loginDto.email);

                if (usuario == null)
                    throw new BadRequestException("Mail o clave incorrecta");

                if (usuario.Contrasena != loginDto.contrasena)
                    throw new BadRequestException("Mail o clave incorrecta");

                UserTokenDto tokenDto = _appSharedFunction.BuildTokenUsuario(loginDto.email, loginDto.contrasena);


               
                 
                
                usuarioDto.usuario = usuario;
                usuarioDto.token = tokenDto.Token;

                return usuarioDto;
            }
            catch (Exception)
            {
                throw new BadRequestException("Los datos ingresados incorrectos");
            }

        }

        public string HabilitarProfesional(int id, bool estado)
        {
            Usuario profesinal = _userRepo.getUsuarioById(id);
            if (estado == false)
            {
                profesinal.Activo = true;
            }
            else
            {
                profesinal.Activo = false;
            }
            

            _userRepo.SaveChanges();

            return string.Format("El profesional {0} se ha habilitado correctamente", profesinal.Nombre);

        }

        #region Validaciones
        private Boolean ValidateEmail(String email)
        {
            if (email == null)
                return false;

            if (new EmailAddressAttribute().IsValid(email))
                return true;

            return false;
        }

        private Boolean ContrasenaSegura(String contraseñaSinVerificar)
        {
            //letras de la A a la Z, mayusculas y minusculas
            Regex letras = new Regex(@"[a-zA-z]");
            //digitos del 0 al 9
            Regex numeros = new Regex(@"[0-9]");
            //cualquier caracter del conjunto
            Regex caracEsp = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]^_`{|}~]");

            Boolean cumpleCriterios = false;

            //si no contiene las letras, regresa false
            if (!letras.IsMatch(contraseñaSinVerificar))
                return false;

            //si no contiene los numeros, regresa false
            if (!numeros.IsMatch(contraseñaSinVerificar))
                return false;

            //si no contiene los caracteres especiales, regresa false
            if (!caracEsp.IsMatch(contraseñaSinVerificar))
                return false;

            //Si la contraseña tiene menos de 8 caracteres, regresa false
            if (contraseñaSinVerificar.Length < 8)
                return false;

            //si cumple con todo, regresa true
            return true;
        }
        #endregion

        #region Get

        public List<Usuario> getAllUsuariosProfesionales()
        {
            return _userRepo.getAllUsuariosProfesionales();
        }

        public List<Usuario> getAllUsuariosProfesionalesActivos()
        {
            return _userRepo.getAllUsuariosProfesionalesActivos();
        }

        public List<Usuario> getAllUsuariosProfesionalesInactivos()
        {
            return _userRepo.getAllUsuariosProfesionalesInactivos();
        }

        public List<Usuario> getAllUsuariosPacientesActivos()
        {
            return _userRepo.getAllUsuariosPacientesActivos();
        }

        public List<Usuario> getAllUsuariosPacientesInactivos()
        {
            return _userRepo.getAllUsuariosPacientesInactivos();
        }

        public List<Usuario> getAllUsuariosPacientes()
        {
            return _userRepo.getAllUsuariosPacientes();
        }
        public Usuario getUsuarioByEmail(string email)
        {
            return _userRepo.getUsuarioByEmail(email);
        }
        public Usuario getUsuarioById(int id)
        {
            if (id == null)
                throw new BadRequestException("Los datos ingresados incorrectos");

            Usuario user = _userRepo.getUsuarioById(id);

            if (user == null)
                throw new BadRequestException("No existe Usuario");

            return user;
        }

        #endregion

        public void SaveChanges()
        {
            _userRepo.SaveChanges();
        }

     
    }
}
