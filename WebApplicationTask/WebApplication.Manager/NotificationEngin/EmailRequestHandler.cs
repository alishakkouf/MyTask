using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace WebApplication.Manager.NotificationEngin
{
    public class EmailRequestHandler : IRequestHandler<EmailRequest, Unit>
    {
        private readonly IMailService _mailService;

        public EmailRequestHandler(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task<Unit> Handle(EmailRequest request, CancellationToken cancellationToken)
        {
            // Use your mail service to send an email
            await _mailService.SendEmailAsync(request.To, request.Subject, request.Body);
            return Unit.Value;
        }
    }
}
