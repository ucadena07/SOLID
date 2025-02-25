﻿using HRManagement.Application.Contracts.Email;
using HRManagement.Application.Models.Email;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.Infrastructure.EmailService;

public class EmailSender : IEmailSender
{
    private  EmailSettings _emailSettings { get; }
    public EmailSender(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;   
    }
    public async Task<bool> SendEmailAsync(EmailMessage email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress { Email= _emailSettings.FromAddress,Name = _emailSettings.FromName };

        var message = MailHelper.CreateSingleEmail(from,to,email.Subject,email.Body,email.Body);   
        var response = await client.SendEmailAsync(message);    

        return response.IsSuccessStatusCode;


    }
}
