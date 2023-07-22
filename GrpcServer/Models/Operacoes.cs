using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrpcServer.Models;

public partial class Operacoes
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("operacao")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Operacao { get; set; }

    [Column("operador")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Operador { get; set; }

    [Column("num_administrativo")]
    public string? NumAdministrativo { get; set; }

    [Column("dataatual", TypeName = "datetime")]
    public DateTime? Dataatual { get; set; }
}
