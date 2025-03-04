using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key): base($"{name} ({key} not found)")
    {
        
    }

    public IDictionary<string, string[]> ValidationErrors { get; set; }
}

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base($"{message}")
    {

    }
    public BadRequestException(string message, ValidationResult validation):base(message) 
    {
        ValidationErrors = validation.ToDictionary();
    }

    public IDictionary<string, string[]> ValidationErrors { get; set; }    
}

