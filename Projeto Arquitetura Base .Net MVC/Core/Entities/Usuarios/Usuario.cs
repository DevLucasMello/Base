using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Usuarios
{

    /// <summary>
    /// Usuário generico com acesso ao sistema
    /// </summary>
    [Table("Usuarios", Schema = "Usuarios")]
    public class Usuario : Base.PersistentEntity
    {

        public enum Tipos
        {

        }

        public Guid Codigo { get; set; }

        public int TipoID { get; set; }

        /// <summary>
        /// Saldo de créditos adquiridos e disponíveis para o fiel ou créditos ganhos pelo pastor
        /// </summary>
        public int SaldoCreditos { get; set; }

        [MaxLength(100)]
        public string Foto { get; set; }

        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(200)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Senha { get; set; }

        public bool Bloqueado { get; set; }

        public DateTime? UltimoAcesso { get; set; }

        [NotMapped]
        public Tipos Tipo
        {
            get { return (Tipos)this.TipoID; }
            set { this.TipoID = (int)value; }
        }

        [NotMapped]
        public string SenhaLimpa
        {
            get { return String.Empty; }
            set { this.Senha = Helpers.CriptographyHelper.Encript(value); }
        }

    

    }
}
