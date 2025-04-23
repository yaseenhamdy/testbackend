using System;
using System.Collections.Generic;

namespace TactiForge.Repository.Entities.Fifa24Models;

public partial class PlayerPosition
{
    public int PlayerId { get; set; }

    public int FifaVersion { get; set; }

    public string? Ls { get; set; }

    public string? St { get; set; }

    public string? Rs { get; set; }

    public string? Lw { get; set; }

    public string? Lf { get; set; }

    public string? Cf { get; set; }

    public string? Rf { get; set; }

    public string? Rw { get; set; }

    public string? Lam { get; set; }

    public string? Cam { get; set; }

    public string? Ram { get; set; }

    public string? Lm { get; set; }

    public string? Lcm { get; set; }

    public string? Cm { get; set; }

    public string? Rcm { get; set; }

    public string? Rm { get; set; }

    public string? Lwb { get; set; }

    public string? Ldm { get; set; }

    public string? Cdm { get; set; }

    public string? Rdm { get; set; }

    public string? Rwb { get; set; }

    public string? Lb { get; set; }

    public string? Lcb { get; set; }

    public string? Cb { get; set; }

    public string? Rcb { get; set; }

    public string? Rb { get; set; }

    public string? Gk { get; set; }

    public virtual Player Player { get; set; } = null!;
}
