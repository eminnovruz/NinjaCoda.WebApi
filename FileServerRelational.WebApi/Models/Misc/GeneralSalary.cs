﻿using FileServerRelational.WebApi.Models.Common;

namespace FileServerRelational.WebApi.Models.Misc;

public class Salary : BaseEntity
{
    public int JuniorSalary { get; set; }
    public int MiddleSalary { get; set; }
    public int SeniorSalary { get; set; }
}
