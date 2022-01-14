﻿using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nex.Simulator.Domain;
using Nex.Simulator.Domain.Interfaces;
using Nex.Simulator.Domain.Models;
using Nex.Simulator.Domain.Services;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddSingleton<IRandomNumberGenerator, RandomNumberGenerator>()
            .AddTransient<INexKillSimulator, NexKillSimulator>()
            .AddTransient<INexUniqueSimulator, NexUniqueSimulator>())
    .Build();

var killsRequired = GetStatsForUniques(6, 1_000_000, host.Services, new NexUnique[]
{
    new ZaryteVambraces(),
    new TorvaFullHelmet(),
    new TorvaPlateBody(),
    new TorvaPlateLegs(),
    new NihilHorn(),
});

await host.RunAsync();

static IEnumerable<int> GetStatsForUniques(
    int teamSize,
    int iterations,
    IServiceProvider services,
    IEnumerable<NexUnique> desiredUniques)
{
    using var serviceScope = services.CreateScope();
    var provider = serviceScope.ServiceProvider;
    var nexSimulator = provider.GetRequiredService<INexUniqueSimulator>();

    desiredUniques = desiredUniques.ToList();

    var results = new List<SimulationResult>();

    for (var i = 0; i < iterations; i++)
    {
        results.Add(nexSimulator.GetKillsForUniques(teamSize, desiredUniques));
    }

    Console.WriteLine($"Team Size: {teamSize}");
    Console.WriteLine($"Total Iterations: {iterations}");
    Console.WriteLine($"Desired Uniques: {string.Join(",", desiredUniques.Select(x => x.Name))}");
    Console.WriteLine($"Average Kills Required: {results.Average(x => x.Kills)}");
    Console.WriteLine($"Minimum Kills Required: {results.Min(x => x.Kills)}");
    var maxKills = results.MaxBy(x => x.Kills);
    var maxKillUniques = maxKills!.Uniques.GroupBy(x => x.Name);
    Console.WriteLine($"Maximum Kills Required: {maxKills.Kills}");
    Console.WriteLine($"The person who got {maxKills.Kills} received:");

    foreach (var unique in maxKillUniques)
    {
        Console.WriteLine($"\t{unique.Count()} {unique.First().Name}");
    }
    Console.WriteLine($"Most Common # Kills Required: {results.GroupBy(x => x.Kills).MaxBy(x => x.Count())!.Key}");

    return results.Select(x => x.Kills);
}
