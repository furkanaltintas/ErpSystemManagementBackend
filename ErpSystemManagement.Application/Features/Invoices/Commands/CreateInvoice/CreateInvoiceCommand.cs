using DomainResults.Common;
using ErpSystemManagement.Application.Dtos;
using MediatR;

namespace ErpSystemManagement.Application.Features.Invoices.Commands.CreateInvoice;

public record CreateInvoiceCommand(
    Guid CustomerId,
    int InvoiceType,
    DateOnly Date,
    string InvoiceNumber,
    List<InvoiceDetailDto> Details) : IRequest<IDomainResult<string>>;