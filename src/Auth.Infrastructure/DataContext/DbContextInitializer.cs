namespace Auth.Infrastructure.DataContext;

public static class DbContextInitializer
{
    public static void Init(AppDbContext context)
    {
        context.Database.EnsureCreated();
    }
}