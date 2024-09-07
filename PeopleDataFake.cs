namespace BenchMarkJsonSerialization;

internal static class PeopleDataFake
{
        public static IEnumerable<Address> GetAddresses()
    {
        return Enumerable.Range(1, 2).Select(i =>
        {
            return new Address(
                Guid.NewGuid(),
                "street"+ i,
                "city"+ i,
                "state"+ i,
                "zip" + i);
        }
        );
    }
    public static Person[] GetPeople()
    {
        return Enumerable.Range(1, 1000000).Select(i =>
        {
            return new Person(
                Guid.NewGuid(),
                "Name_" + i,
                DateTime.UtcNow,
                GetAddresses()
            );
        }
        ).ToArray();
    }
}
