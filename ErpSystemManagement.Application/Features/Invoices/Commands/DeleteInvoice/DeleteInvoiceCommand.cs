using DomainResults.Common;
using MediatR;

namespace ErpSystemManagement.Application.Features.Invoices.Commands.DeleteInvoice;

public record DeleteInvoiceCommand(Guid Id) : IRequest<IDomainResult<string>>;