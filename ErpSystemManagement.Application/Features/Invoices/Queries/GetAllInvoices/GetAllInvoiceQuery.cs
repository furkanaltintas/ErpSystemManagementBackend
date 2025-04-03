using DomainResults.Common;
using ErpSystemManagement.Domain.Entities;
using MediatR;

namespace ErpSystemManagement.Application.Features.Invoices.Queries.GetAllInvoices;

public record GetAllInvoiceQuery(int Type) : IRequest<IDomainResult<List<Invoice>>>;
