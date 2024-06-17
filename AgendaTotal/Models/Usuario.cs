using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaTotal.Models
{
    public class Usuario
    {
        [Display(Name="Id")]
        public int id_usuario {get; set; }
        [Display(Name = "Nome")]
        public string nome {get; set; }
        [Display(Name = "Email")]
        public string email {get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string senha {get; set; }
        [Display(Name = "País")]
        public string pais { get; set; }
        [Display(Name = "Status")]
        public bool status_ { get; set; }

        public Usuario()
        {
        }



    }
}
