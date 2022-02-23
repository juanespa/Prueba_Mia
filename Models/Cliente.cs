namespace Prueba_Mia.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Cliente")]
    public partial class Cliente
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Cedula { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(50)]
        public string Correo { get; set; }

        [StringLength(50)]
        public string Direccion { get; set; }

        [StringLength(10)]
        public string Telefono { get; set; }

        public List<Cliente> listarClientes()
        {
            List<Cliente> lst = new List<Cliente>();
            using (var ctx = new Model1())
            {
                lst = ctx.Cliente.ToList();
            }
            return lst;
        }

        public void CrearCliente(Cliente cliente)
        {
            using (var ctx = new Model1())
            {
                ctx.Cliente.Add(cliente);
                ctx.SaveChanges();
            }
        }

        public Cliente VerCliente(int id)
        {
            Cliente cli = new Cliente();
            using (var ctx = new Model1())
            {
                cli = ctx.Cliente.Where(x => x.Id == id).FirstOrDefault();

            }

            return cli;
        }

        public Cliente Eliminar(int id)
        {
            Cliente cli = new Cliente();
            using (var ctx = new Model1())
            {
                cli = ctx.Cliente.Find(id);
                ctx.Cliente.Remove(cli);
                ctx.SaveChanges();
            }

            return cli;
        }
    }


}
