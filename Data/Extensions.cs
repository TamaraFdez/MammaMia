namespace MammaMia.Data;
public static class Extension{
    public static void CreateDBIfNoExists(this IHost host){
        using(var scope = host.Services.CreateScope()){
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<PizzaContext>();
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }
}