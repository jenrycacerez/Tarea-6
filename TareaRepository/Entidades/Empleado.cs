﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaRepository.Entidades
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        public DateTime Fecha { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Cedula { get; set; }

        public decimal Sueldo { get; set; }

        public decimal Incentivo { get; set; }



        public Empleado()
        {
            EmpleadoId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Cedula = string.Empty;
            Sueldo = 0;
            Incentivo = 0;
        }
    }
}
