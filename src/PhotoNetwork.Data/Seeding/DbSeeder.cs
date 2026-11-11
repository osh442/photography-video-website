using Microsoft.AspNetCore.Identity;
using PhotoNetwork.Data.Constants;
using PhotoNetwork.Data.Entities;

namespace PhotoNetwork.Data.Seeding;

public static class DbSeeder
{
    private record DemoUser(string Email, string Role, string? DisplayName, string? Bio);

    private static readonly DemoUser[] DemoUsers =
    {
        new("admin@photonetwork.test", RoleNames.Administrator, null, null),
        new("moderator@photonetwork.test", RoleNames.Moderator, null, null),
        new("anna@photonetwork.test", RoleNames.Photographer, "Анна Петрова", "Снимам пейзажи и природа."),
        new("boris@photonetwork.test", RoleNames.Photographer, "Борис Георгиев", "Улична фотография в София.")
    };

    // Ролите се създават винаги. Демо потребителите - само ако е зададена парола.
    public static async Task SeedAsync(
        RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager,
        string? demoPassword)
    {
        await SeedRolesAsync(roleManager);

        if (!string.IsNullOrWhiteSpace(demoPassword))
        {
            await SeedDemoUsersAsync(userManager, demoPassword);
        }
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = { RoleNames.Photographer, RoleNames.Moderator, RoleNames.Administrator };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task SeedDemoUsersAsync(UserManager<ApplicationUser> userManager, string password)
    {
        foreach (var demo in DemoUsers)
        {
            if (await userManager.FindByEmailAsync(demo.Email) != null)
            {
                continue;
            }

            var user = new ApplicationUser
            {
                UserName = demo.Email,
                Email = demo.Email,
                EmailConfirmed = true
            };

            if (demo.DisplayName != null)
            {
                user.Profile = new PhotographerProfile
                {
                    DisplayName = demo.DisplayName,
                    Bio = demo.Bio
                };
            }

            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Could not create demo user {demo.Email}: {errors}");
            }

            await userManager.AddToRoleAsync(user, demo.Role);
        }
    }
}
