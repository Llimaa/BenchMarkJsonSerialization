namespace BenchMarkJsonSerialization;

public record  Person(
    Guid Id,
    string? Name,
    DateTime Birthday,
    IEnumerable<Address> Addresses
);

public record Address(
    Guid Id,
    string? Street,
    string? City,
    string? State,
    string? Zip
);
