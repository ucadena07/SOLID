using HRManagement.Application.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(EmailMessage email);
}
