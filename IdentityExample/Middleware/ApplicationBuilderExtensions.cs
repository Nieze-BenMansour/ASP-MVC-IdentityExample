using Microsoft.Extensions.FileProviders;

namespace IdentityExample.Middleware;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseNodeModules(this IApplicationBuilder applicationBuilder, string root)
    {
        var path = Path.Combine(root, "node_modules");
        var fileProvider = new PhysicalFileProvider(path);

        var options = new StaticFileOptions();
        options.RequestPath = "/node_modules";
        options.FileProvider = fileProvider;

        applicationBuilder.UseStaticFiles(options);
        return applicationBuilder;
    }
}
