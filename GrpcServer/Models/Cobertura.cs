using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Models;

[Table("Cobertura")]
public partial class Cobertura
{
    [Key]
    [Column("num_administrativo")]
    public string? NumAdmin { get; set; }

    [Column("rua")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Rua { get; set; }

    [Column("numero")]
    public int? Numero { get; set; }

    [Column("operator")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Operator { get; set; }

    [Column("modalidade")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Modalidade { get; set; }

    [Column("estado")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Estado { get; set; }
}
