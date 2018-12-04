using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    //ToDo: OO - Herança (:) com a classe Veiculo.
    public class VeiculoPasseio : Veiculo//, Caminhao
    {
        public Carroceria Carroceria { get; set; }

        //ToDo: OO - Polimorfismo por sobrescrita.
        public override List<string> Validar()
        {
            var erros = base.ValidarBase();

            if (!Enum.IsDefined(typeof(Carroceria), Carroceria))
            {
                erros.Add($"A Carroceria informada ({Carroceria}) não é válida.");
            }

            return erros;
        }
    }
}
