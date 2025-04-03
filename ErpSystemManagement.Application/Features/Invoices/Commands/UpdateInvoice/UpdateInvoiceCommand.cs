using DomainResults.Common;
using ErpSystemManagement.Application.Dtos;
using MediatR;

namespace ErpSystemManagement.Application.Features.Invoices.Commands.UpdateInvoice;

public record UpdateInvoiceCommand(
    Guid Id,
    Guid CustomerId,
    DateOnly Date,
    int InvoiceType,
    string InvoiceNumber,
    List<InvoiceDetailDto> Details) : IRequest<IDomainResult<string>>;