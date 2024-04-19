using Demo.Core.CQRS.Tags;
using Demo.Core.Ids;
using Demo.Core.Tests.Constants;
using NodaTime.Testing;

namespace Demo.Core.Tests.CQRS.Tags;

public class CreateTests(Fixture fixture) : IClassFixture<Fixture>
{
    private CreateTagCommandHandler CreateHandler()
    {
        return new CreateTagCommandHandler(new TestDbContextFactory(fixture.Options), new FakeClock(TestConstants.MockedTime));
    }

    [Fact]
    public async Task CreateTest()
    {
        var handler = CreateHandler();

        var siteId = SiteId.From(fixture.Sites[1].Id);
        const string name = "test";
        const string unit = "C";

        var tag = await handler.Handle(new CreateTagCommand(siteId, name, unit), default);
        Assert.Equal(siteId.Value, tag.SiteId);
        Assert.Equal(name, tag.Name);
        Assert.Equal(unit, tag.Unit);
        Assert.Equal(TestConstants.MockedTime, tag.CreatedAt);
        Assert.Equal(TestConstants.DefaultTime, tag.UpdatedAt);
        
        // fetch from DB
        await using var context = new DemoDbContext(fixture.Options);
        var dbTag = await context.Tags.FindAsync(tag.Id);
        Assert.NotNull(dbTag);
        Assert.Equal(siteId.Value, dbTag.SiteId);
        Assert.Equal(name, dbTag.Name);
        Assert.Equal(unit, dbTag.Unit);
        Assert.Equal(TestConstants.MockedTime, dbTag.CreatedAt);
        Assert.Equal(TestConstants.DefaultTime, tag.UpdatedAt);
    }
}