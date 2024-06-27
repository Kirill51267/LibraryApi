namespace LibraryApi.Contracts
{
    public record BookResponse(
        Guid id,
        string Title,
        string Description,
        decimal Price);
}
