namespace ChefReservationsMs.Features.Quotations.StateMachines.Responses
{
    public record QuotationQuotedByChef(
    Guid QuotationId,
    string ChefName,
    decimal Price,
    string? ChefComments,
    string ContactEmail);
}
